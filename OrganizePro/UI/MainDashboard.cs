using OrganizePro.Shared;
using OrganizePro.Services;
using OrganizePro.UI;
using Microsoft.Extensions.DependencyInjection;

namespace OrganizePro;
public partial class MainDashboard : Form
{
    private readonly CustomerService _customerService;
    private readonly AppointmentService _appointmentService;
    private readonly ReportService _reportService;
    private readonly Store _store;
    private readonly IServiceProvider _serviceProvider;

    public MainDashboard(
        CustomerService customerService,
        AppointmentService appointmentService,
        ReportService reportService,
        Store store,
        IServiceProvider serviceProvider
    )
    {
        _customerService = customerService;
        _appointmentService = appointmentService;
        _reportService = reportService;
        _store = store;
        _serviceProvider = serviceProvider;

        InitializeComponent();
    }

    private async void MainDashboard_Load(object sender, EventArgs e)
    {
        EnterYearLabel.Visible = false; 
        YearInput.Visible = false;
        GenerateReportBtn.Enabled = false;
        CalendarAppointmentDgv.Visible = false;
        ReportDgv.Visible = false;

        await PopulateCustomerTable();
        await PopulateAppointmentTable();
        await ShowUpcomingAppointments();
    }

    private async Task PopulateCustomerTable()
    {
        CustomerDgv.DataSource = await _customerService.CreateCustomerTableDto();

        CustomerDgv.Columns["Id"].Visible = false;

        CustomerDgv.Columns["CustomerName"].HeaderText = "Customer";
        CustomerDgv.Columns["AddressLine1"].HeaderText = "Address Line 1";
        CustomerDgv.Columns["AddressLine2"].HeaderText = "Address Line 2";
        CustomerDgv.Columns["CityName"].HeaderText = "City Name";
        CustomerDgv.Columns["PostalCode"].HeaderText = "Postal Code";
        CustomerDgv.Columns["CountryName"].HeaderText = "Country Name";
        CustomerDgv.Columns["Phone"].HeaderText = "Phone";

        CustomerDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        CustomerDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        foreach (DataGridViewColumn col in CustomerDgv.Columns)
        {
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
        }
    }

    private async Task PopulateAppointmentTable()
    {
        AppointmentDgv.DataSource = await _appointmentService.CreateAppointmentTableDto();

        AppointmentDgv.Columns["Id"].Visible = false;
        AppointmentDgv.Columns["CustomerName"].HeaderText = "Customer";
        AppointmentDgv.Columns["Username"].HeaderText = "User";

        AppointmentDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        AppointmentDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        foreach (DataGridViewColumn col in AppointmentDgv.Columns)
        {
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
        }
    }

    private async Task ShowUpcomingAppointments()
    {
        var allAppointments = await _appointmentService.GetAllAsync();

        var upcomingUserAppts = allAppointments
            .Where(a => a.UserId == _store.LoggedInUser.Id &&
                        a.Start >= DateTime.Now &&
                        a.Start <= DateTime.Now.AddMinutes(15))
            .Select(appt => $"{appt.Type} with {appt.Customer.CustomerName} at {appt.Start}")
            .ToList();


        if (upcomingUserAppts.Count != 0)
        {
            string message = "Your upcoming appointments:\n" +
                             string.Join("\n", upcomingUserAppts);

            Utilities.ShowMessage(message, "Upcoming Appointments");
        }
    }

    private async void SetActiveCustomer(object sender, DataGridViewCellEventArgs e)
    {
        int id = CustomerDgv.GetSelectedId(e, "Id");

        _store.ActiveCustomer = await _customerService.GetEntityByIdAsync(id);
    }

    private async void SetActiveAppointment(object sender, DataGridViewCellEventArgs e)
    {
        int id = AppointmentDgv.GetSelectedId(e, "Id");

        _store.ActiveAppointment = await _appointmentService.GetEntityByIdAsync(id);
    }

    private async void ShowCustomerForm(object sender, EventArgs e)
    {
        if (sender is Button clickedButton && clickedButton == UpdateCustomerBtn && _store.ActiveCustomer is null)
        {
            Utilities.ShowMessage("Please select a customer to update.", "No Selection");
            return;
        }

        Hide();

        var customerForm = _serviceProvider.GetRequiredService<CustomerForm>();
        customerForm.ShowDialog();

        await PopulateCustomerTable();
        Show();
    }

    private async void ShowAppointmentForm(object sender, EventArgs e)
    {
        if (sender is Button clickedButton && clickedButton == UpdateAppointmentBtn && _store.ActiveAppointment is null)
        {
            Utilities.ShowMessage("Please select an appointment to update.", "No Selection");
            return;
        }

        Hide();

        var appointmentForm = _serviceProvider.GetRequiredService<AppointmentForm>();
        appointmentForm.ShowDialog();

        await PopulateAppointmentTable();
        Show();
    }

