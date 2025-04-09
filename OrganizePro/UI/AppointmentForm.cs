using OrganizePro.Shared;
using OrganizePro.Models;
using OrganizePro.Services;

namespace OrganizePro.UI;
public partial class AppointmentForm : Form
{
    private Appointment Appointment { get; set; }
    private List<Customer> Customers = [];
    private List<TextBox> Inputs { get; set; }
    private bool IsValid = false;
    private readonly AppointmentService _appointmentService;
    private readonly CustomerService _customerService;
    private readonly Repository _repo;

    public AppointmentForm(AppointmentService apptService, CustomerService custService, Repository repo)
    {
        _appointmentService = apptService;
        _customerService = custService;
        _repo = repo;

        InitializeComponent();

        Inputs =
        [
            TitleInput,
            TypeInput,
            LocationInput,
            ContactInput,
            DescriptionInput,
            UrlInput
        ];

        if (_repo.ActiveAppointment is not null)
        {
            Appointment = _repo.ActiveAppointment;
            PopulateFields();
        }
    }

    private async void AppointmentForm_Load(object sender, EventArgs e)
    {
        await PopulateCustomersDropdown();
    }

    private async Task PopulateCustomersDropdown()
    {
        Customers = await _customerService.GetAllAsync();

        CustomerDropdown.DataSource = Customers;
        CustomerDropdown.DisplayMember = "CustomerName";
        CustomerDropdown.ValueMember = "Id";
    }

    private void PopulateFields()
    {
        if (Appointment is not null)
        {
            TitleInput.Text = Appointment.Title;
            TypeInput.Text = Appointment.Type;
            StartInput.Value = Appointment.Start;
            EndInput.Value = Appointment.End;
            LocationInput.Text = Appointment.Location;
            ContactInput.Text = Appointment.Contact;
            DescriptionInput.Text = Appointment.Description;
            UrlInput.Text = Appointment.Url;
        }
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        if (_repo.ActiveAppointment is null)
        {
            await AddAppointment();
        }
        else if (_repo.ActiveAppointment is not null)
        {
            await UpdateAppointment();
        }
    }

    private async Task AddAppointment()
    {
        Appointment = new()
        {
            CreatedBy = _repo.LoggedInUser.Username
        };

        await ValidateAppointment();

        if (IsValid)
        {
            MapAppointmentProperties();
            await _appointmentService.CreateEntity(Appointment);

            _repo.ActiveAppointment = null;

            Close();
        }
    }

    private async Task UpdateAppointment()
    {
        await ValidateAppointment();

        if (IsValid)
        {
            MapAppointmentProperties();
            await _appointmentService.UpdateEntity(Appointment);

            _repo.ActiveAppointment = null;

            Close();
        }
    }

    private async Task ValidateAppointment()
    {
        Utilities.CheckForNulls(Inputs, ref IsValid);

        IsValid =
            await ValidateAppointmentOverlap()
            && ValidateAppointmentTime();
    }

    private async Task<bool> ValidateAppointmentOverlap()
    {
        var apptStart = StartInput.Value;
        var apptEnd = EndInput.Value;
        var allAppts = await _appointmentService.GetAllAsync();

        var existingUserAppts = allAppts
            .Where(a => a.UserId == _repo.LoggedInUser.Id);

        var overlappingAppts = existingUserAppts
            .Where(e => e.Start < apptEnd && e.End > apptStart);

        if (overlappingAppts.Any())
        {
            Utilities.ShowMessage(
                $"User '{_repo.LoggedInUser.Username}' already has an appointment scheduled during the selected time.", 
                "Invalid Input"
            );
            return false;
        }

        return true;
    }

    private bool ValidateAppointmentTime()
    {
        var start = StartInput.Value;
        var end = EndInput.Value;

        var nineAM = new DateTime(start.Year, start.Month, start.Day, 9, 0, 0);
        var fivePM = new DateTime(end.Year, end.Month, end.Day, 17, 0, 0);

        bool startIsValid =
            start >= nineAM &&
            start <= fivePM &&
            start.Day == end.Day;

        bool endIsValid =
            end >= nineAM &&
            end <= fivePM &&
            end.Day == start.Day;

        if (start < DateTime.Now)
        {
            Utilities.ShowMessage("Appointments cannot be scheduled in the past.", "Invalid Input");
            return false;
        }

        if (start > end)
        {
            Utilities.ShowMessage("Start time must be before end time.", "Invalid Input");
            return false;
        }

        if (!startIsValid || !endIsValid)
        {
            Utilities.ShowMessage("Appointments must be scheduled during business hours: 9 AM - 5 PM EST", "Invalid Input");
            return false;
        }

        return true;
    }

    private void MapAppointmentProperties()
    {
        TrimFields();

        if (Appointment is not null)
        {
            Appointment.Title = TitleInput.Text;
            Appointment.Type = TypeInput.Text;
            Appointment.Start = StartInput.Value;
            Appointment.End = EndInput.Value;
            Appointment.Location = LocationInput.Text;
            Appointment.Contact = ContactInput.Text;
            Appointment.LastUpdateBy = _repo.LoggedInUser.Username;
            Appointment.User = _repo.LoggedInUser;
            Appointment.Customer = CustomerDropdown.SelectedItem as Customer;
            Appointment.Description = DescriptionInput.Text;
            Appointment.Url = UrlInput.Text;
        }
    }

    private void TrimFields()
    {
        Inputs = Utilities.TrimFields(Inputs);
    }

    private void Cancel(object sender, EventArgs e)
    {
        _repo.ActiveAppointment = null;

        Close();
    }
}

