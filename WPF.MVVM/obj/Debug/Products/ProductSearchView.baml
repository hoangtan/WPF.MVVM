   M S B A M L   `   `   `  ����  WPF.MVVM)    #WPF.MVVM.Products.ProductSearchView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � 	Resources  5         BooleanToVisibility  CustomGrayColour �� Color  ClearButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName  SearchBorderStyle �� EndPoint � Color � Offset  SearchTermTextBoxStyle��%^  &	        &	      &	 9     &	 �    7  &	 �    7  �� 5   
   6'   �� 5   
   $ #808080��63   6E   �� 5   
   " ��5	      .�5
      ��  � ��$ 
0, 0, 4, 0q�5      �� 5       � ��$ Right=�5      �� 5       �@�OverridesDefaultStyle . 5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Border��6!   ���#888888$ 15��5   !   $��14��5   !   $��Right=�5   !   $��14��5   !   ._�5      �� $��9(�6(   $��SemiBold"�5   (   
�������$��Center=�5   (   $��0, -1, 0, 0q�5   (   $��X��5   (   $��Center=�5   (   5        5!      P� 5"      	 �@J�IsMouseOver
 . . �5$   "   �� $ Border��6)    � �� �#6666665&   )   5'      5)      5+      5,      �� 5-   
   " ��5.      .�5/      ��  � �� 50      �� 51      $	 0,1&�6*   .��52      � $ #C3C3C3��6'   $ 0Q�67   � 53      $ #FDFDFD��6'   $ 1Q�67   54      56      �� 57       � ��8   58      �� 59       � ��$ 1q�5:      �� 5;       �@��CornerRadius$ 5��5<      �� 5=       �@��Padding$ 
7, 3, 3, 4q�5>      �� 5?       � ��$ Center=�5@      5A      �� 5B   
   " ��5C      .�5D      ��  � ��
 ���� 5E      �� 5F       � ��$ 0q�5G      �� 5H       � ��$ Italic$�5I      �� 5J       � ��8   5K      �� 5L       � ��$ Stretch=�5M      �� 5N       � ��$ 0q�5O      �� 5P       �@��TextWrapping$ NoWrap=�5Q      �� 5R       � ��$ Center=�5S      5T      5U      .��5W      �� #��[ 6   ._�5X   
   � $	��150��6   ��5Y      ��  �� RelativeSource �� *TemplatedParent+ �� Path$ ActualWidth� � ColumnDefinitions 5Z      �� 5[      $��* �6#   �� 5\      $
��Auto �6#   .+�5^      �� -   5         ��Name$ SearchTermTextBox��5^      $��0��5`      #��[ 5b      ��5c      �� *
SearchTerm+ �� UpdateSourceTrigger$ PropertyChanged=�.��6W   5d      �� 5e      -   5         ��Name$ ClearButton��5e      $��1��5g      #��[ 5i      ��5f      �� *ClearCommand+{�5h      �� *HasSearchTerm+y�5j      �� *HasSearchTerm+ �� 	Converter# [  5k      �� 5l      -   5        $ SearchButton��5l      $��Go��5n      $��1��5o      $y�	Collapsed=�5q      ��5m      �� *SearchCommand+{�5p      �� *HasSearchTerm+5r      5s      5t      5u      