   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OOP_CourseWorkOOP_CourseWork  5   	        OOP_CourseWork.BonusWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OOP_CourseWork     5   	   -   5          � Title$  BonusWindow��5	   	   $	��450��6   $	��800��6*   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $	��10* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5        $	��Rix��5         Macondo#��[  5      $��0��5      $��0��5      $
��Left=�5      $	��Top=�5       � LayoutTransform 5      �� 5       �� ScaleX$ 4Q�6!    �� ScaleY$ 4Q�6,   5!      �� 5"   
   -   5        $��Sign In/Register��5"      $��Inter)�6O   $��1��6b   $��0��6r   $
��Left=�6�   $��Center=�6�   6�   �� 5#   
   -   5        $#��История Покупок��5#      $��Inter)�5$      $��1��5%      $��1��5&      $��3��5'      $��Center=�5(      $	��Top=�5)       5+      �� 5,      $ 3Q�6!   $ 3Q�6,   5.      �� 51   
   $��1��6   $��1��6$   $��3��61   $
��Left=�52      $��Center=�6#   $
��Wrap=�53      $	��500��6   $��Inter)�6+   �� 54      $D�>Ваше текущее количество бонусов: 0��6    55      �� 56      $ 1Q�6!   $ 1Q�6,   58      �� 5:   
   $��1��6   $��1��6$   $��5��61   $
��Left=�5;      $��Bottom=�6#   $
��Wrap=�5<      $	��500��6   $��Inter)�6+   �� 5=      $?�9Как работает бонусная система: ��6   �� 5>      �� 5?      $���За каждую покупку от 8000 рублей, за каждые последующие 500 рублей в цене заказа вы получате 1 бонус.��6   �� 5@      �� 5A      $M�G1 бонус = 5% скидки на заказ от 10000 рублей.��6   �� 5B      �� 5C      $���При оплате бонусами, оплачиваемый товар бонусной системе не подлежит.��6   �� 5D      �� 5E      $M�GМаксимальное количество - 10 бонусов(50%).��6    5F      �� 5G      $ 1Q�6!   $ 1Q�6,   5I      �� 5K   
   $��2��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5L      �� -   5        $��Помощь��5L      $��Almarai)�5M      $��Center=�5N      $��Center=�5O      $
��20,0q�5P       5S      �� 5T      $ 1Q�6%   $ 1Q�60   5V      �� 5X      -   5        $��Контакты��5X      $��Almarai)�5Y      $��Center=�5Z      $��Center=�5[      $
��20,0q�5\       5^      �� 5_      $ 1Q�6%   $ 1Q�60   5a      �� 5c      -   5        $!��Активные точки��5c      $��Almarai)�5d      $��Center=�5e      $��Center=�5f      $
��20,0q�5g       5i      �� 5j      $ 1Q�6%   $ 1Q�60   5l      5m      �� 5n   
   $��0��6   $��1��6"   $��4��62   $��Right=�6F   $��Center=�6b   $ 
Horizontal=�6}   .+�5o      �� -   5        $��Orders��5o      $��Almarai)�5p      $��Center=�5q      $��Center=�5r      $	��5,0q�5s       5u      �� 5v      $	 1.5Q�6%   $	 1.5Q�62   5x      �� 5y      -	   5        $��	Last View��5y      $��Almarai)�5z      $��Center=�5{      $��Center=�5|      $	��5,0q�5}       5      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -
   5        $��History��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $��Bonus��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $��Favorite��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $
��Cart��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5         ��Name$
 shop��5�      $
��Shop��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      � 5�      -   5         �Name$ popup��5�      $��False��5�      	 � 	StaysOpen$
	 True��6   $��Right=�6,   $��Right=�6H   
 � HorizontalOffset$

 -200��6Z    � VerticalOffset$ 20��6r    � PlacementTarget 5�   #   ��  �� ElementName$ textBox��.��5�      �� -   5         ��Name$ listBox��5�      $	��200��6+   $��0��68   $��0��6E   .@�5�      �� -   5        $��Закрыть��5�   "   64   �� 5�      $��Все��6"   �� 5�      $��
Новое��6"   �� 5�      $��Футболки��6"   �� 5�      $��Толстовки��6"   �� 5�      $��Джинсы��6"   �� 5�      $��Рубашки��6"   �� 5�      $��Куртки��6"   �� 5�      $��
Брюки��6"   �� 5�      $��Акссесуары��6"   5�      5�      5�      5�      5�      