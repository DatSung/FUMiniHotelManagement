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
	/// Interaction logic for RoomTablePage.xaml
	/// </summary>
	public partial class RoomTablePage : Page
	{
		private IRoomService roomService;
		private IRoomTypeService roomTypeService;

		public RoomTablePage()
		{
			InitializeComponent();
			roomService = new RoomService();
			roomTypeService = new RoomTypeService();
		}

		private async void OnLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshListView();
		}

		private async Task RefreshListView()
		{
			RoomListView.ItemsSource = await roomService.GetAllRoomAsync();
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			UpsertRoomWindow upsertRoomWindow = new UpsertRoomWindow(roomService, roomTypeService, null, RefreshListView);
			upsertRoomWindow.ShowDialog();
		}

		private async void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (RoomListView.SelectedItem != null)
			{
				var selectedRoom = RoomListView.SelectedItem as RoomInformation;
				if (selectedRoom != null)
				{
					var result = await roomService.DeleteRoomAsync(selectedRoom);
					await RefreshListView();
				}
			}
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			if (RoomListView.SelectedItem != null)
			{
				var selectedRoom = RoomListView.SelectedItem as RoomInformation;
				if (selectedRoom != null)
				{
					UpsertRoomWindow upsertRoomWindow = new UpsertRoomWindow(roomService, roomTypeService, selectedRoom, RefreshListView);
					upsertRoomWindow.ShowDialog();
				}
			}
		}

		private async void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			RoomListView.ItemsSource = await roomService.SearchRoomByRoomNumberAsync(SearchText.Text);
		}

	}
}
