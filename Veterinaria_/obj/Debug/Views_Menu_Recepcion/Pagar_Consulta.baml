   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Veterinaria_.Views_Menu_Recepcion!Veterinaria_.Views_Menu_Recepcion  5   	   6    0Veterinaria_.Views_Menu_Recepcion.Pagar_Consulta   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Veterinaria_.Views_Menu_Recepcion     5   	   
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$ GridPagarConsulta��5       � ColumnDefinitions 5      �� 5      $
��743* �6#   �� 5      $
��182* �6#   .+�5      �� $��0��6   $��Pagar Consulta��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $
��Left=�5      $��346,2,0,492q�6,   $	��268��6A   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'    � Offset$ 0.017Q�65   � 5      $ 	#FF339A73��6'   $ 1Q�69   5       5"      �� 5#      ���#2D6E48$��4��6'   $��43,53,55,492q�62   $��2��6H   �� 5$      ���#2D6E48$��4��6'   $��225,288,59,257q�62    J� RenderTransformOrigin$ 0.5,0.5&�6J   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)       �� Angle$ 90.387Q�6*   T� 5*      5+      5-      �� 5.      $��Id De la Cita��6   ���#2D6E48$��14(�6A   $��Segoe UI)�6O   $
��Left=�6e   $��	76,90,0,0q�6�   $	��Top=�6�   �� 5/      -   5        	 ��Name$	 txt_Id_Cita��5/      $��14(�6+   $��Segoe UI)�69   ���#E0F8E0���#2D6E48$
��Left=�6z   $��
182,97,0,0q�6�   
 �� TextWrapping$

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 50      $��Nombre Del Propietario��6   ���#2D6E48$��14(�6J   $��Segoe UI)�6X   $
��Left=�6n   $��
76,122,0,0q�6�   $	��Top=�6�   �� 51      -   5        $	 txt_Nombre_Propietario��51      $��14(�66   $��Segoe UI)�6D   ���#E0F8E0���#2D6E48$
��Left=�6�   $��239,130,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 52      $��Mascota��6   ���#2D6E48$��14(�6;   $��Segoe UI)�6I   $
��Left=�6_   $��
76,151,0,0q�6z   $	��Top=�6�   �� 53      $��Fecha de la consulta��6   ���#2D6E48$��14(�6H   $��Segoe UI)�6V   $
��Left=�6l   $��
70,187,0,0q�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  54      -   5        $��dtp_Fecha_Consulta��54      $
��Left=�63   $��226,192,0,0q�6N   $	��Top=�6c   �� 55      $��nombre del veterinario��6   ���#2D6E48$��14(�6J   $��Segoe UI)�6X   $
��Left=�6n   $��
70,221,0,0q�6�   $	��Top=�6�   �� 56      $��Descripcion��6   ���#2D6E48$��14(�6?   $��Segoe UI)�6M   $
��Left=�6c   $��37,0,0,0q�6~   $��Center=�6�   �� 57      -   5        $	 txt_Descripcion_Consulta��57      $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��
78,306,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��244��6�   $	��160��6�   �� 58      -   5         ��Name$ btn_Pagar_Consulta��58      $��Pagar Consulta��61   
�������$��16(�6]   $��Segoe UI)�6k   $
��Bold"�6�   ���#2D6E48$
��Left=�6�   $��643,460,0,0q�6�   $	��Top=�6�   $��32��6  $	��128��6  $��2��6*  ��59      �� 5:      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5;      � $ Black��6'   � 5<      $ 	#FF339A73��6'   $ 1Q�69   5=      5?      �� 5@      -   5        $��txt_Nombre_Mascota��5@      $��14(�60   $��Segoe UI)�6>   ���#E0F8E0���#2D6E48$
��Left=�6   $��178,159,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $ 0.517,-0.386&�6�   �� 5A      -   5        $	 txt_Nombre_Veterinario��5A      $��14(�66   $��Segoe UI)�6D   ���#E0F8E0���#2D6E48$
��Left=�6�   $��238,229,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5B      -	   5        $��dtg_Tabla_Tipo_Consulta��5C      $��531,235,42,146q�5B         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5F         SelectionUnit$ FullRow=�5G      $��2��5H      ���#2D6E48$��1q�5J         RowBackground �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5M         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�5O       � 	Resources 5P      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 5R      "  6   .�5S      ��  � �� �#2D6E4867   �� 5T       � ��
 �����67   �� 5U       � ��$
 Bold"�67   �� 5V       � ��$ 8q�64   �� 5W       � ��$ Center=�6G   5X      �� 5Z      "  6   .�5[      ��  � ��$ 14(�65    5\      P� 5]       �@ 
IsSelected . . �5^   "   ��  � �� �#A8D5BA6?   �� 5_   "    � ��
 �   �6?   5`      5b      5c         Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5e      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5f      $ Nombre��6)   $	 200 6b    69   �� *tipo_consulta.nombre+6b     5g      $ Precio��6)   $	 100 6z    69   �� *tipo_consulta.precio+  �� StringFormat$  {0:C}��6z   5i      �� 5k      $��Total a pagar��6   ���#2D6E48$��14(�6A   $��Segoe UI)�6O   $
��Left=�6e   $��
549,99,0,0q�6�   $	��Top=�6�   �� 5l      -
   5        $	 txt_Total_Pagar��5l      $��14(�6/   $��Segoe UI)�6=   ���#E0F8E0���#2D6E48$
��Left=�6~   $��657,107,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $ 
3.3,-8.194&�6�   $��2��6  �� 5m      $��Recibo��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��553,133,0,0q�6y   $	��Top=�6�   �� 5n      -   5        $	 
txt_Recibo��5n      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��657,141,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $��2��6  �� 5o      $��El cambio es��6   ���#2D6E48$��14(�6@   $��Segoe UI)�6N   $
��Left=�6d   $��552,169,0,0q�6   $	��Top=�6�   �� 5p      -   5        $	 
txt_Cambio��5p      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��657,181,0,0q�6�   $

 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $��2��6�   5r      5s      5u      