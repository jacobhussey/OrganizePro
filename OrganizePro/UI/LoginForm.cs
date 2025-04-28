using Microsoft.Extensions.DependencyInjection;
using OrganizePro.Shared;
using OrganizePro.Models;
using OrganizePro.Services;

namespace OrganizePro;
public partial class LoginForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly UserService _userService;
    private readonly Store _store;
    public LoginForm(
        IServiceProvider serviceProvider,
        UserService userService,
        Store store
    )
    {
        _serviceProvider = serviceProvider;
        _userService = userService;
        _store = store;

        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        var userCulture = System.Globalization.CultureInfo.CurrentUICulture;

        if (userCulture.TwoLetterISOLanguageName == "es") 
        {
            SetLabelsToSpanish();
        }
        else
        {
            SetLabelsToEnglish();
        }
    }

    private void SetLabelsToSpanish()
    {
        UsernameLabel.Text = "Nombre de usuario";
        PasswordLabel.Text = "Contraseña";
        LoginBtn.Text = "Iniciar sesión";

        CreateUsernameLabel.Text = "Nombre de usuario";
        CreatePasswordLabel.Text = "Contraseña";
        CreateUserBtn.Text = "Crear";

        LoginTabPage.Text = "Iniciar sesión";
        CreateUserTabPage.Text = "Crear nuevo usuario";
    }

    private void SetLabelsToEnglish()
    {
        UsernameLabel.Text = "Username";
        PasswordLabel.Text = "Password";
        LoginBtn.Text = "Login";

        CreateUsernameLabel.Text = "Username";
        CreatePasswordLabel.Text = "Password";
        CreateUserBtn.Text = "Create";

        LoginTabPage.Text = "Login";
        CreateUserTabPage.Text = "Create New User";
    }

    private async void Login(object sender, EventArgs e)
    {
        User user = new()
        {
            Username = LoginUsernameInput.Text,
            Password = LoginPasswordInput.Text
        };

        bool isValid = await ValidateLogin(user);

        if (isValid)
        {
            await ShowMainDashboard(user);
        }
    }

    private async Task<bool> ValidateLogin(User user)
    {
        bool isValid = await _userService.ValidateLogin(user);

        if (!isValid)
        {
            Utilities.ShowMessage("Invalid username and password. Please try again.", "Invalid Credentials");
        }

        return isValid;
    }

    private async void CreateUser(object sender, EventArgs e)
    {
        User user = new()
        {
            Username = CreateUsernameInput.Text,
            Password = CreatePasswordInput.Text,
            CreatedBy = CreateUsernameInput.Text
        };

        bool isValid = await _userService.ValidateCreate(user);

        if (!isValid)
        {
            Utilities.ShowMessage(
                "Sorry, that username is already taken. Please choose another.",
                "Username Taken"
            );

            return;
        }

        await _userService.CreateEntity(user);
        await ShowMainDashboard(user);
    }

    private async Task ShowMainDashboard(User user)
    {
        await SetLoggedInUser(user);

        WriteUserLog(user);

        Hide();

        var mainDashboard = _serviceProvider.GetRequiredService<MainDashboard>();
        mainDashboard.Show();
    }

    private async Task SetLoggedInUser(User user)
    {
        var users = await _userService.GetAllAsync();

        user = users
            .Where(u => u.Username == user.Username && u.Password == user.Password)
            .FirstOrDefault();

        _store.LoggedInUser = user;
    }

    private static void WriteUserLog(User user)
    {
        UserLog log = new()
        {
            Username = user.Username,
            Date = DateTime.Now
        };

        Logger.WriteLog(log);
    }
}

