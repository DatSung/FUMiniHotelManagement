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
	/// Interaction logic for UpsertBookingWindow.xaml
	/// </summary>
	public partial class UpsertBookingWindow : Window
	{
		private Func<Task> refreshListView;
		private IBookingService bookingService;
		private BookingReservation? bookingReservation;
		private IUserService userService;

		public UpsertBookingWindow()
		{
			InitializeComponent();
		}

		public UpsertBookingWindow(Func<Task> refreshListView, IBookingService bookingService, BookingReservation? bookingReservation)
		{
			InitializeComponent();
			this.refreshListView = refreshListView;
			this.bookingService = bookingService;
			this.bookingReservation = bookingReservation;
			this.userService = new UserService();
		}

		private async void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			if (bookingReservation is null)
			{

				var bookingReservation = await FillBookingWithFormAsync();

				if (bookingReservation is null)
				{
					return;
				}

				var result = await bookingService.CreateBookingAsync(bookingReservation);

				if (result is false)
				{
					MessageBox.Show("Something went wrong!");
					return;
				}
				await refreshListView();
				this.Close();
			}

			if (bookingReservation is not null)
			{
				var bookingReservation = await FillBookingWithFormAsync();

				if (bookingReservation is null)
				{
					MessageBox.Show("Customer was not found!");
					return;
				}

				var result = await bookingService.UpdateBookingAsync(bookingReservation);
				if (result is false)
				{
					MessageBox.Show("Something went wrong!");
					return;
				}
				await refreshListView();
				this.Close();
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (bookingReservation is null)
			{
				return;
			}
            FillFormWithBooking();
        }

		private async Task<BookingReservation?> FillBookingWithFormAsync()
		{
			var selectedStatusItem = StatusComboBox.SelectedValue as ComboBoxItem;
			var selectedStatus = selectedStatusItem!.Content.ToString();

			var customer = await userService.GetUserByEmailAsync(CustomerEmailText.Text.Trim());

			if (customer == null)
			{
				MessageBox.Show("User was not found");
				return null;
			}

			var booking = new BookingReservation
			{
				BookingReservationId = bookingReservation is null ? Guid.NewGuid() : bookingReservation.BookingReservationId,
				BookingDate = BookingDatePicker.SelectedDate,
				BookingStatus = selectedStatus,
				CustomerId = customer!.UserId,
				TotalPrice = bookingReservation is null ? 0 : bookingReservation!.TotalPrice
			};

			return booking;
		}

		private void FillFormWithBooking()
		{
			BookingIdText.Text = bookingReservation!.BookingReservationId.ToString();
			BookingDatePicker.SelectedDate = bookingReservation.BookingDate;
			StatusComboBox.SelectedIndex = bookingReservation.BookingStatus == "Pending" ? 0 : 1;
			CustomerEmailText.Text = bookingReservation.Customer.EmailAddress;
			TotalPriceText.Text = bookingReservation!.TotalPrice.ToString();
		}

	}
}
