﻿using OrganizePro.Shared;
using OrganizePro.Models;
using OrganizePro.Services;
using System.Diagnostics;

namespace OrganizePro.UI;
public partial class AppointmentForm : Form
{
    private Appointment Appointment { get; set; }
    private List<Customer> Customers = [];
    private List<TextBox> Inputs { get; set; }
    private bool IsValid = false;
    private readonly AppointmentService _appointmentService;
    private readonly CustomerService _customerService;
    private readonly Store _store;

    public AppointmentForm(AppointmentService apptService, CustomerService custService, Store store)
    {
        _appointmentService = apptService;
        _customerService = custService;
        _store = store;

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

        if (_store.ActiveAppointment is not null)
        {
            Appointment = _store.ActiveAppointment;
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
        if (_store.ActiveAppointment is null)
        {
            await AddAppointment();
        }
        else if (_store.ActiveAppointment is not null)
        {
            await UpdateAppointment();
        }
    }

    private async Task AddAppointment()
    {
        Appointment = new()
        {
            CreatedBy = _store.LoggedInUser.Username
        };

        await ValidateAppointment();

        if (IsValid)
        {
            try
            {
                MapAppointmentProperties();
                await _appointmentService.CreateEntityAsync(Appointment);

                _store.ActiveAppointment = null;

                Close();
            }
            catch(Exception)
            {
                Utilities.ShowMessage(
                    "An error occurred while trying to save the appointment. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private async Task UpdateAppointment()
    {
        await ValidateAppointment();

        if (IsValid)
        {
            try
            {
                MapAppointmentProperties();
                await _appointmentService.UpdateEntityAsync(Appointment);

                _store.ActiveAppointment = null;

                Close();
            }
            catch (Exception)
            {
                Utilities.ShowMessage(
                    "An error occurred while trying to save the appointment. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private async Task ValidateAppointment()
    {
        IsValid =
            Utilities.CheckForNulls(Inputs)
            && await ValidateAppointmentOverlap()
            && ValidateAppointmentTime();
    }

    private async Task<bool> ValidateAppointmentOverlap()
    {
        var apptStart = StartInput.Value;
        var apptEnd = EndInput.Value;
        var allAppts = await _appointmentService.GetAllAsync();

        var existingUserAppts = allAppts
            .Where(a => a != _store.ActiveAppointment && a.UserId == _store.LoggedInUser.Id);

        var overlappingAppts = existingUserAppts
            .Where(e => e.Start < apptEnd && e.End > apptStart);

        if (overlappingAppts.Any())
        {
            Utilities.ShowMessage(
                $"User '{_store.LoggedInUser.Username}' already has an appointment scheduled during the selected time.", 
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

        TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        var startInEastern = TimeZoneInfo.ConvertTime(start, TimeZoneInfo.Local, easternTimeZone);
        var endInEastern = TimeZoneInfo.ConvertTime(end, TimeZoneInfo.Local, easternTimeZone);

        var nineAM = new DateTime(startInEastern.Year, startInEastern.Month, startInEastern.Day, 9, 0, 0, DateTimeKind.Unspecified);
        var fivePM = new DateTime(endInEastern.Year, endInEastern.Month, endInEastern.Day, 17, 0, 0, DateTimeKind.Unspecified);

        bool startIsValid =
            startInEastern >= nineAM &&
            startInEastern <= fivePM &&
            startInEastern.Day == endInEastern.Day;

        bool endIsValid =
            endInEastern >= nineAM &&
            endInEastern <= fivePM &&
            endInEastern.Day == startInEastern.Day;

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
            Appointment.Start = DateTime.SpecifyKind(StartInput.Value, DateTimeKind.Local).ToUniversalTime();
            Appointment.End = DateTime.SpecifyKind(EndInput.Value, DateTimeKind.Local).ToUniversalTime();
            Appointment.Location = LocationInput.Text;
            Appointment.Contact = ContactInput.Text;
            Appointment.LastUpdateBy = _store.LoggedInUser.Username;
            Appointment.User = _store.LoggedInUser;
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
        _store.ActiveAppointment = null;

        Close();
    }
}

