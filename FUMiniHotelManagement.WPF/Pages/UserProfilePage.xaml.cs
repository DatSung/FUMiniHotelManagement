using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.Service.Implements;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Path = System.IO.Path;

namespace FUMiniHotelManagement.WPF.Pages
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        private User admin { get; set; }
        private UserService userService { get; set; }

        private Action<string> UpdateAdminName { get; set; }
        private Action<string> UpdateAdminAvatar { get; set; }

        public UserProfilePage()
        {
            InitializeComponent();
        }

        public UserProfilePage(User admin, Action<string> updateAdminName, Action<string> updateAdminAvatar)
        {
            InitializeComponent();
            this.admin = admin;
            userService = new UserService();
            UpdateAdminName = updateAdminName;
            UpdateAdminAvatar = updateAdminAvatar;
        }

        private async Task LoadUserData()
        {
            // Giả sử bạn lấy dữ liệu từ cơ sở dữ liệu hoặc từ một nguồn khác
            var user = await userService.GetUserByIdAsync(admin.UserId);

            // Hiển thị thông tin người dùng lên form
            txtUserId.Text = user.UserId.ToString();
            txtFullName.Text = user.FullName;
            txtTelephone.Text = user.Telephone;
            txtEmailAddress.Text = user.EmailAddress;
            dpBirthday.SelectedDate = user.Birthday;
            txtStatus.Text = user.Status;
            txtRole.Text = user.Role;
            txtPassword.Password = user.Password;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadUserData();
            if (admin.AvatarUrl is not null)
            {
                UserAvatarImage.Source = new BitmapImage(new Uri(admin.AvatarUrl));
            }
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ các điều khiển
            var userId = Guid.Parse(txtUserId.Text);
            var fullName = txtFullName.Text;
            var telephone = txtTelephone.Text;
            var emailAddress = txtEmailAddress.Text;
            var birthday = dpBirthday.SelectedDate;
            var status = txtStatus.Text;
            var role = txtRole.Text;
            var password = txtPasswordVisible.Text; // Sử dụng PasswordBox để lấy mật khẩu

            // Tạo một đối tượng User mới với thông tin đã nhập
            User updatedUser = new User
            {
                UserId = userId,
                FullName = fullName,
                Telephone = telephone,
                EmailAddress = emailAddress,
                Birthday = birthday,
                Status = status,
                AvatarUrl = admin.AvatarUrl,
                Password = password,
                Role = role
            };

            await userService.UpdateUserAsync(updatedUser);

            // Thông báo cập nhật thành công
            MessageBox.Show("User information updated successfully!");

            await LoadUserData();

            UpdateAdminName.Invoke((updatedUser.FullName));
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Cập nhật TextBox với giá trị của PasswordBox
            txtPasswordVisible.Text = txtPassword.Password;
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            // Hiển thị TextBox và ẩn PasswordBox
            txtPasswordVisible.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Ẩn TextBox và hiển thị PasswordBox
            txtPassword.Visibility = Visibility.Visible;
            txtPasswordVisible.Visibility = Visibility.Collapsed;
        }

        private async void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    var url = SaveFile(filePath);
                    admin.AvatarUrl = url;

                    await userService.UpdateUserAsync(admin);
                    UserAvatarImage.Source = new BitmapImage(new Uri(url));
                    UpdateAdminAvatar(url);
                    MessageBox.Show("Update user avatar successfully!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
        }

        private string SaveFile(string filePath)
        {
            string dest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images",
                System.IO.Path.GetFileName(filePath));
            Directory.CreateDirectory(Path.GetDirectoryName(dest));
            File.Copy(filePath, dest, true);
            return dest;
        }
    }
}