   M S B A M L   `   `   `  ����R  NSatisfactory Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Satisfactory_CalculatorSatisfactory_Calculator  5   	   (    "Satisfactory_Calculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Satisfactory_Calculator     5   	   $��18(�5   	     � Title$  Satisfactory Calculator��5	   	   $	��785��6)   $
��1380��66   $	��785��6C   $
��1380��6S   $��Bernard MT Condensed)�6c   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $	��Top=�6K   .+�5      �� -   5        $��Extraction Buildings��5      $��0,0,10,0q�6Z   $	��150��6l   �� 5      -   5        $��Production Buildings��5      $��0,0,10,0q�6Z   $	��150��6l   �� 5      -   5        $��
Generators��5      $��0,0,10,0q�6F   $	��150��6X   �� 5      -   5        $��Vehicles��5      $��0,0,10,0q�6B   $	��150��6T   5       � 5   
   -   5          �Name$ 
Main_Frame��5   -   $��1��6   $��2��6    $��0,10,0,0q�6A     � NavigationUIVisibility$ Hidden=�6S   �� 5   
   -   5         ��Name$ ListViewInfo��5      $��2��6)   $��1��69   $��2��6F    �� View 5      �� 5       P�5!      �� 5"      $��Building��6)    �� Width$	 500��6;   	 �� CellTemplate	 5#      �� 5$   "   .R�5%   &   �� $ 
Horizontal=�61   .+�5&   *   �� $��0,0,10,0q�6Q   ��64   �� 
 �� Path$
 TBName�6Q   �� 5'   *   $��50��6N   $��50��6Y   $��0,0,10,0q�6f   ��60   �� $
 IVImg�6f   5(   '   5)   #   5+      5-      5/      50      51      