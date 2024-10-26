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
    /// Interaction logic for BookingDetailTablePage.xaml
    /// </summary>
    public partial class BookingDetailTablePage : Page
    {
        private Guid bookingId;
        private IBookingDetailService bookingDetailService;
        public BookingDetailTablePage()
        {
            InitializeComponent();
        }

        public BookingDetailTablePage(Guid bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;
            this.bookingDetailService = new BookingDetailService();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            UpsertBookingDetailWindow upsertBookingDetailWindow = new UpsertBookingDetailWindow(bookingDetailService, bookingId, null, RefreshListView);
            upsertBookingDetailWindow.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookingDetailListView.SelectedItem != null)
            {
                var selectedBookingDetail = BookingDetailListView.SelectedItem as BookingDetail;

                if (selectedBookingDetail is null)
                {
                    return;
                }
                UpsertBookingDetailWindow upsertBookingDetailWindow = new UpsertBookingDetailWindow(bookingDetailService, bookingId, selectedBookingDetail, RefreshListView);
                upsertBookingDetailWindow.ShowDialog();

            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookingDetailListView.SelectedItem != null)
            {
                var selectedBookingDetail = BookingDetailListView.SelectedItem as BookingDetail;

                if (selectedBookingDetail is null)
                {
                    return;
                }

                await bookingDetailService.DeleteBookingDetailAsync(selectedBookingDetail);
                await RefreshListView();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await RefreshListView();
        }

        private async Task RefreshListView()
        {
            BookingDetailListView.ItemsSource = await bookingDetailService.GetAllBookingDetailByBookingIdAsync(bookingId);
        }
    }
}
