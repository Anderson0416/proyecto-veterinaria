   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Veterinaria_.ViewsVeterinaria_.Views  5          Veterinaria_.Views.Compra   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Veterinaria_.Views     5      
������ $	��565��5      $	��925��6(   .��5
      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$ 
GridCompra��5      $��0,0,10,0q�6#    � ColumnDefinitions 5      �� 5      $
��467* �6#   �� 5      $
��407* �6#   .+�5      �� $��0��6   $��Compra��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $
��Left=�5      $��385,0,0,521q�6'   $��2��6<   $	��141��6P   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��43,53,55,508q�62   $��2��6H   �� 5       $��Producto��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��	82,94,0,0q�6{   $	��Top=�6�   $��1��6�   &   System.Windows.Controls.DataGrid  5!      -   5        $��dtg_Tabla_Producto��5"      $��43,81,0,364q�5!         AutoGenerateColumns .     
IsReadOnly . 	   SelectionMode$	 Single=�5%      
   SelectionUnit$
 FullRow=�5&      $
��Left=�5(      $	��464��5)      ���#2D6E48$��1q�5+         RowBackground �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5.         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�50      $��2��6#    � 	Resources 51      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 53      "  6   .�54      ��  � �� �#2D6E4867   �� 55       � ��
 �����67   �� 56       � ��$
 Bold"�67   �� 57       � ��$ 8q�64   �� 58       � ��$ Center=�6G   59      �� 5;      "  6   .�5<      ��  � ��$ 14(�65    5=      P� 5>       �@ 
IsSelected . . �5?   "   ��  � �� �#A8D5BA6?   �� 5@   "    � ��
 �   �6?   5A      5C      5D         Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5G      $ Nombre��6)   $	 200 6T    69   �� *nombre+6T     5H      $ Stock��6)   $	 100 6R    68   �� *stock+6R     5I      $ Precio��6)   $ 70 6l    69   �� *precio+ �� StringFormat$ {0:C}��6l   5K      �� 5M      $��Nombre��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��
43,229,0,0q�6y   $	��Top=�6�   �� 5N      -   5         ��Name$ 
txt_Nombre��5N      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��119,227,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��31��6�   �� 5O      $��Cantidad��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��348,229,0,0q�6{   $	��Top=�6�   �� 5P      -   5        $ txt_Cantidad��5P      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��453,233,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��129��6�   $��25��6�   $��2��6�   �� 5Q      -   5         ��Name$ btn_Agregar��5Q      $��Agregar��6*   
�������$��16(�6O   $��Segoe UI)�6]   $
��Bold"�6s   ���#2D6E48$
��Left=�6�   $��165,282,0,0q�6�   $	��Top=�6�   $��38��6�   $��94��6	  ��5R      �� 5S      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5T      � $ Black��6'   � 5U      $ 	#FF339A73��6'   $ 1Q�69   5V      5X        5Y      -   5        $��dtg_Tabla_Compra��5Z      $��43,369,0,73q�5Y       .   . $	 Single=�5]      $
 FullRow=�5^      $
��Left=�5`      $	��464��5a      ���#2D6E48$��1q�5c       �#F3F9F6 �#E3F2E9$ 
Horizontal=�5f       �#B5D6C6$	 All=�5h      $��2��6#    5i      ��%�  '        '  �     �� 5k      "  6   .�5l      ��  � �� �#2D6E4867   �� 5m       � ��
 �����67   �� 5n       � ��$
 Bold"�67   �� 5o       � ��$ 8q�64   �� 5p       � ��$ Center=�6G   5q      �� 5s      "  6   .�5t      ��  � ��$ 14(�65    5u      P� 5v       �@ 
IsSelected . . �5w   "   ��  � �� �#A8D5BA6?   �� 5x   "    � ��
 �   �6?   5y      5{      5|       5}        5~      $ ID��6)   $ 50 6U    65   �� *producto.id+6U     5      $ Nombre��6)   $	 200 6]    69   �� *producto.nombre+6]     5�      $ Cantidad��6)   $	 100 6X    6;   �� *
cantidad+6X     5�      $ 	Sub Total��6)   $ 70 6r    6<   �� *	sub_total+$ {0:C}��6r   5�      �� 5�      $��Total a pagar��6   ���#2D6E48$��14(�6A   $��Segoe UI)�6O   $
��Left=�6e   $��
74,507,0,0q�6�   $	��Top=�6�   �� 5�      -   5        $ 	txt_Total��5�      $��14(�6)   $��Segoe UI)�67   ���#E0F8E0���#2D6E48$
��Left=�6x   $��189,507,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��224��6�   $��29��6  �� 5�      -   5        $ 	btn_Pagar��5�      
�������$��16(�6;   $��Segoe UI)�6I   $
��Bold"�6_   ���#2D6E48$��Pagar��6�   $
��Left=�6�   $��204,335,0,0q�6�   $	��Top=�6�   $	��162��6�   $��36��6  $��1��6  ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ Black��6'   � 5�      $ 	#FF339A73��6'   $ 1Q�69   5�      5�      �� 5�      -	   5        $ txt_Buscar_Producto��5�      $��14(�63   $��Segoe UI)�6A   ���#E0F8E0���#2D6E48$
��Left=�6�   $��
54,128,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��150��6�   $��26��6  $��1��6+  �� 5�      -
   5        $ txt_Buscar_Compra��5�      $��14(�61   $��Segoe UI)�6?   ���#E0F8E0���#2D6E48$
��Left=�6�   $��124,340,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��128��6�   $��18��6  �� 5�      $��Compra��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��
43,335,0,0q�6y   $	��Top=�6�   �� 5�      -   5        $ 
txt_Borrar��5�      $��Borrar��6)   
�������$��16(�6M   $��Segoe UI)�6[   $
��Bold"�6q   ���#2D6E48$
��Left=�6�   $��319,283,0,0q�6�   $	��Top=�6�   $��37��6�   $��94��6  ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ Black��6'   � 5�      $ 	#FF339A73��6'   $ 1Q�69   5�      5�      �� 5�      -   5        $ btn_Imprimir_Factura��5�      $��Imprimir Factura��63   
�������$��16(�6a   $��Segoe UI)�6o   $
��Bold"�6�   ���#2D6E48$
��Left=�6�   $��204,395,0,0q�6�   $	��Top=�6�   $	��162��6�   $��48��6$  $��1��60  ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ Black��6'   � 5�      $ 	#FF339A73��6'   $ 1Q�69   5�      5�      5�      5�      5�      