   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:FUMiniHotelManagement.WPF.PagesFUMiniHotelManagement.WPF.Pages  5      1    +FUMiniHotelManagement.WPF.Pages.SideBarPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:FUMiniHotelManagement.WPF.Pages     5        N� Title$  SideBarPage��5	       � 	Resources 5         SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �	#FF34495E6+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��
 ���� 6,   �� 5       � ��$ 2q�60   �� 5       � ��$ 10q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 5��5   !   #��z��5   !   #��z��5   !   $��5q�5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5!       5"      P� 5#       �@J�IsMouseOver$
	 True��61   . �5$      ��  � �� �	#FF2C3E5063   5%      P� 5&       � ��$
	 True��6/   . �5'      ��  � �� �	#FF1ABC9C63   5(      5*      5+      .��5-      � ���	#FF2C3E50.+�5/   
   �� $	��Top=�6   $��Center=�6-   $��0,30,0,0q�6J   .+�53      �� -   5        #��[  54      .��57      �� .+�58      �� -   5        
 ��Name$
 
UserAvatar��58      $	��100��60   $	��100��6<   ��59      �� 5:       �� 	UriSource$1 +pack://application:,,,/Images/user_icon.jpg?�6*   5<      �� 5=      -   5         ��Name$ FullNameLabel��5=       $��Center=�67   $��FullName��6T   5>      5@      �� 5B      -   5         ��Name$ CustomerButton��5B      $��Customer��5C      $��50��5D      $	��200��5E       � Cursor$
 Hand��5G      $��0,0,0,10q�5H      #��[  5I      �� 5K      -   5        $ 
RoomButton��5K      $
��Room��5L      $��50��5M      $	��200��5N      $
 Hand��5P      $��0,0,0,10q�5Q      #��[  5R      �� 5T      -   5        $ BookingButton��5T      $��Booking��5U      $��50��5V      $	��200��5W      $
 Hand��5Y      $��0,0,0,10q�5Z      #��[  5[      5\      �� 5]   
   -   5        $ 
ExitButton��5]      $��Logout��5^   	   $��50��5_   	   $	��200��5`   	   $
 Hand��5b   	   $��30,550,30,30q�5c   	   #��[  5d   	   5e      5f      