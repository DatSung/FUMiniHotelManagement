   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:FUMiniHotelManagement.WPF.PagesFUMiniHotelManagement.WPF.Pages  5      3    -FUMiniHotelManagement.WPF.Pages.RoomTablePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:FUMiniHotelManagement.WPF.Pages     5        N� Title$  RoomTablePage��5	       � 	Resources 5         SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 40��6'   �� 5       � ��$	 120��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 5��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5       5"      5#      5$      .��5&      � .+�5'   
   �� -   5         ��Name$ RoomListView��5'      $��Center=�6)   $	��510��6F   $��	0,110,0,0q�6S   $	��Top=�6f   $	��970��6~    �� View 5(      �� 5)      .P�5*      �� $��RoomId��6%   	 �� Width$		 120��65   
 �� DisplayMemberBinding
 6A   �� *RoomId+�� 5+      $��
RoomNumber��6%   $		 150��69   
 6E   �� *
RoomNumber+�� 5,      $��RoomDetailDescription��6%   $		 150��6D   
 6P   �� *RoomDetailDescription+�� 5-      $��RoomMaxCapacity��6%   $		 200��6>   
 6J   �� *RoomMaxCapacity+�� 5.      $��RoomTypeName��6%   $		 150��6;   
 6G   �� *RoomType.RoomTypeName+�� 5/      $��
RoomStatus��6%   $		 100��69   
 6E   �� *
RoomStatus+�� 50      $��RoomPricePerDay��6%   $		 100��6>   
 6J   �� *RoomPricePerDay+51      53      �� 55   
   -   5         ��Name$ CreateButton��55      $��Create��6'   #��[  68   $
��Left=�6d   $��	10,10,0,0q�6   $	��Top=�6�   6�   �� 56   
   -   5        $ UpdateButton��56      $��Update��6'   #��[  68   $
��Left=�6d   $��
135,10,0,0q�6   $	��Top=�6�   6�   �� 57   
   -   5        $ DeleteButton��57      $��Delete��6'   #��[  68   $
��Left=�6d   $��
260,10,0,0q�6   $	��Top=�6�   6�   �� 59   
   -   5         ��Name$ 
SearchText��59      $
��Left=�6&   $��
557,10,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��298��6�   $��40��6�   �� 5:   
   -   5        $ SearchButton��5:      $��Search��6'   #��[  68   $
��Left=�6d   $��
860,10,0,0q�6   $	��Top=�6�   6�   �� 5;   
   $��Room Management��6   $
��Left=�5<      $	��Top=�5=      $��	10,55,0,0q�5>      $��50��5?      $	��370��5@      ���#333333$��28(�5B      $
��Bold"�5C      
������ $��5q�5E      5F      5G      