   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FUMiniHotelManagement.WPFFUMiniHotelManagement.WPF  5   	   4    .FUMiniHotelManagement.WPF.UpsertCustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FUMiniHotelManagement.WPF     5   	   -   5          � Title$  Upsert Customer��5   	   $	��450��6!   $	��600��6.    � 
ResizeMode$ NoResize=�5	   	    � SizeToContent$ Manual=�6   .��5
      � $��10,10,10,10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��User ID:��6   $��Center=�6$   $��10q�6?   �� 5   
   -   5         ��Name$ 
UserIdText��5      $��0��6&   $��
150,5,10,5q�63   $	��400��6G   ${�False��6S    �� 
IsReadOnly$
 True��6e   �� 5   
   $��
Full Name:��6   $��1��6&   $��Center=�63   $��10q�6N   �� 5   
   -   5        $ FullNameText��5      $��1��6(   $��
150,5,10,5q�65   $	��400��6I   �� 5    
   $��
Telephone:��6   $��2��6&   $��Center=�63   $��10q�6N   �� 5!   
   -   5        $ TelephoneText��5!      $��2��6)   $��
150,5,10,5q�66   $	��400��6J   �� 5$   
   $��Email Address:��6   $��3��6*   $��Center=�67   $��10q�6R   �� 5%   
   -   5        $ EmailAddressText��5%      $��3��6,   $��
150,5,10,5q�69   $	��400��6M   �� 5(   
   $��	Birthday:��6   $��4��6%   $��Center=�62   $��10q�6M   (  "System.Windows.Controls.DatePicker  5)   
   -   5          Name$ BirthdayDatePicker��5)      $��4��61   $��
150,5,10,5q�6>   $	��400��6R   �� 5,   
   $��Status:��6   $��5��6#   $��Center=�60   $��10q�6K   �� 5-   
   -   5         ��Name$ StatusComboBox��5-   %    �� SelectedIndex$ 0��6   $��5��6=   $��
150,5,10,5q�6J   $	��400��6^   .@�5.      �� $��	Activated��6   �� 5/      $��Deactivated��6   50      �� 53   
   $��	Password:��6   $��6��6%   $��Center=�62   $��10q�6M   G� 54   
   -   5        	 G�Name$	 PasswordText��54      $��6��6,   $��
150,5,10,5q�69   $	��400��6M   �� 57   
   $��Role:��6   $��7��6!   $��Center=�6.   $��10q�6I   �� 58   
   -	   5        $ RoleComboBox��58   %   $ 1��6   $��7��6;   $��
150,5,10,5q�6H   $	��400��6\   .@�59      �� $��Admin��6   �� 5:      $��Customer��6   5;      �� 5>   
   $��8��6   
 �� Orientation$
 
Horizontal=�6"   $��Right=�6;   $��0,0,23,0q�6W   $��52��6i   $	��Top=�6u   .+�5?      �� -
   5        $��Submit��5?      $	��100��6&   $��5q�62   6=   �� 5@      -   5        $��Cancel��5@      $	��100��6&   $��5q�62   6=   5A      5B      5C      