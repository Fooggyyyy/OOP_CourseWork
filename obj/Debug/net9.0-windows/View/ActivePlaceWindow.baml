   M S B A M L   `   `   `  ����I  EOOP_CourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OOP_CourseWorkOOP_CourseWork  5   	   &     OOP_CourseWork.ActivePlaceWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OOP_CourseWork     5   	   -   5          � Title$  
HelpWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $	��10* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5        $	��Rix��5         Macondo#��[  5      $��0��5      $��0��5      $
��Left=�5      $	��Top=�5       � LayoutTransform 5      �� 5        �� ScaleX$ 4Q�6!    �� ScaleY$ 4Q�6,   5"      �� 5#   
   -   5        $��Sign In/Register��5#      $��Inter)�6O   $��1��6b   $��0��6r   $
��Left=�6   $��Center=�6�   6�   �� 5%   
   $��Inter)�5&      $��1��5'      $��1��5(      $
��Left=�5)      $	��Top=�5*       5+      �� 5,      $ 1Q�6!   $ 1Q�6,   �� 5.      $�	Rix-store��6   �� 5/      �� 50      $�Г.Минск��6   �� 51      �� 52      $"�Ул.Бобруйская 25��6   �� 53      54      �� 55   
   $��Inter)�56      $��3��57      $��1��58      $
��Left=�59      $	��Top=�5:       5;      �� 5<      $ 1Q�6!   $ 1Q�6,   �� 5>      $�Часы работы:��6   �� 5?      �� 5@      $'�!Ежедневно: 12:00 - 21:00��6   5A      �� 5C   
   $_��YC:\Users\user\source\repos\OOP_CourseWork\OOP_CourseWork\Recources\Photo\ActivePlace1.png��6   $��1��6s   $��2��6�   �� 5D   
   $_��YC:\Users\user\source\repos\OOP_CourseWork\OOP_CourseWork\Recources\Photo\ActivePlace2.png��6   $��3��6s   $��2��6�   �� 5E   
   $��3��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5F      �� -   5        $��Помощь��5F      $��Almarai)�5G      $��Center=�5H      $��Center=�5I      $
��20,0q�5J       5M      �� 5N      $ 1Q�6%   $ 1Q�60   5P      �� 5R      -   5        $��Контакты��5R      $��Almarai)�5S      $��Center=�5T      $��Center=�5U      $
��20,0q�5V       5X      �� 5Y      $ 1Q�6%   $ 1Q�60   5[      �� 5]      -   5        $!��Активные точки��5]      $��Almarai)�5^      $��Center=�5_      $��Center=�5`      $
��20,0q�5a       5c      �� 5d      $ 1Q�6%   $ 1Q�60   5f      5g      �� 5h   
   $��0��6   $��1��6"   $��4��62   $��Right=�6F   $��Center=�6b   $ 
Horizontal=�6}   .+�5i      �� -   5        $��Orders��5i      $��Almarai)�5j      $��Center=�5k      $��Center=�5l      $	��5,0q�5m       5o      �� 5p      $	 1.5Q�6%   $	 1.5Q�62   5r      �� 5s      -   5        $��	Last View��5s      $��Almarai)�5t      $��Center=�5u      $��Center=�5v      $	��5,0q�5w       5y      �� 5z      $	 1.5Q�6%   $	 1.5Q�62   5|      �� 5}      -	   5        $��History��5}      $��Almarai)�5~      $��Center=�5      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -
   5        $��Bonus��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $��Favorite��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5        $
��Cart��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      �� 5�      -   5         ��Name$
 shop��5�      $
��Shop��5�      $��Almarai)�5�      $��Center=�5�      $��Center=�5�      $	��5,0q�5�       5�      �� 5�      $	 1.5Q�6%   $	 1.5Q�62   5�      � 5�      -   5         �Name$ popup��5�      $��False��5�      	 � 	StaysOpen$
	 True��6   $��Right=�6,   $��Right=�6H   
 � HorizontalOffset$

 -200��6Z    � VerticalOffset$ 20��6r    � PlacementTarget 5�   #   ��  �� ElementName$ textBox��.��5�      �� -   5         ��Name$ listBox��5�      $	��200��6+   $��0��68   $��0��6E   .@�5�      �� -   5        $��Закрыть��5�   "   64   �� 5�      $��Все��6"   �� 5�      $��
Новое��6"   �� 5�      $��Футболки��6"   �� 5�      $��Толстовки��6"   �� 5�      $��Джинсы��6"   �� 5�      $��Рубашки��6"   �� 5�      $��Куртки��6"   �� 5�      $��
Брюки��6"   �� 5�      $��Акссесуары��6"   5�      5�      5�      5�      5�      