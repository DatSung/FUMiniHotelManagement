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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FUMiniHotelManagement.WPF.Pages
{
	/// <summary>
	/// Interaction logic for BookingTablePage.xaml
	/// </summary>
	public partial class BookingTablePage : Page
	{
		private IBookingService bookingService;
        private AdminDashboardWindow adminDashboardWindow;

        public BookingTablePage()
		{
			InitializeComponent();
			bookingService = new BookingService();
		}

        public BookingTablePage(AdminDashboardWindow adminDashboardWindow)
        {
            InitializeComponent();
            bookingService = new BookingService();
			this.adminDashboardWindow = adminDashboardWindow;
        }


        private async void OnLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshListView();
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			UpsertBookingWindow upsertBookingWindow = new UpsertBookingWindow(RefreshListView, bookingService, null);
			upsertBookingWindow.ShowDialog();
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{

			if (BookingListView.SelectedItem != null)
			{
				var selectedBooking = BookingListView.SelectedItem as BookingReservation;

				if (selectedBooking is null)
				{
					return;
				}

				UpsertBookingWindow upsertBookingWindow = new UpsertBookingWindow(RefreshListView, bookingService, selectedBooking);
				upsertBookingWindow.ShowDialog();
			}

		}

		private async void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (BookingListView.SelectedItem != null)
			{
				var selectedBooking = BookingListView.SelectedItem as BookingReservation;

				if (selectedBooking is null)
				{
					return;
				}

				var result = await bookingService.DeleteBookingAsync(selectedBooking);

				if (result is true)
				{
					await RefreshListView();
				}
			}
		}

		private void DetailButton_Click(object sender, RoutedEventArgs e)
		{
			
            if (BookingListView.SelectedItem != null)
            {
                var selectedBooking = BookingListView.SelectedItem as BookingReservation;

                if (selectedBooking is null)
                {
                    return;
                }

                adminDashboardWindow.FoundationFrame.Content = new BookingDetailTablePage(selectedBooking.BookingReservationId);
            }
        }

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private async Task RefreshListView()
		{
			BookingListView.ItemsSource = await bookingService.GetAllBookingAsync();
		}
	}
}
