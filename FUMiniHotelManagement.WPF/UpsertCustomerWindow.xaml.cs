using FUMiniHotelManagement.BusinessObject.Entities;
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
    /// Interaction logic for UpsertCustomerWindow.xaml
    /// </summary>
    public partial class UpsertCustomerWindow : Window
    {
        private IUserService userService;
        private Func<Task> refreshListView;
        private User? user;

        public UpsertCustomerWindow()
        {
            InitializeComponent();
        }

        public UpsertCustomerWindow(IUserService userService, Func<Task> refreshListView, User? user)
        {
            InitializeComponent();
            this.userService = userService;
            this.refreshListView = refreshListView;
            this.user = user;
        }

        public UpsertCustomerWindow(IUserService userService, Func<Task> refreshListView)
        {
            InitializeComponent();
            this.userService = userService;
            this.refreshListView = refreshListView;
            user = null;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (user is null)
                {
                    var user = FillUserWithForm();

                    var result = await userService.CreateUserAsync(user);

                    if (result is false)
                    {
                        MessageBox.Show("Something went wrong!");
                        return;
                    }

                    await refreshListView();
                    this.Close();
                }

                if (user is not null)
                {
                    var user = FillUserWithForm();
                    var result = await userService.UpdateUserAsync(user);
                    if (result is false)
                    {
                        MessageBox.Show("Something went wrong!");
                        return;
                    }

                    await refreshListView();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillFormWithUser(User user)
        {
            UserIdText.Text = user.UserId.ToString();
            BirthdayDatePicker.SelectedDate = user.Birthday;
            EmailAddressText.Text = user.EmailAddress;
            FullNameText.Text = user.FullName;
            PasswordText.Password = user.Password;
            RoleComboBox.SelectedIndex = user.Role!.ToLower().Trim() == "admin" ? 0 : 1;
            StatusComboBox.SelectedIndex = user.Status!.ToLower().Trim() == "activated" ? 0 : 1;
            TelephoneText.Text = user.Telephone;
        }

        private User FillUserWithForm()
        {
            var selectedRoleItem = (ComboBoxItem)RoleComboBox.SelectedItem;
            string selectedRole = selectedRoleItem.Content.ToString()!;

            var selectedStatusItem = (ComboBoxItem)StatusComboBox.SelectedItem;
            string selectedStatus = selectedStatusItem.Content.ToString()!;

            return new User()
            {
                UserId = user is null ? Guid.NewGuid() : user.UserId,
                Birthday = BirthdayDatePicker.SelectedDate,
                EmailAddress = EmailAddressText.Text,
                FullName = FullNameText.Text,
                Password = PasswordText.Password,
                Role = selectedRole,
                Status = selectedStatus,
                Telephone = TelephoneText.Text
            };
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (user is not null)
            {
                this.Title = "Update user";
                PasswordText.IsEnabled = false;
                EmailAddressText.IsEnabled = false;
                FillFormWithUser(user);
            }

            this.Title = "Create user";
        }
    }
}