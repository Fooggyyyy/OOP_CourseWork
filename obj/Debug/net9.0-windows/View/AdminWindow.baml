   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OOP_CourseWork.ViewOOP_CourseWork.View  5   	   C&clr-namespace:OOP_CourseWork.ViewModelOOP_CourseWork.ViewModel  5   	   %    OOP_CourseWork.View.AdminWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   3local!clr-namespace:OOP_CourseWork.View     5   	   <	viewmodel&clr-namespace:OOP_CourseWork.ViewModel     5   	     � Title$  Admin Panel��5   	   $	��700��6   $
��1000��6*   $	��600��5   	   $
��1000��6    � Icon$d ^C:\Users\user\source\repos\OOP_CourseWork\OOP_CourseWork\Recources\tiktok_logo_icon_186896.ico��5   	   .��5
      � ���#FAFAFA$��10q�6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��0 0 0 10q�6!   .+�5      �� $.��(Админ-панель магазина��6   $��24(�65   $
��Bold"�6C   $��Segoe UI)�6U   ���#3336k   �� 5      -   5         	  Store#���   5      $��Almarai)�5      $��16(�5      $
��Bold"�5      
����Zj� � Cursor$
 Hand��5      $��20,0,0,0q�5      $��Right=�5      $��Center=�5      5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#    5$      �� 5%      $��* �6    �� 5&      $��* �6    .+�5)      �� $+��%Управление товарами��6   $��0��64   $��0��6A   $
��Bold"�6Q   $��Segoe UI)�6c   .��5*      �� $��10q�6   .+�5+      &   System.Windows.Controls.DataGrid  -   5          Name$ ItemsDataGrid��5+      $	��180��5.         AutoGenerateColumns$
 True��6,   ��5,      �� *Items+ �� SelectedItem 5-      �� *SelectedItem+ �� Mode$ TwoWay=�5.   ,   �� 50      	 �� Orientation$	 
Horizontal=�6!   $��0,10,0,0q�6:   $��Center=�6L   .+�51      �� $��Добавить��6!   $��90��64   ��6?   �� *	AddItem+��6[   �� *SelectedItem+
 �� ElementName$
 ItemsDataGrid���� 52      $��Удалить��6!   $��90��63   ��6>   �� *
DeleteItem+��6]   �� *SelectedItem+$
 ItemsDataGrid���� 53      $��Обновить��6!   $��90��64   ��6?   �� *
UpdateItem+��6^   �� *SelectedItem+$
 ItemsDataGrid��54      55      56      �� 58      $��Пользователи��6   $��1��6-   $��0��6:   $
��Bold"�6J   $��Segoe UI)�6\   .��59      �� $��10q�6   .+�5:        -   5        $ UsersDataGrid��5:      $	��180��5=      $
 True��6,   ��5;      �� *Users+ 5<      �� *SelectedUser+$ TwoWay=�5=   ,   �� 5>      $ ��Заблокировать��6   $��0,10,0,0q�5A      $	��160��6/   $��Center=�6;   ��5?      �� *
DeleteUser+��5@      �� *SelectedItem+$
 UsersDataGrid��5A   ;   �� 5B      $"��Разблокировать��6   $��0,10,0,0q�5E      $	��160��6/   $��Center=�6;   ��5C      �� *OnBlockUser1+��5D      �� *SelectedItem+$
 UsersDataGrid��5E   ;   5F      5G      �� 5I      $��Заказы��6   $��2��6'   $��1��68   $��2��6H   $
��Bold"�6\   $��Segoe UI)�6n   .��5J      �� $��10q�6   .+�5K        -   5        $ OrdersDataGrid��5K      $ False��5N      $	��360��5O         CanUserAddRows$ False��5P      ��5L      �� *Orders+ 5M      �� *SelectedOrder+$ TwoWay=�   Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T      
IsReadOnly$
 True��6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6a     5S      $ Пользователь��61   $ * 6b   $
 True��6l    6G   �� *UserId+6l     5T      $ 
Товар��61   $ * 6^   $
 True��6h    6@   �� *	Item.Name+6h     5U      $ Статус��61   $ * 6\    6A   �� *Status+6\   5W      �� 5Y      $#��Изменить статус��6   $	��150��5[      $��Right=�5\      $��0,10,0,0q�5]      ��5Z      �� *ChangeOrderStatusCommand+5]      5^      5_      5`      5a      5b      