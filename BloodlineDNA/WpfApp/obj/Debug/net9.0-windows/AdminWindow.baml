   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.AdminWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	    localclr-namespace:WpfApp  5   	     � Title$  AdminWindow��5	   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	   
������  � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      ��  �� CornerRadius$ 10��6   $��1q�5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �    winBorderColor1 � Color# [  6   	 � Offset$	 0Q�6H   � 5        winBorderColor2# [ 6   $	 0Q�6H   � 5        winBorderColor3# [ 6   $	 1Q�6H   5      ._�5   
   � 
 � ColumnDefinitions
 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5%      �� $ 10, 0, 0, 10��6   $��0��5&      ��5'      �� 5(      $	 0,1&�6*   $	 1,0&�6;   .��5)      �   secondaryBackColor1# [ 6'   $	 0Q�6T   � 5*        secondaryBackColor2# [ 6'   $	 1Q�6T   5+      ._�5.      �� .+�50      ��  �� Orientation$ 
Horizontal=�6!   $��35��51   !   $��
15,25,0 40q�52   !   .+�53      �� $,��&pack://application:,,,/Images/Icon.png��6    �� 54      $��Manager Panel��6$     titleColor1#��[ 55   $     
Montserrat#��[ 56   $   $��20(�57   $   $��Center=�58   $   $��10,0,0,0q�59   $   5:      �� 5<      .+�5=      	�   
menuButton#��[ 6&    
 color1
 � Tag# [ 5>   &   .��5?      �� $ 
Horizontal=�6)   .+�5@   "   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6/    	 menuButtonIcon#��[	 6;   �� 5A   "   $��	Dashboard��6,    
 menuButtonText#��[
 6=   5C      5D      5E      5F      5G      �� 5J      $ 0, 10, 10, 0��6   $��1��5K      ��5L      �� 5M      $	 0,1&�6*   $	 1,0&�6;   .��5N      � # [ 6'   $	 0Q�6T   � 5O      # [ 6'   $	 1Q�6T   5P      5R      5U      5X      5Y      