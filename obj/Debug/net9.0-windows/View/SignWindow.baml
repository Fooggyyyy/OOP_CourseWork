   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OOP_CourseWorkOOP_CourseWork  5   	       OOP_CourseWork.SignWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OOP_CourseWork     5   	   -   5          � Title$  ContactWindow��5   	   $	��450��6   $	��800��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $	��10* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5        $	��Rix��5         Macondo#��[  5      $��0��5      $��0��5      $
��Left=�5      $	��Top=�5       � LayoutTransform 5      �� 5       �� ScaleX$ 4Q�6!    �� ScaleY$ 4Q�6,   5!      �� 5"   
   -   5        $��Sign In/Register��5"      $��Inter)�6N   $��1��6a   $��0��6q   $
��Left=�6~   $��Center=�6�   6�   �� 5#   
   $��Войти.��6   $��Inter)�6!   $��2��64   $��1��6D   $��Center=�6Q   $	��Top=�6n   6�   �� 5%   
   $��1��6   $��1��6   $��3��6/   $��Имя��5&   
   $��Stretch=�5'   
   $	��Top=�5(   
   $	��200��5)   
   $��40q�5*   
   �� 5,   
   $��1��6   $��1��6   $��3��6/   $��Пароль��5-      $��Stretch=�5.      $	��Top=�5/      $	��200��50      $��80q�51      �� 54   
   $��1��6   $��1��6   $��3��6.   $��Stretch=�6B   $��Bottom=�55      $��30��6   $	��250��6+   $	��100q�6:   .��6G   
Войти6N   �� 56   
   -   5        $��0��56      $��1��6$   $��5��61   $��Center=�57   	   $��Bottom=�6&   $
��Wrap=�58   	   $	��500��6   $��Inter)�6,   $��50q�5:      �� 5;   
   $B�<Нет аккаунта? Зарагестрируйтесь!��6    5<      �� 5=      $ 1Q�6!   $ 1Q�6,   5?      �� 5A   
   $��2��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5B      �� -   5        $��Помощь��5B      $��Almarai)�5C      $��Center=�5D      $��Center=�5E      $
��20,0q�5F       5I      �� 5J      $ 1Q�6%   $ 1Q�60   5L      �� 5N      -   5        $��Контакты��5N      $��Almarai)�5O      $��Center=�5P      $��Center=�5Q      $
��20,0q�5R       5T      �� 5U      $ 1Q�6%   $ 1Q�60   5W      �� 5Y      -   5        $!��Активные точки��5Y      $��Almarai)�5Z      $��Center=�5[      $��Center=�5\      $
��20,0q�5]       5_      �� 5`      $ 1Q�6%   $ 1Q�60   5b      5c      �� 5d   
   $��0��6   $��1��6"   $��4��62   $��Right=�6F   $��Center=�6b   $ 
Horizontal=�6}   .+�5e      �� -   5        $��Orders��5e      $��Almarai)�5f      $��Center=�5g      $��Center=�5h      $	��5,0q�5i       5k      �� 5l      $	 1.5Q�6%   $	 1.5Q�62   5n      �� 5o      -	   5        $��	Last View��5o      $��Almarai)�5p      $��Center=�5q      $��Center=�5r      $	��5,0q�5s       5u      �� 5v      $	 1.5Q�6%   $	 1.5Q�62   5x      �� 5y      -
   5        $��History��5y      $��Almarai)�5z      $��Center=�5{      $��Center=�5|      $	��5,0q�5}       5      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $��Bonus��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $��Favorite��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $
��Cart��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5         ��Name$
 shop��5�      $
��Shop��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      � 5�      -   5         �Name$ popup��5�      $��False��5�      	 � 	StaysOpen$
	 True��6   $��Right=�6,   $��Right=�6H   
 � HorizontalOffset$

 -200��6Z    � VerticalOffset$ 20��6r    � PlacementTarget 5�   #   ��  �� ElementName$ textBox��.��5�      �� -   5         ��Name$ listBox��5�      $	��200��6+   $��0��68   $��0��6E   .@�5�      �� -   5        $��Закрыть��5�   "   64   �� 5�      $��Все��6"   �� 5�      $��
Новое��6"   �� 5�      $��Футболки��6"   �� 5�      $��Толстовки��6"   �� 5�      $��Джинсы��6"   �� 5�      $��Рубашки��6"   �� 5�      $��Куртки��6"   �� 5�      $��
Брюки��6"   �� 5�      $��Акссесуары��6"   5�      5�      5�      5�      5�      