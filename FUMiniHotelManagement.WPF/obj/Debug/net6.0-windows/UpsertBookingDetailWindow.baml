   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FUMiniHotelManagement.WPFFUMiniHotelManagement.WPF  5   	   9    3FUMiniHotelManagement.WPF.UpsertBookingDetailWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FUMiniHotelManagement.WPF     5   	   -   5          � Title$  Upsert Booking��5      $	��450��6'   $	��600��64   .��5	      � $��10,10,10,10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��234.24 �6   .+�5   
   �� $��Booking ID:��6   $��Center=�6'   $��10q�6B   �� 5   
   -   5         ��Name$ BookingIdText��5      $��0��6)   $��
150,5,10,5q�66   $	��400��6J   ${�False��6V    �� 
IsReadOnly$
 True��6h   �� 5   
   $��Actual Price:��6   $��4��6)   $��Center=�66   $��10q�6Q   �� 5   
   -   5        $ ActualPriceText��5      $��4��6+   $��
150,5,10,5q�68   $	��400��6L   �� 5   
   $��
StartDate:��6   $��2��6&   $��Center=�63   $��10q�6N   (  "System.Windows.Controls.DatePicker  5    
   -   5          Name$ StartDatePicker��5       $��2��6.   $��
150,5,10,5q�6;   $	��400��6O   �� 5#   
   $��EndDate:��6   $��3��6$   $��Center=�61   $��10q�6L     5$   
   -   5        $ EndDatePicker��5$      $��3��6,   $��
150,5,10,5q�69   $	��400��6M   �� 5(   
   $��Room:��6   $��1��6!   $��Center=�6.   $��10q�6I   �� 5)   
   -   5         ��Name$ RoomComboBox��5)   %    �� SelectedIndex$ 0��6   $��1��6;   $��
150,5,10,5q�6H   $	��400��6\   5*      �� 5.   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,0,23,0q�6W   $��52��6i   $	��Top=�6u   .+�5/      �� -   5        $��Submit��5/      $	��100��6&   $��5q�62   6=   �� 50      -   5        $��Cancel��50      $	��100��6&   $��5q�62   6=   51      52      53      