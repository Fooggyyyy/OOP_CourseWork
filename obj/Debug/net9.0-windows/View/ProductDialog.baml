   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:OOP_CourseWork.ViewOOP_CourseWork.View  5   	   '    !OOP_CourseWork.View.ProductDialog   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:OOP_CourseWork.View     5   	     � Title$  Product Details��5	   	   $	��450��6!   $	��400��6.    � WindowStartupLocation$ CenterOwner=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Name:��6-   $��0,0,10,5q�6=   �� 5   
   -   5         ��Name$ NameTextBox��5      $��0��6'   $��1��64   $��0,0,0,5q�5       ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5       �� 5#   
   $��1��6   $��0��6   $��Description:��6-   $��0,0,10,5q�6D   �� 5$   
   $��1��6   $��1��6    �� TextWrapping$
 Wrap=�5&       �� AcceptsReturn$
 True��6&   $��60��6;   $��0,0,0,5q�6G   ��5%      �� *Description+$ PropertyChanged=�$ TwoWay=�5&   G   �� 5)   
   $��2��6   $��0��6   $��Price:��6-   $��0,0,10,5q�6>   �� 5*   
   $��2��6   $��1��6   $��0,0,0,5q�5,      ��5+      �� *Price+$ PropertyChanged=�$ TwoWay=�5,      �� 5/   
   $��3��6   $��0��6   $��Type:��6-   $��0,0,10,5q�6=   �� 50   
   $��3��6   $��1��6    $��0,0,0,5q�53      ��51      �� *TypeWearValues+	 �� SelectedItem	 52      �� *
TypeWear+$ PropertyChanged=�$ TwoWay=�53      �� 56   
   $��4��6   $��0��6   $��Image:��6-   $��0,0,10,5q�6>   �� 57   
   -   5        $��4��57      $��1��6   $��Select Image��6.   $��0,0,0,5q�58   +   �� 5;   
   $��5��6   $��0��6   $��2��6-   $��Uniform=�5=      $	��0,5q�5>      ��5<      �� *ImageSource+5>      �� 5A   
   $��6��6   $��0��6"   $��2��62   
 �� Orientation$
 
Horizontal=�5B      $��Right=�6.   .+�5C      �� -   5        $
��Save��5C      $��80��67   $��0,0,10,0q�6B   �� 5D      -   5        $��Cancel��5D      $��80��6;   5E      5F      5G      