   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Veterinaria_.Views_Menu_AdminVeterinaria_.Views_Menu_Admin  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      ,    &Veterinaria_.Views_Menu_Admin.Facturas   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Veterinaria_.Views_Menu_Admin     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$ GridFacturas��5      .+�5      �� $��0��6   $��Facturas��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,0,0,514q�6)   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��52,56,44,505q�62   �� 5      -   5        $��cmb_Filtro_mes��5      $
��Left=�6-   $��552,372,0,0q�6H   $	��Top=�6]   $	��120��6u   6�   (  "System.Windows.Controls.DatePicker  5       -   5        $��dtp_Filtrar_Fecha��5       $
��Left=�62   $��
52,138,0,0q�6M   $	��Top=�6a   $	��170��6y   6�   &   System.Windows.Controls.DataGrid  5!      -   5        $��dtg_Tabla_Compra��5#      $��
0,81,0,306q�5"         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5&      	   SelectionUnit$	 FullRow=�5'      $��Center=�5)      $	��420��5*      ���#2D6E48$��1q�5,      
   RowBackground
 �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5/         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�51      $��14(�52      
���   � � 	Resources 55      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 57      "  6   .�58      ��  � �� �#2D6E4867   �� 59       � ��
 �����67   �� 5:       � ��$
 Bold"�67   �� 5;       � ��$ 8q�64   �� 5<       � ��$ Center=�6G   5=      �� 5@      "  6   .�5A      ��  � ��$ 14(�65    5B      P� 5C       �@ 
IsSelected . . �5D   "   ��  � �� �#A8D5BA6?   �� 5E   "    � ��
 �   �6?   5F      5H      5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5M      $ Fecha de la factura��6)   $	 200 6�    6F   �� *fecha+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5N      $ Total��6)   $	 100 6j    68   �� *total+$ {0:C}��6j   5P      �� 5R      $��Filtrar por mes��6   ���#2D6E48$��14(�6C   $��Segoe UI)�6Q   $
��Left=�6g   $��
83,104,0,0q�6�   $	��Top=�6�   #	  LiveCharts.Wpf.CartesianChart	  5S      $��234,282,234,31q�6!   
�������&
   LiveCharts.Wpf.Charts.Base.Chart 
  Series 5U      �� *SeriesCollection+ 
  AxisX 5W        LiveCharts.Wpf.Axis     Title$ Meses��6      Labels 5X      �� *Meses+ 
  AxisY 5[        $ Total Ventas��6       MinValue$  0Q�5]      !   MaxValue$! 700000Q�5^      "   LabelFormatter" 5\      �� *	Formatter+#   	Separator# 5_        LiveCharts.Wpf.Separator  5`      $   Step$$ 50000Q�6,   5b      5d      5f      5g      5i      