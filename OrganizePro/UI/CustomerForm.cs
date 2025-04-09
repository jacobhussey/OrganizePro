using OrganizePro.Shared;
using OrganizePro.Models;
using OrganizePro.Services;

namespace OrganizePro.UI;

public partial class CustomerForm : Form
{
    private readonly CustomerService _service;
    private readonly Repository _repo;
    private Customer Customer { get; set; }
    private List<TextBox> Inputs { get; set; }
    private bool IsValid = false;

    public CustomerForm(CustomerService service, Repository repo)
    {
        _service = service;
        _repo = repo;

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

        if (_repo.ActiveCustomer is not null)
        {
            Customer = _repo.ActiveCustomer;
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
        if (_repo.ActiveCustomer is null)
        {
            await AddCustomer();
        }
        else if (_repo.ActiveCustomer is not null)
        {
            await UpdateCustomer();
        }
    }

    private async Task AddCustomer()
    {
        Customer = new()
        {
            CreatedBy = _repo.LoggedInUser.Username
        };

        ValidateCustomer();

        if (IsValid)
        {
            MapCustomerProperties();
            await _service.CreateEntity(Customer);
            _repo.ActiveCustomer = null;
            Close();
        }
    }

    private async Task UpdateCustomer()
    {
        ValidateCustomer();

        if (IsValid)
        {
            MapCustomerProperties();
            await _service.UpdateEntity(Customer);
            _repo.ActiveCustomer = null;
            Close();
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
            Customer.LastUpdateBy = _repo.LoggedInUser.Username;
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
        _repo.ActiveCustomer = null;

        Close();
    }

}

