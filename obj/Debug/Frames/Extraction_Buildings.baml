   M S B A M L   `   `   `  ����R  NSatisfactory Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Satisfactory_CalculatorSatisfactory_Calculator  5      2    ,Satisfactory_Calculator.Extraction_Buildings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Satisfactory_Calculator     5        N� FontSize$  16(�5       N� Title$ Extraction Buildings��5      .��5      � $
��Left=�6   $	��Top=�6&    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5"   
   �� $��0��6   $��0��6$   $��2��61   $��Add Extraction Building��6E   $��20(�6d   $��	Underline{�6r   �� 5#   
   $��0��6   $��1��6$   $��Extraction Building��61   �� 5$   
   -   5         ��Name$ 
CBBuilding��5$      $��0��6'   $��2��67   $	��250��6D   $��0,0,10,0q�6P   $
��Left=�6b   ��5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6!   .+�5(      �� $��30��6C   $��30��6N   ��6    ��  �� Path$ 
IVBuilding�6N   �� 5)      ��6$   �� $ 
TBBuilding�5*      5+      5-      �� 5.   
   $��1��6   $��1��6$   $
��Item��61   �� 5/   
   -   5        $ CBItem��5/      $��1��6#   $��2��63   $	��250��6@   $��0,0,10,0q�6L   $
��Left=�6^   ��50      �� 51      .R�52      �� $ 
Horizontal=�6!   .+�53      �� $��30��6?   $��30��6J   ��6    �� $ IVItem�6J   �� 54      ��6$   �� $ TBItem�55      56      58      �� 59   
   $��2��6   $��1��6$   $��Purity��61   �� 5:   
   -   5        $ CBPurity��5:      $��2��6%   $��2��65   $��2��6B   $	��250��6V   $��0,0,10,0q�6b   $
��Left=�6t   ��5;      �� 5<      .R�5=      �� $ 
Horizontal=�6!   .+�5>      �� $��30��6A   $��30��6L   ��6    �� $ IVPurity�6L   �� 5?      ��6$   �� $ TBPurity�5@      5A      5C      �� 5D   
   -   5         ��Name$$ ListViewAllExtractionBuildings��5D      $��0��6;   $��3��6K   $��4��6X   $	��800��6l   $	��200��6x   $��
0,10,10,10q�6�    �� View 5E      �� 5F      P�5G      �� 5H      $��Building��6)   	 �� Width$		 150��6;   
 �� CellTemplate
 5I      �� 5J   "   .R�5K   &   �� $ 
Horizontal=�61   .+�5L   *   �� ��64   �� $ 
TBBuilding��� 5M   *   $��30��6S   $��30��6^   ��60   �� $ 
IVBuilding�6^   �� 5N   *   ��64   �� $ TBBuildingCode�5O   '   5P   #   5R      �� 5S      $
��Name��6)   $		 310��67   
 5T      �� 5U   "   .R�5V   &   �� ��60   �� $ TBName�5W   #   5Y      �� 5Z      $��Produce��6)   $		 156��6:   
 5[      �� 5\   "   .R�5]   &   �� $ 
Horizontal=�61   y�6J   �� $ 	SPProduce���6p   �� $ HProduce�.+�5^   *   �� ��64   �� $ 	TBProduce��� 5_   *   $��30��6R   $��30��6]   $��0,0,10,0q�6i   ��60   �� $ 	IVProduce�6i   5`   '   5a   #   5c      �� 5d      $��Purity��6)   $		 156��69   
 5e      �� 5f   "   .R�5g   &   �� ��60   �� $ TBPurity�5h   #   5j      5l      5n      �� 5o   
   -   5         ��Name$ BtnAddBuilding��5o      $��0��6)   $��4��69   $��Add Building��6F   $��30��6z   �� 5p   
   $��0��6   $��5��6$   $��2��61   $��Edit Extraction Building��6E   $��20(�6e   $��	Underline{�6s   �� 5q   
   $��0��6   $��6��6$   $��Extraction Building��61   �� 5r   
   -   5        $ CBMyBuilding��5r      $��0��6)   $��7��69   $	��250��6F   $��0,0,10,0q�6R   $
��Left=�6d   ��5s      �� 5t      .R�5u      �� $ 
Horizontal=�6!   .+�5v      �� $��30��6E   $��30��6P   ��6    �� $ IVMyBuilding�6P   �� 5w      ��6$   �� $ TBMyBuilding�5x      5y      5{      �� 5|   
   $��1��6   $��6��6$   $
��Item��61   �� 5}   
   -   5        $ CBMyItem��5}      $��1��6%   $��7��65   $	��250��6B   $��0,0,10,0q�6N   $
