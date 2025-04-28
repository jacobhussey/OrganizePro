using OrganizePro.Shared;
using OrganizePro.Models;
using OrganizePro.Services;
using System.Diagnostics;

namespace OrganizePro.UI;

public partial class CustomerForm : Form
{
    private readonly CustomerService _service;
    private readonly Store _store;
    private Customer Customer { get; set; }
    private List<TextBox> Inputs { get; set; }
    private bool IsValid = false;

    public CustomerForm(CustomerService service, Store store)
    {
        _service = service;
        _store = store;

        InitializeComponent();

        Inputs =
        [
            NameInput,
            AddressInput,
            PostalCodeInput,
            PhoneInput,
            CityInput,
            CountryInput
        ];

        if (_store.ActiveCustomer is not null)
        {
            Customer = _store.ActiveCustomer;
            PopulateFields();
        }
    }

    private void PopulateFields()
    {
        if (Customer is not null)
        {
            NameInput.Text = Customer.CustomerName;
            AddressInput.Text = Customer.Address.AddressLine1;
            Address2Input.Text = Customer.Address.AddressLine2;
            PostalCodeInput.Text = Customer.Address.PostalCode;
            PhoneInput.Text = Customer.Address.Phone;
            CityInput.Text = Customer.Address.City.CityName;
            CountryInput.Text = Customer.Address.City.Country.CountryName;
        }
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        if (_store.ActiveCustomer is null)
        {
            await AddCustomer();
        }
        else if (_store.ActiveCustomer is not null)
        {
            await UpdateCustomer();
        }
    }

    private async Task AddCustomer()
    {
        Customer = new()
        {
            CreatedBy = _store.LoggedInUser.Username
        };

        ValidateCustomer();

        if (IsValid)
        {
            try
            {
                MapCustomerProperties();
                await _service.CreateEntity(Customer);

                _store.ActiveCustomer = null;

                Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error in {nameof(AddCustomer)}: {e.Message}");

                Utilities.ShowMessage(
                    "An error occurred while trying to save the customer. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private async Task UpdateCustomer()
    {
        ValidateCustomer();

        if (IsValid)
        {
            try
            {
                MapCustomerProperties();
                await _service.UpdateEntity(Customer);

                _store.ActiveCustomer = null;

                Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error in {nameof(UpdateCustomer)}: {e.Message}");

                Utilities.ShowMessage(
                    "An error occurred while trying to save the customer. Please try again later.",
                    "Error"
                );
            }
        }
    }

    private void ValidateCustomer()
    {
        Utilities.CheckForNulls(Inputs, ref IsValid);
    }

    private void MapCustomerProperties()
    {
        TrimFields();

        if (Customer is not null)
        {
            Customer.CustomerName = NameInput.Text;
            Customer.Address.AddressLine1 = AddressInput.Text;
            Customer.Address.AddressLine2 = Address2Input.Text;
            Customer.Address.PostalCode = PostalCodeInput.Text;
            Customer.Address.Phone = PhoneInput.Text;
            Customer.Address.City.CityName = CityInput.Text;
            Customer.Address.City.Country.CountryName = CountryInput.Text;
            Customer.IsActive = true;
            Customer.LastUpdateBy = _store.LoggedInUser.Username;
        }
    }

    private void TrimFields()
    {
        Inputs = Utilities.TrimFields(Inputs);
    }

    private void FormatPhoneInput(object sender, KeyPressEventArgs e)
    {
        Utilities.FormatPhoneInput(e);
    }

    private void CancelClick(object sender, EventArgs e)
    {
        _store.ActiveCustomer = null;

        Close();
    }

}

