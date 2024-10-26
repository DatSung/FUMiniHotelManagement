using FUMiniHotelManagement.BusinessObject.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FUMiniHotelManagement.WPF.Pages
{
    /// <summary>
    /// Interaction logic for SideBarPage.xaml
    /// </summary>
    public partial class SideBarPage : Page
    {
        private AdminDashboardWindow adminDashboardWindow;
        private User admin;

        public SideBarPage(AdminDashboardWindow adminDashboardWindow, User admin)
        {
            InitializeComponent();
            this.adminDashboardWindow = adminDashboardWindow;
            this.admin = admin;
            FullNameLabel.Text = admin.FullName;
            if (admin.AvatarUrl is not null)
            {
                UserAvatar.Source = new BitmapImage(new Uri(this.admin.AvatarUrl!));
            }
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            adminDashboardWindow.FoundationFrame.Content = new CustomerTablePage(admin);
        }

        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            adminDashboardWindow.FoundationFrame.Content = new RoomTablePage();
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            adminDashboardWindow.FoundationFrame.Content = new BookingTablePage(adminDashboardWindow);
        }

        private void UserProfileButton_Click(object sender, RoutedEventArgs e)
        {
            adminDashboardWindow.FoundationFrame.Content = new UserProfilePage(admin, UpdateAdminName, UpdateAdminAvatar);
        }

        private void UpdateAdminName(string name)
        {
            FullNameLabel.Text = name;
        }
        
        private void UpdateAdminAvatar(string path)
        {
            UserAvatar.Source = new BitmapImage(new Uri(path));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            adminDashboardWindow.Close();
        }
    }
}