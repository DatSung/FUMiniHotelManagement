   M S B A M L   `   `   `  ����T  PFUMiniHotelManagement.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:FUMiniHotelManagement.WPF.PagesFUMiniHotelManagement.WPF.Pages  5      7    1FUMiniHotelManagement.WPF.Pages.CustomerTablePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:FUMiniHotelManagement.WPF.Pages     5        N� Title$  CustomerTablePage��5	       � 	Resources 5         SidebarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 40��6'   �� 5       � ��$	 120��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 5��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5       5"      5#      5$      .��5&      � .+�5'   
   �� -   5         ��Name$ CustomerListView��5'      $��Center=�6-   $	��510��6J   $��	0,110,0,0q�6W   $	��Top=�6j   $	��970��6�    �� View 5(      �� 5)      .P�5*      �� $��UserId��6%   	 �� Width$		 120��65   
 �� DisplayMemberBinding
 6A   �� *UserId+�� 5+      $��FullName��6%   $		 150��67   
 6C   �� *
FullName+�� 5,      $��	Telephone��6%   $		 150��68   
 6D   �� *	Telephone+�� 5-      $��Email��6%   $		 200��64   
 6@   �� *EmailAddress+�� 5.      $��Birthday��6%   $		 150��67   
 6C   �� *
Birthday+�� 5/      $��Status��6%   $		 100��65   
 6A   �� *Status+�� 50      $
��Role��6%   $		 100��63   
 6?   �� *Role+51      53      �� 55   
   -   5         ��Name$ CreateButton��55      $��Create��6'   #��[  68   $
��Left=�6d   $��	10,10,0,0q�6   $	��Top=�6�   6�   �� 56   
   -   5        $ UpdateButton��56      $��Update��6'   #��[  68   $
��Left=�6d   $��
135,10,0,0q�6   $	��Top=�6�   6�   �� 57   
   -   5        $ DeleteButton��57      $��Delete��6'   #��[  68   $
��Left=�6d   $��
260,10,0,0q�6   $	��Top=�6�   6�   �� 58   
   -   5        $ ExportButton��58      $��Export��6'   $
��Left=�68   $��
400,20,0,0q�6S   $	��Top=�6g   6   �� 59   
   -   5        $ ImportButton��59      $��Import��6'   $
��Left=�68   $��
450,20,0,0q�6S   $	��Top=�6g   6   �� 5;   
   -   5         ��Name$ 
SearchText��5;      $
��Left=�6&   $��
557,10,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��298��6�   $��40��6�   �� 5<   
   -   5        $ SearchButton��5<      $��Search��6'   #��[  68   $
��Left=�6d   $��
860,10,0,0q�6   $	��Top=�6�   6�   �� 5>   
   $��Customer Management��6   $
��Left=�5?      $	��Top=�5@      $��	10,55,0,0q�5A      $��50��5B      $	��370��5C      ���#333333$��28(�5E      $
��Bold"�5F      
������ $��5q�5H      5I      5J      