   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OOP_CourseWork.ViewOOP_CourseWork.View  5   	   &     OOP_CourseWork.View.AdminAdoView   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:OOP_CourseWork.View     5   	     � Title$  Admin ADO.NET Panel��5   	   $	��650��6%   $
��1000��62    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $	��200��6   $��0,0,10,0q�6"   ��5      �� *
SearchTerm+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $	��150��6   $��0,0,10,0q�6#   ��5      �� *SortOptions+ �� SelectedItem 5      �� *SelectedSortOption+�� 5      $��Refresh��6   $	��100��5      $��0,0,10,0q�6!   ��5   '   �� *RefreshCommand+5   !   �� 5      $��Reinitialize DB��6   $	��100��5      $��0,0,10,0q�6!   ��5   /   �� *ReinitializeDatabaseCommand+5   !   5      &   System.Windows.Controls.DataGrid  5    
   $��1��6   $��0,0,0,10q�6       AutoGenerateColumns$ False��5#         
IsReadOnly$
 True��5$         SelectionMode$ Single=�5%      ��5!      �� *
Products+ 5"      �� *SelectedProduct+	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5(      $

 Name��6%   $	 200 6L    63   �� *Name+6L     5)      $
 Description��6%   $	 250 6Z    6:   �� *Description+6Z     5*      $
 Price��6%   $	 100 6N    64   �� *Price+6N     5+      $

 Type��6%   $	 100 6P    63   �� *
TypeWear+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $
 Image��6)   $	 100 68      CellTemplate 5-      �� 5.      .R�5/      �� $��50��6=   $��50��6I   $��Uniform=�50   $   ��5/   $   �� *Image+50   $   51      53      55      �� 58   
   $��2��6   $ 
Horizontal=�6"   .+�59      �� $	��Add��6   $	��100��5:      $��0,0,10,0q�6!   ��59   #   �� *
AddCommand+5:   !   �� 5;      $
��Edit��6   $	��100��5<      $��0,0,10,0q�6!   ��5;   $   �� *EditCommand+5<   !   �� 5=      $��Delete��6   $	��100��5>      $��0,0,10,0q�6!   ��5=   &   �� *DeleteCommand+5>   !   �� 5?      $��Back to Main��6   $	��100��5@      $��0,0,10,0q�6!   ��5?   ,   �� *NavigateToMainCommand+5@   !   5A      5B      5C      