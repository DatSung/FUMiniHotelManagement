using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.Service.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniHotelManagement.WPF
{
	/// <summary>
	/// Interaction logic for UpsertRoomWindow.xaml
	/// </summary>
	public partial class UpsertRoomWindow : Window
	{
		private IRoomService roomService;
		private IRoomTypeService roomTypeService;
		private RoomInformation? roomInformation;
		Func<Task> refreshListView;

		public UpsertRoomWindow()
		{
			InitializeComponent();
		}

		public UpsertRoomWindow(IRoomService roomService, IRoomTypeService roomTypeService, RoomInformation? roomInformation, Func<Task> refreshListView)
		{
			InitializeComponent();
			this.roomService = roomService;
			this.roomTypeService = roomTypeService;
			this.roomInformation = roomInformation;
			this.refreshListView = refreshListView;
		}

		private async void OnLoaded(object sender, RoutedEventArgs e)
		{
			await HandleLoadTypeComboBox();
			if (roomInformation is not null)
			{
				FillFormWithRoom();
				this.Title = "Update Room";
			}
			this.Title = "Create Room";
		}

		private async void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			if (roomInformation is null)
			{
				var room = FillRoomWithForm();
				var result = await roomService.CreateRoomAsync(room);
				if (result is false)
				{
					MessageBox.Show("Something went wrong!");
					return;
				}
				await refreshListView();
				this.Close();
			}
			else
			{
				var room = FillRoomWithForm();
				var result = await roomService.UpdateRoomAsync(room);
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

		private async Task HandleLoadTypeComboBox()
		{
			TypeComboBox.ItemsSource = await roomTypeService.GetAllRoomTypeAsync();
			TypeComboBox.SelectedValuePath = "RoomTypeId";
			TypeComboBox.DisplayMemberPath = "RoomTypeName";
			TypeComboBox.SelectedIndex = 0;
		}

		private RoomInformation FillRoomWithForm()
		{
			var selectedStatusItem = (ComboBoxItem)StatusComboBox.SelectedItem;
			string selectedStatus = selectedStatusItem.Content.ToString()!;

			return new RoomInformation()
			{
				RoomId = roomInformation is null ? Guid.NewGuid() : roomInformation.RoomId,
				RoomDetailDescription = DescriptionText.Text,
				RoomMaxCapacity = int.Parse(MaxCapacityText.Text),
				RoomNumber = RoomNumberText.Text,
				RoomStatus = selectedStatus,
				RoomTypeId = Guid.Parse(TypeComboBox.SelectedValue.ToString()!),
				RoomPricePerDay = decimal.Parse(PricePerDayText.Text)
			};
		}

		private void FillFormWithRoom()
		{
			RoomIdText.Text = roomInformation!.RoomId.ToString();
			RoomNumberText.Text = roomInformation!.RoomNumber.ToString();
			DescriptionText.Text = roomInformation!.RoomDetailDescription;
			MaxCapacityText.Text = roomInformation!.RoomMaxCapacity.ToString();
			StatusComboBox.SelectedIndex = roomInformation.RoomStatus!.ToLower().Trim() == "activated" ? 0 : 1;
			TypeComboBox.SelectedItem = roomInformation.RoomType;
			PricePerDayText.Text = roomInformation.RoomPricePerDay.ToString();
		}
	}
}
