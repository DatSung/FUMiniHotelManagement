   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:FUMiniHotelManagement.WPF.PagesFUMiniHotelManagement.WPF.Pages  5      <    6FUMiniHotelManagement.WPF.Pages.BookingDetailTablePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:FUMiniHotelManagement.WPF.Pages     5        N� Title$  BookingDetailTablePage��5	       � 	Resources 5         SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 40��6'   �� 5       � ��$	 120��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 5��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5       5"      5#      5$      .��5&      � .+�5'   
   �� -   5         ��Name$ BookingDetailListView��5'      $��Center=�62   $	��510��6O   $��	0,110,0,0q�6\   $	��Top=�6o   $	��970��6�    �� View 5(      �� 5)      .P�5*      �� $��BookingReservationId��6%   	 �� Width$		 120��6C   
 �� DisplayMemberBinding
 6O   �� *BookingReservationId+�� 5+      $��RoomId��6%   $		 200��65   
 6A   �� *RoomId+�� 5,      $��	StartDate��6%   $		 200��68   
 6D   �� *	StartDate+�� 5-      $��EndDate��6%   $		 200��66   
 6B   �� *	EndDate+�� 5.      $��ActualPrice��6%   $		 200��6:   
 6F   �� *ActualPrice+5/      51      �� 53   
   -   5         ��Name$ CreateButton��53      $��Create��6'   #��[  68   $
��Left=�6d   $��	10,10,0,0q�6   $	��Top=�6�   6�   �� 54   
   -   5        $ UpdateButton��54      $��Update��6'   #��[  68   $
��Left=�6d   $��
135,10,0,0q�6   $	��Top=�6�   6�   �� 55   
   -   5        $ DeleteButton��55      $��Delete��6'   #��[  68   $
��Left=�6d   $��
260,10,0,0q�6   $	��Top=�6�   6�   �� 57   
   -   5         ��Name$ 
SearchText��57      $
��Left=�6&   $��
557,10,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��298��6�   $��40��6�   �� 58   
   -   5        $ SearchButton��58      $��Search��6'   #��[  68   $
��Left=�6d   $��
860,10,0,0q�6   $	��Top=�6�   6�   �� 5:   
   $��Booking Detail Management��6   $
��Left=�5;      $	��Top=�5<      $��	10,55,0,0q�5=      $��50��5>      $	��370��5?      ���#333333$��28(�5A      $
��Bold"�5B      
������ $��5q�5D      5E      5F      