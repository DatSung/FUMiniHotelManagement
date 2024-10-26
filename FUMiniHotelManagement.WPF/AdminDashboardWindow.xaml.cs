using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.WPF.Pages;
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
	/// Interaction logic for adminDashboardWindow.xaml
	/// </summary>
	public partial class AdminDashboardWindow : Window
	{
		private User admin;

		public AdminDashboardWindow(User admin)
		{
			InitializeComponent();
			SideBarFrame.Content = new SideBarPage(this, admin);
			FoundationFrame.Content = new CustomerTablePage(admin);
			this.admin = admin;
		}
    }
}
