   M S B A M L   `   `   `  ����V  RPersonal Finance Manager V1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Personal_Finance_Manager_V1Personal_Finance_Manager_V1  5   	   ,    &Personal_Finance_Manager_V1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Personal_Finance_Manager_V1     5   	   $	��580��5   	   $	��920��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�62    � AllowsTransparency . $��Calibri)�5
   	   ��5	      Z� .��5      �� $��0q�6   ���#E9E9E9._�5   
   �  � RowDefinitions 5      �� 5      $
��0.6* �6    60   �� 5      $	��10* �6    6/    � ColumnDefinitions 5      �� 5      $	��25* �6#   61   �� 5      $
��100* �6#   62   .+�5      �� $��0��6   $��2��6"   ���#004E98$��0q�6M    �� CornerRadius$ 0��6a   ._�5      � -   5        ���#004E98.+�5      �� $
��15 5q�6    $��Calibri)�6.   
�������$��18(�6V   Personal Finance Manager6~   �� 5       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�5      �� -   5        $��0q�5   !   $��20��65   $��20��6@   $��Right=�6L   $	��Top=�6h   $��0 7 6 1q�6�   $��0q�5   )   
������ .��5!      �� $'��!/Resources/Icons/btn-minimize.png��6$   6Q   5#      �� 5$      -   5        $��0q�5$   !   $��20��65   $��20��6@   $��Right=�6L   $	��Top=�6h   $��0 7 6 1q�6�   $��0q�5%   )   
������ .��5(      �� $$��/Resources/Icons/btn-close.png��6$   6N   5)      5*      5+      5,      �� 5.      $��1��6   $��0��6"   ���#B4B4B4$��0.5 0 0.5 0.5q�6H   $ 0 0 0 10��6h   ._�5/      � $	��Top=�6   .+�50      �� $ Vertical=�6!   .+�51      �� $��	0 10 0 10q�6%   $ 
Horizontal=�68   $��Right=�6Q   .+�54      �� -   5        $��50��54   '   $��50��62   $��	12 10 5 0q�6>   $��Right=�6Q    � 	Resources 57   "   	 �� 
TargetType
 �� Property �� Value��%`   '��       �� 58   &   "	 ��6,   .�59   *   �� 
 �@��CornerRadius$	 100��6I   5:   '   5;   #   .��5<   "   �� $��50��6(   $��30��63   $$��/Resources/Icons/plus-icon.png��6?   5=   #   5>      5?      �� 5B      ���#B4B4B4$	��0.5q�67   $��
10 30 10 0q�6M   $ 3��6a    �� Padding$ 10q�5C   !   ���#F6F6F6._�5E      �� $��-1 -1 -1 -1q�6*   .+�5F   "   �� $��Calibri)�6-   $
��Thin"�6B   $��18(�6T   Transactions6p   �� 5G   "   -   5         ��Name$ TransactionMenu��5G   +   $��1��6[   $
��15 3q�6h   ���#F6F6F6��6D   Z� .@�5J   &   �� -   5        .��5K   *   �� $ 
Horizontal=�65   .+�5L   .   �� $��Center=�68   $��15(�6S   All Transactions6s   5M   +   5N   '   �� 5P   &   -   5        .��5Q   *   �� $ 
Horizontal=�65   .+�5R   .   �� $��Center=�68   $��15(�6S   Weekly6i   5S   +   5T   '   5U   #   �� 5W   "   $��0 20 0 0q�6,   $��Calibri)�6?   $
��Thin"�6T   $��18(�6f   	Reports6}   �� 5X   "   -   5        $ 
ReportMenu��5X   +   $��1��6?   $��15 5 0 0q�6L   ���#F6F6F6��6s   Z� .@�5Y   &   �� -	   5        .��5Z   *   �� $ 
Horizontal=�65   .+�5[   .   �� $��Center=�68   $��15(�6S   Report (In & Exp)6x   5\   +   5]   '   5^   #   5_      5`      5b      5d      5e      �� 5g      $��1��6   $��1��6"   ���#D8D8D8$��0 0 1 1q�6H   $��0 -1 0 0q�6b   $ 0 0 10 0��6t   ._�5i      � .+�5j       � -
   5          �Name$ MainWindowFrame��5j   H   $��10q�6     � NavigationUIVisibility$ Hidden=�6(   6c   5k      5m      5n      5o      5t      