    private async void DeleteCustomer(object sender, EventArgs e)
    {
        if (_store.ActiveCustomer is null)
        {
            Utilities.ShowMessage(
                "Please select a Customer to delete.",
                "No selection"
            );

            return;
        }

        DialogResult result = Utilities.ConfirmAction(
            $"Are you sure you want to delete {_store.ActiveCustomer.CustomerName}?",
            "Confirm Deletion"
        );

        if (result == DialogResult.Yes)
        {
            try
            {
                await _customerService.DeleteEntityAsync(_store.ActiveCustomer);
                await PopulateCustomerTable();
                await PopulateAppointmentTable();
            }
            catch (Exception)
            {
                Utilities.ShowMessage(
                    "An error occurred while trying to delete the customer. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private async void DeleteAppointment(object sender, EventArgs e)
    {
        if (_store.ActiveAppointment is null)
        {
            Utilities.ShowMessage(
                "Please select an appointment to delete.",
                "No selection"
            );

            return;
        }

        DialogResult result = Utilities.ConfirmAction(
            $"Are you sure you want to delete {_store.ActiveAppointment.Title}?",
            "Confirm Deletion"
        );

        if (result == DialogResult.Yes)
        {
            try
            {
                await _appointmentService.DeleteEntityAsync(_store.ActiveAppointment);
                await PopulateAppointmentTable(); 
            }
            catch (Exception)
            {
                Utilities.ShowMessage(
                    "An error occurred while trying to delete the appointment. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private async void SelectCalendarDate(object sender, DateRangeEventArgs e)
    {
        var selectedDate = e.Start;

        CalendarAppointmentDgv.DataSource = await _appointmentService.CreateCalendarAppointmentTableDto(selectedDate);

        CalendarAppointmentDgv.Columns["Id"].Visible = false;
        CalendarAppointmentDgv.Columns["CustomerName"].HeaderText = "Customer";
        CalendarAppointmentDgv.Columns["Username"].HeaderText = "Customer";

        CalendarAppointmentDgv.Visible = true;
        CalendarAppointmentDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        CalendarAppointmentDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        foreach (DataGridViewColumn col in CalendarAppointmentDgv.Columns)
        {
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
        }
    }

    private void SelectReportType(object sender, EventArgs e)
    {
        if (ReportsDropdown.SelectedIndex == 0)
        {
            GenerateReportBtn.Enabled = false;
            EnterYearLabel.Visible = true;
            YearInput.Visible = true;
        }
        else if (ReportsDropdown.SelectedIndex == 1 || ReportsDropdown.SelectedIndex == 2)
        {
            GenerateReportBtn.Enabled = true;
            YearInput.Text = null;
            EnterYearLabel.Visible = false;
            YearInput.Visible = false;
        }
    }

    private void YearInput_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(YearInput.Text.Trim()))
        {
            GenerateReportBtn.Enabled = true;
        }
        else if (string.IsNullOrEmpty(YearInput.Text.Trim()))
        {
            GenerateReportBtn.Enabled = false;
        }
    }

    private async void GenerateReport(object sender, EventArgs e)
    {
        switch (ReportsDropdown.SelectedIndex)
        {
            case 0:
                await GenerateAppointmentTypeReport();
                break;

            case 1:
                await GenerateUserSchedulesReport();
                break;

            case 2:
                await GenerateCustomerAppointmentSummaryReport();
                break;

            default:
                MessageBox.Show("Please select a valid report.");
                break;
        }

        ReportDgv.Visible = true;
    }

    private async Task GenerateAppointmentTypeReport()
    {
        int year = int.Parse(YearInput.Text);

        ReportDgv.DataSource = await _reportService.CreateAppointmentTypeReportDto(year);

        ReportDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        ReportDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        foreach (DataGridViewColumn col in ReportDgv.Columns)
        {
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
        }
    }

    private async Task GenerateUserSchedulesReport()
    {
        ReportDgv.DataSource = await _reportService.CreateUserScheduleReportDto();

        ReportDgv.Columns["CustomerName"].HeaderText = "Customer";
        ReportDgv.Columns["AppointmentTitle"].HeaderText = "Title";
        ReportDgv.Columns["Username"].HeaderText = "User";
        ReportDgv.Columns["AppointmentTitle"].HeaderText = "Title";
        ReportDgv.Columns["AppointmentType"].HeaderText = "Type";
        ReportDgv.Columns["StartTime"].HeaderText = "Start";
        ReportDgv.Columns["EndTime"].HeaderText = "End";

    }

    private async Task GenerateCustomerAppointmentSummaryReport()
    {
        ReportDgv.DataSource = await _reportService.CreateCustomerSummaryReportDto();

        ReportDgv.Columns["TotalAppointments"].HeaderText = "Total Appointments";
        ReportDgv.Columns["MostCommonAppointmentType"].HeaderText = "Most Common Type";
    }

    private void ExitApplication(object sender, EventArgs e)
    {
        DialogResult result = Utilities.ConfirmAction("Are you sure you want to exit the application?", "Exit Application");

        if (result == DialogResult.Yes)
        {
            Environment.Exit(0);
        }
    }
}

