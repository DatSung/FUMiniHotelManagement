   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FUMiniHotelManagement.WPFFUMiniHotelManagement.WPF  5   	   3    -FUMiniHotelManagement.WPF.UpsertBookingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FUMiniHotelManagement.WPF     5   	   -   5          � Title$  Upsert Booking��5   	   $	��450��6    $	��600��6-   .��5	      � $��10,10,10,10q�6    � RowDefinitions 5
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
   $��Total Price:��6   $��1��6(   $��Center=�65   $��10q�6P   �� 5   
   -   5        $ TotalPriceText��5   6   $
 True��6   ${�False��6$   $��1��6N   $��
150,5,10,5q�6[   $	��400��6o   �� 5   
   $��BookingDate:��6   $��2��6(   $��Center=�65   $��10q�6P   (  "System.Windows.Controls.DatePicker  5    
   -   5          Name$ BookingDatePicker��5       $��2��60   $��
150,5,10,5q�6=   $	��400��6Q   �� 5#   
   $��Status:��6   $��4��6#   $��Center=�60   $��10q�6K   �� 5$   
   -   5         ��Name$ StatusComboBox��5$   %    �� SelectedIndex$ 0��6   $��4��6=   $��
150,5,10,5q�6J   $	��400��6^   .@�5%      �� $��Pending��6   �� 5&      $��	Purchased��6   5'      �� 5*   
   $��	Customer:��6   $��3��6%   $��Center=�62   $��10q�6M   �� 5+   
   -   5        $ CustomerEmailText��5+      $��3��6-   $��
150,5,10,5q�6:   $	��400��6N   �� 5/   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,0,23,0q�6W   $��52��6i   $	��Top=�6u   .+�50      �� -   5        $��Submit��50      $	��100��6&   $��5q�62   6=   �� 51      -   5        $��Cancel��51      $	��100��6&   $��5q�62   6=   52      53      54      