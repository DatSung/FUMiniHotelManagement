   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FUMiniHotelManagement.WPFFUMiniHotelManagement.WPF  5   	   0    *FUMiniHotelManagement.WPF.UpsertRoomWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FUMiniHotelManagement.WPF     5   	   -   5          � Title$  Upsert Room��5   	   $	��450��6   $	��600��6*    � 
ResizeMode$ NoResize=�5	   	    � SizeToContent$ Manual=�6   .��5      � $��10,10,10,10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Room ID:��6   $��Center=�6$   $��10q�6?   �� 5   
   -   5         ��Name$ 
RoomIdText��5      $��0��6&   $��
150,5,10,5q�63   $	��400��6G   ${�False��6S    �� 
IsReadOnly$
 True��6e   �� 5   
   $��Room Number:��6   $��1��6(   $��Center=�65   $��10q�6P   �� 5   
   -   5        $ RoomNumberText��5      $��1��6*   $��
150,5,10,5q�67   $	��400��6K   �� 5    
   $��Description:��6   $��2��6(   $��Center=�65   $��10q�6P   �� 5!   
   -   5        $ DescriptionText��5!      $��2��6+   $��
150,5,10,5q�68   $	��400��6L   �� 5$   
   $��Max Capacity:��6   $��3��6)   $��Center=�66   $��10q�6Q   �� 5%   
   -   5        $ MaxCapacityText��5%      $��3��6+   $��
150,5,10,5q�68   $	��400��6L   �� 5(   
   $��
Price/Day:��6   $��4��6&   $��Center=�63   $��10q�6N   �� 5)   
   -   5        $ PricePerDayText��5)      $��4��6+   $��
150,5,10,5q�68   $	��400��6L   �� 5-   
   $��Room Status:��6   $��5��6(   $��Center=�65   $��10q�6P   �� 5.   
   -   5         ��Name$ StatusComboBox��5.   %    �� SelectedIndex$ 0��6   $��5��6=   $��
150,5,10,5q�6J   $	��400��6^   .@�5/      �� $��	Activated��6   �� 50      $��Deactivated��6   51      �� 54   
   $��
Room Type:��6   $��6��6&   $��Center=�63   $��10q�6N   �� 55   
   -   5        $ TypeComboBox��55   %   $ 1��6   $��6��6;   $��
150,5,10,5q�6H   $	��400��6\   56      �� 59   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,0,23,0q�6W   $��52��6i   $	��Top=�6u   .+�5:      �� -	   5        $��Submit��5:      $	��100��6&   $��5q�62   6=   �� 5;      -
   5        $��Cancel��5;      $	��100��6&   $��5q�62   6=   5<      5=      5>      