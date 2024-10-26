using System.IO;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.Service.Implements;
using FUMiniHotelManagement.Service.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniHotelManagement.WPF.Pages
{
    /// <summary>
    /// Interaction logic for CustomerTablePage.xaml
    /// </summary>
    public partial class CustomerTablePage : Page
    {
        private IUserService userService;
        private User admin;
        private IJsonStream<User> _jsonStream;
        private IXmlStream<User> _xmlStream;

        public CustomerTablePage()
        {
            InitializeComponent();
            userService = new UserService();
        }

        public CustomerTablePage(User admin)
        {
            InitializeComponent();
            userService = new UserService();
            this.admin = admin;
            _jsonStream = new JsonStream<User>();
            _xmlStream = new XmlSteam<User>();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await RefreshListView();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            UpsertCustomerWindow createCustomerWindow = new UpsertCustomerWindow(userService, RefreshListView);
            createCustomerWindow.ShowDialog();
        }


        private async Task RefreshListView()
        {
            CustomerListView.ItemsSource = await userService.GetAllUserAsync();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerListView.SelectedItem != null)
            {
                var selectedUser = CustomerListView.SelectedItem as User;

                if (selectedUser is null)
                {
                    return;
                }

                if (selectedUser.UserId == admin.UserId)
                {
                    return;
                }

                UpsertCustomerWindow updateCustomerWindow =
                    new UpsertCustomerWindow(userService, RefreshListView, selectedUser);
                updateCustomerWindow.ShowDialog();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerListView.SelectedItem != null)
            {
                var selectedUser = CustomerListView.SelectedItem as User;

                if (selectedUser is null)
                {
                    return;
                }

                if (selectedUser.UserId == admin.UserId)
                {
                    return;
                }

                var result = await userService.DeleteUserAsync(selectedUser);

                if (result is true)
                {
                    await RefreshListView();
                }
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerListView.ItemsSource = await userService.SearchUserByNameAsync(SearchText.Text);
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một dialog thủ công với 3 nút
            var dialog = new Window()
            {
                Title = "Export Options",
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow
            };

            var stackPanel = new StackPanel
            {
                Margin = new Thickness(10)
            };

            var questionText = new TextBlock
            {
                Text = "Choose export format:",
                Margin = new Thickness(0, 0, 0, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            stackPanel.Children.Add(questionText);

            var btnJson = new Button
            {
                Content = "Export as JSON",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var btnXml = new Button
            {
                Content = "Export as XML",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var btnCancel = new Button
            {
                Content = "Cancel",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // Thêm các nút vào StackPanel
            stackPanel.Children.Add(btnJson);
            stackPanel.Children.Add(btnXml);
            stackPanel.Children.Add(btnCancel);

            // Set content của dialog
            dialog.Content = stackPanel;

            // Event handler cho các nút
            btnJson.Click += async (s, eArgs) =>
            {
                var data = await userService.GetAllUserAsync();
                var dest = Path.Combine(Directory.GetCurrentDirectory(), "UserExport", "User.json");
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                var jsonResult = _jsonStream.Export(data as List<User>, dest);
                dialog.DialogResult = true;
                dialog.Close();
            };

            btnXml.Click += async (s, eArgs) =>
            {
                var data = await userService.GetAllUserAsync();
                var dest = Path.Combine(Directory.GetCurrentDirectory(), "UserExport", "User.xml");
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                var jsonResult = _jsonStream.Export(data as List<User>, dest);
                dialog.DialogResult = true;
                dialog.Close();
            };

            btnCancel.Click += (s, eArgs) =>
            {
                dialog.DialogResult = false;
                dialog.Close();
            };

            // Hiển thị dialog
            dialog.ShowDialog();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một dialog thủ công với 3 nút
            var dialog = new Window()
            {
                Title = "Import Options",
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow
            };

            var stackPanel = new StackPanel
            {
                Margin = new Thickness(10)
            };

            var questionText = new TextBlock
            {
                Text = "Choose import format:",
                Margin = new Thickness(0, 0, 0, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            stackPanel.Children.Add(questionText);

            var btnJson = new Button
            {
                Content = "Import as JSON",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var btnXml = new Button
            {
                Content = "Import as XML",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var btnCancel = new Button
            {
                Content = "Cancel",
                Width = 100,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // Thêm các nút vào StackPanel
            stackPanel.Children.Add(btnJson);
            stackPanel.Children.Add(btnXml);
            stackPanel.Children.Add(btnCancel);

            // Set content của dialog
            dialog.Content = stackPanel;

            // Event handler cho các nút
            btnJson.Click += (s, eArgs) =>
            {
                var data = _jsonStream.Import( Path.Combine(Directory.GetCurrentDirectory(), "UserExport", "User.json"));
                CustomerListView.ItemsSource = data;
                dialog.DialogResult = true;
                dialog.Close();
            };

            btnXml.Click += (s, eArgs) =>
            {
                var data = _jsonStream.Import( Path.Combine(Directory.GetCurrentDirectory(), "UserExport", "User.xml"));
                CustomerListView.ItemsSource = data;
                dialog.DialogResult = true;
                dialog.Close();
            };

            btnCancel.Click += (s, eArgs) =>
            {
                dialog.DialogResult = false;
                dialog.Close();
            };

            // Hiển thị dialog
            dialog.ShowDialog();
        }
    }
}