��Left=�6`   ��5~      �� 5      .R�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��30��6A   $��30��6L   ��6    �� $ IVMyItem�6L   �� 5�      ��6$   �� $ TBMyItem�5�      5�      5�      �� 5�   
   $��2��6   $��6��6$   $��Divided��61   �� 5�   
   -   5        $ CBMyDivided��5�      $��2��6(   $��7��68   $	��135��6E   $��0,0,10,0q�6Q   $
��Left=�6c   ��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��30��6D   $��30��6O   ��6    �� $ IVMyDivided�6O   �� 5�      ��6$   �� $ TBMyDivided�5�      5�      5�      �� 5�   
   $��3��6   $��6��6$   $��Purity��61   �� 5�   
   -	   5        $ 
CBMyPurity��5�      $��3��6'   $��7��67   $	��135��6D   $��0,0,10,0q�6P   $
��Left=�6b   ��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��30��6C   $��30��6N   ��6    �� $ 
IVMyPurity�6N   �� 5�      ��6$   �� $ 
TBMyPurity�5�      5�      5�      �� 5�   
   -
   5        $# ListViewMyExtractionBuildings��5�      $��0��6:   $��8��6J   $��4��6W   $	��800��6k   $	��200��6w   $��
0,10,10,10q�6�    5�      �� 5�      P�5�      �� 5�      $��Building��6)   $		 150��6;   
 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� ��64   �� $ 
TBBuilding��� 5�   *   $��30��6S   $��30��6^   ��60   �� $ 
IVBuilding�6^   �� 5�   *   ��64   �� $ TBBuildingCode�5�   '   5�   #   5�      �� 5�      $
��Name��6)   $		 256��67   
 5�      �� 5�   "   .R�5�   &   �� ��60   �� $ TBName�5�   #   5�      �� 5�      $��Working��6)   $	 75��6:   
 5�      �� 5�   "   .R�5�   &   �� ��60   �� $ 	TBWorking�5�   #   5�      �� 5�      $��Produce��6)   $		 146��6:   
 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   y�6J   �� $ 	SPProduce���6p   �� $ HProduce�.+�5�   .   �� ��68   �� $ 	TBProduce��� 5�   .   $��30��6V   $��30��6a   $��0,0,10,0q�6m   ��64   �� $ 	IVProduce�6m   5�   +   5�   #   5�      �� 5�      $��Purity��6)   $		 146��69   
 5�      �� 5�   "   .R�5�   &   �� ��60   �� $ TBPurity�5�   #   5�      5�      5�      �� 5�   
   -   5        $ BtnRemoveBuilding��5�      $��0��6,   $��9��6<   $��Remove Building��6I   6c   �� 5�   
   $��1��6   $��9��6$   $��
Working at��61   $��20(�6C    �� TextAlignment$ Right=�6Q   $��0,0,10,0q�6g   �� 5�   
   $ 
Horizontal=�6   $��2��6.   $��9��6>   $��2��6K   .+�5�      �� -   5        $ BtnRemovePercentage��5�      $��30��6T   $��30��6_   .��5�      �� $��/Img/Img_Other/Minus.png��6   $��15��6:   5�      �� 5�      -   5         ��Name$ TBPercentage��5�      $��20(�6.   $��75��6<   $ Center=�6G   �� 5�      -   5        $ BtnAddPercentage��5�      $��30��6N   $��30��6Y   .��5�      �� $��/Img/Img_Other/Plus.png��6   $��15��69   5�      5�      5�      5�      