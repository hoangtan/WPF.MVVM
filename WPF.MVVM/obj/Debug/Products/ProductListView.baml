   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  5      C ?WPF.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF.MVVM.ProductsWPF.MVVM.Products 5      '   !WPF.MVVM.Products.ProductListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      @d2http://schemas.microsoft.com/expression/blend/2008      5      Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase      5      4productsclr-namespace:WPF.MVVM.Products      5      
�������  � 	Resources  5         SortedItems �� Source �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName   	Direction��%}   &	        �� 5   
    5      �� *Items+ 5        5      $
 Name��6&   $ 	Ascending=�6:   5      5      .��5      �� -   5         ��Name$ ProductsControl��5      ��.  %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�5      ��5      ��  �� Source# [  ��5      �� 	 �� RelativeSource	 �� *TemplatedParent+
 �� Path$
 ActualHeight���5      �� 	 �� *TemplatedParent+$
 ActualHeight���5      �� 	 �� *TemplatedParent+$
 ActualWidth���5   
   �� 5       .R�5!      $� 5"      ��5$   
   �� 5%      .R�5&      �� 
�������$��
0, 0, 0, 1q�61   ._�5'      '  !WPF.MVVM.Products.ProductListItem   � DataContext 6/   �� 5(      5)      ��5+   
   �� 5,      .R�5-      �� |�.  .��5.      ��  J� SnapsToDevicePixels# z 6%   5/      50      52      54      