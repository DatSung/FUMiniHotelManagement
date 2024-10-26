using FUMiniHotelManagement.Service.Implements;
using FUMiniHotelManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FUMiniHotelManagement.WPF
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		private IUserService userService;

		public LoginWindow()
		{
			InitializeComponent();
			userService = new UserService();
		}

		private async void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			LoginButton.IsEnabled = false;
			var email = EmailText.Text.Trim();
			var password = PasswordText.Password.Trim();

			var user = await userService.CheckLoginAsync(email, password);

			if (user is null)
			{
				MessageBox.Show("Email or password incorrect!");
                LoginButton.IsEnabled = true;
                return;
			}

			if (user.Role!.Trim().ToLower() == "admin")
			{
				AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow(user);
				adminDashboardWindow.Show();
				this.Hide();
			}

			if (user.Role.Trim().ToLower() == "customer")
			{
				MessageBox.Show("Customer login");
			}
            LoginButton.IsEnabled = true;
        }

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{

		}
		
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
