   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OOP_CourseWorkOOP_CourseWork  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   #    OOP_CourseWork.FavoriteWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OOP_CourseWork     5	   	   =
properties&clr-namespace:System;assembly=mscorlib     5
   	   -   5        $	��780��5   	   $	��430��6   $	��800��5   	   $	��600��6     � Icon$d  ^C:\Users\user\source\repos\OOP_CourseWork\OOP_CourseWork\Recources\tiktok_logo_icon_186896.ico��5   	    � Title$ FavoriteWindow��5   	   $	��450��6    $	��800��6-   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $	��10* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5        $	��Rix��5      $��Segoe UI)�5      $
��Bold"�5      
���   �$
��Left=�5      $	��Top=�5       $��0,0,0,10q�5!       � LayoutTransform 5"      �� 5#       �� ScaleX$ 3Q�6!    �� ScaleY$ 3Q�6,   5%      �� 5&   
   -   5        $��Sign In / Register��5&      $��Inter)�5'      $��14(�5(      
���   � � Cursor$
 Hand��5*      $
��Left=�5+      $��Center=�5,      $��1��5-      $��0��5.      $��10,0,0,0q�5/      ��51      �� 52       �� 
TargetType" ��6   .�53      �� 	 �� Property	 � ��
 �� Value
 �#CCCCCC63   �� 54      	 � ��$
 SemiBold"�63   �� 55      	 � ��$

 None{�6B    �� Triggers 56      P� 57       P� Property �@J�IsMouseOver P� Value$
 True��69   . �58      �� 	 � ��
 �#FFFFFF6;   �� 59      	 � ��$
 	Underline{�6J   5:      5<      5>      �� 5@   
   $��1��6   $��1��6$   $��3��64   $
��Auto=�5A      $��20q�62   .��5B      �� ��6   �� *FavortesItems+��5C      �� 5D      .R�5E      �  K� IsItemsHost$
 True��6$   $��0q�67   5F      ��5I      �� 5J      .R�5K      �� ���#DDDDDD$��1q�67   
������� �� CornerRadius$ 10��5L   ,   $��10q�5M       �� Padding$ 10q�6%   $	��180��62   $	��300��6>   ._�5O      �� $��Center=�6)   .+�5Q   "   �� $	��130��6E   $	��130��6R   $��UniformToFill=�5R       $��0,0,0,10q�68   $
}�True��5S       ��5Q   (   �� *	PhotoPath+5S       �� 5V   "   $
��Bold"�5W   $   $��14(�66    �� TextAlignment$ Center=�5X   $   $
��Wrap=�6;   $��0,0,0,4q�5Y   $   ��5V   ,   �� *Name+5Y   $   �� 5\   "   ���#4CAF50$��13(�5]   9   $��SemiBold"�5^   $   $ Center=�6:   $��0,0,0,4q�5_   $   ��5\   ,   �� *Price+5_   $   �� 5b   "   $��12(�5c   $   
�������$ Center=�5d   $   ��5b   ,   �� *Size+5d   $   �� 5g   "   $��🗑 Удалить��6)   $��0,12,0,0q�5j   !   $	��120��63   $��30��6?   ���#F44336
�������$
��Bold"�5l   !   $��Inter)�63   $��0q�5m   !   $
 Hand��65   ��5h   !   �� *#!DataContext.RemoveFavoriteCommand+ �� RelativeSource ��  �� AncestorType
 Window��5i   !   �� 5m   5   5n      5o      5p      5r      5s      �� 5v   
   $��3��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5x      �� -   5           Help#���   5x      $��Almarai)�5y      $��Center=�5z      $��Center=�5{      $
��20,0q�5|      $
 Hand��5}      
���   ���5�      �� 5�      " ��6   .�5�      �� 	 � ��

 �   �67   �� 5�      	 � ��$
 14(�65    5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� 	 � ��

 �����6?   �� 5�   "   	 � ��$
 	Underline{�6D   5�      5�       5�      �� 5�      $ 1Q�6%   $ 1Q�60   5�      �� 5�      -   5          Contacts#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $
��20,0q�5�      $
 Hand��5�      
���   ���5�      �� 5�      " ��6   .�5�      �� 	 � ��

 �����67   �� 5�      	 � ��$
 14(�65    5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� 	 � ��

 �����6?   �� 5�   "   	 � ��$
 	Underline{�6D   5�      5�       5�      �� 5�      $ 1Q�6%   $ 1Q�60   5�      �� 5�      -   5          ActiveSpots#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $
��20,0q�5�      $
 Hand��5�      
���   ���5�      �� 5�      " ��6   .�5�      �� 	 � ��

 �����67   �� 5�      	 � ��$
 14(�65    5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� 	 � ��

 �����6?   �� 5�   "   	 � ��$
 	Underline{�6D   5�      5�       5�      �� 5�      $ 1Q�6%   $ 1Q�60   5�      5�      �� 5�   
   $��0��6   $��1��6"   $��4��62   $��Right=�6F   $��Center=�6b   $ 
Horizontal=�6}   .+�5�      �� -   5         
 Orders#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5          
LastViewed#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -	   5          History#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -
   5         	 Bonus#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5          	Favorites#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5          	AddToCart#���  5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5     �� 5     -   5         ��Name$
 shop��5      		 Store#��� 	 5     $��Almarai)�5     $��Center=�5     $��Center=�5     $	��5,0q�5      5	     �� 5
     $	 1.5Q�6%   $	 1.5Q�62   5     � 5     -   5         �Name$ popup��5     $��False��5      � 	StaysOpen$
 True��6   $��Right=�6,   $��Right=�6H    � HorizontalOffset$
 -200��6Z    � VerticalOffset$ 20��6r    � PlacementTarget 5  #   ��  �� ElementName$ textBox��.��5     �� -   5         ��Name$ listBox��5     $	��200��6+   $��0��68   $��0��6E   .@�5     �� -   5        $��Закрыть��5  "   64   �� 5     $��Все��6"   �� 5     $��
Новое��6"   �� 5     $��Футболки��6"   �� 5     $��Толстовки��6"   �� 5     $��Джинсы��6"   �� 5     $��Рубашки��6"   �� 5     $��Куртки��6"   �� 5     $��
Брюки��6"   �� 5     $��Акссесуары��6"   5     5     5     5     5     