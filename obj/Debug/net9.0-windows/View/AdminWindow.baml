   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OOP_CourseWork.ViewOOP_CourseWork.View  5   	   C&clr-namespace:OOP_CourseWork.ViewModelOOP_CourseWork.ViewModel  5   	   %    OOP_CourseWork.View.AdminWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:OOP_CourseWork.View     5   	   <	viewmodel&clr-namespace:OOP_CourseWork.ViewModel     5   	     � Title$  Admin Panel��5	   	   $	��700��6   $
��1000��6*   $	��600��5
   	   $
��1000��6    � Icon$d ^C:\Users\user\source\repos\OOP_CourseWork\OOP_CourseWork\Recources\tiktok_logo_icon_186896.ico��5   	    J� InputBindings 5      �� 5   
   
 �� Key$ Z��6    �� 	Modifiers$ Controlf�6    �� Command 61   �� *UndoCommand+�� 5   
   $ Y��6   $ Controlf�6    61   �� *RedoCommand+.��5      � ���#FAFAFA$��10q�6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��0 0 0 10q�6!   .+�5      �� $.��(Админ-панель магазина��6   $��24(�65   $
��Bold"�6C   $��Segoe UI)�6U   ���#3336k   �� 5      -   5         	  Store#���   5      $��Almarai)�5      $��16(�5      $
��Bold"�5      
����Zj� � Cursor$
 Hand��5      $��20,0,0,0q�5       $��Right=�5!      $��Center=�5"      5#      5$      � 5&   
   $��1��6    � ColumnDefinitions 5'      �� 5(      $��* �6#   �� 5)      $��* �6#   �� 5*      $��* �6#    5,      �� 5-      $��* �6    �� 5.      $��* �6    .+�51      �� $+��%Управление товарами��6   $��0��64   $��0��6A   $
��Bold"�6Q   $��Segoe UI)�6c   .��52      �� $��10q�6   .+�53      �� 	 �� Orientation$	 
Horizontal=�6!   $��0,0,0,10q�6:   $��Right=�6L   .+�54      �� 
 � ToolTip$
 Отменить (Ctrl+Z)��56       $��0,0,5,0q�57       $	��100��58       ��54   !   �� *UndoCommand+{�55       �� *	CanUndo+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��59      �� $��↩ Отменить��6(   5:      �� 5;      $!
 Повторить (Ctrl+Y)��5=       $	��100��5>       ��5;   !   �� *RedoCommand+{�5<       �� *	CanRedo+$ OneWay=�$ PropertyChanged=�.��5?      �� $��↪ Повторить��6(   5@      5A      &   System.Windows.Controls.DataGrid  5C      -   5          Name$ ItemsDataGrid��5C      $	��180��5F         AutoGenerateColumns$
 True��6,   ��5D      �� *Items+ �� SelectedItem 5E      �� *SelectedItem+$ TwoWay=�5F   ,   �� 5H      $	 
Horizontal=�6!   $��0,10,0,0q�6:   $��Center=�6L   .+�5I      �� $��Добавить��6!   $��90��64   ��6?   �� *	AddItem+��6[   �� *SelectedItem+ �� ElementName$ ItemsDataGrid���� 5J      $��Удалить��6!   $��90��63   ��6>   �� *
DeleteItem+��6]   �� *SelectedItem+$ ItemsDataGrid���� 5K      $��Обновить��6!   $��90��64   ��6?   �� *
UpdateItem+��6^   �� *SelectedItem+$ ItemsDataGrid��5L      5M      5N      �� 5P      $��Пользователи��6   $��1��6-   $��0��6:   $
��Bold"�6J   $��Segoe UI)�6\   .��5Q      �� $��10q�6   .+�5R        -   5        $ UsersDataGrid��5R      $	��180��5U      $
 True��6,   ��5S      �� *Users+ 5T      �� *SelectedUser+$ TwoWay=�5U   ,   �� 5V      $ ��Заблокировать��6   $��0,10,0,0q�5Y      $	��160��6/   $��Center=�6;   ��5W      �� *
DeleteUser+��5X      �� *SelectedItem+$ UsersDataGrid��5Y   ;   �� 5Z      $"��Разблокировать��6   $��0,10,0,0q�5]      $	��160��6/   $��Center=�6;   ��5[      �� *OnBlockUser1+��5\      �� *SelectedItem+$ UsersDataGrid��5]   ;   5^      5_      �� 5a      $��Заказы��6   $��2��6'   $��1��68   $��2��6H   $
��Bold"�6\   $��Segoe UI)�6n   .��5b      �� $��10q�6   .+�5c        -   5        $ OrdersDataGrid��5c      $ False��5f      $	��360��5g         CanUserAddRows$ False��5h      ��5d      �� *Orders+ 5e      �� *SelectedOrder+$ TwoWay=�   Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T      
IsReadOnly$
 True��6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6a     5k      $ Пользователь��61   $ * 6b   $
 True��6l    6G   �� *UserId+6l     5l      $ 
Товар��61   $ * 6^   $
 True��6h    6@   �� *	Item.Name+6h     5m      $ Статус��61   $ * 6\    6A   �� *Status+6\   5o      �� 5q      $#��Изменить статус��6   $	��150��5s      $��Right=�5t      $��0,10,0,0q�5u      ��5r      �� *ChangeOrderStatusCommand+5u      5v      5w      5x      5y      5z      