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
    /// Interaction logic for UpsertBookingDetailWindow.xaml
    /// </summary>
    public partial class UpsertBookingDetailWindow : Window
    {
        private IBookingDetailService bookingDetailService;
        private IBookingService bookingService;
        private IRoomService roomService;
        private BookingDetail? bookingDetail;
        private Guid bookingId;
        private Func<Task> refreshListView;

        public UpsertBookingDetailWindow()
        {
            InitializeComponent();
        }

        public UpsertBookingDetailWindow(IBookingDetailService bookingDetailService, Guid bookingId, BookingDetail? bookingDetail, Func<Task> refreshListView)
        {
            InitializeComponent();
            this.bookingDetailService = bookingDetailService;
            this.bookingId = bookingId;
            this.bookingDetail = bookingDetail;
            roomService = new RoomService();
            this.bookingService = new BookingService();
            this.refreshListView = refreshListView;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookingDetail is null)
            {
                bookingDetail = FillBookingDetailWithForm();
                var result = await bookingDetailService.CreateBookingDetailAsync(bookingDetail);

                if (result is false)
                {
                    MessageBox.Show("Something went wrong!");
                    return;
                }

                if (result) await CaculateBookingTotalPrice();
                await refreshListView();
                this.Close();
            }
            else
            {
                bookingDetail = FillBookingDetailWithForm();
                var result = await bookingDetailService.UpdateBookingDetailAsync(bookingDetail);

                if (result is false)
                {
                    MessageBox.Show("Something went wrong!");
                    return;
                }

                if (result) await CaculateBookingTotalPrice();
                await refreshListView();
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadRoomComboBox();
            if (bookingDetail is null)
            {
                return;
            }
            FillFormWithBookingDetail();
        }

        private void FillFormWithBookingDetail()
        {
            BookingIdText.Text = bookingId.ToString();
            StartDatePicker.SelectedDate = bookingDetail.StartDate;
            EndDatePicker.SelectedDate = bookingDetail.EndDate;
            RoomComboBox.SelectedValue = bookingDetail.RoomId;
            ActualPriceText.Text = bookingDetail.ActualPrice.ToString();
        }

        private BookingDetail FillBookingDetailWithForm()
        {

            return new BookingDetail()
            {
                BookingReservationId = bookingId,
                ActualPrice = decimal.Parse(ActualPriceText.Text),
                StartDate = StartDatePicker.SelectedDate ?? DateTime.UtcNow,
                EndDate = StartDatePicker.SelectedDate ?? DateTime.UtcNow,
                RoomId = (Guid)RoomComboBox.SelectedValue,
            };
        }

        private async Task LoadRoomComboBox()
        {
            RoomComboBox.ItemsSource = await roomService.GetAllRoomAsync();
            RoomComboBox.DisplayMemberPath = "RoomNumber";
            RoomComboBox.SelectedValuePath = "RoomId";
            RoomComboBox.SelectedIndex = 0;
        }

        private async Task CaculateBookingTotalPrice()
        {
            var bookingDetails = await bookingDetailService.GetAllBookingDetailByBookingIdAsync(bookingId);
            var totalPrice = bookingDetails.Sum(x => x.ActualPrice);
            var booking = await bookingService.GetBookingByIdAsync(bookingId);
            booking.TotalPrice = totalPrice;
            await bookingService.UpdateBookingAsync(booking);
        }
    }
}