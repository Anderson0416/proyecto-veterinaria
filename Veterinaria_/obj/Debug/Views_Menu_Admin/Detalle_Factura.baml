   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Veterinaria_.Views_Menu_AdminVeterinaria_.Views_Menu_Admin  5   	   3    -Veterinaria_.Views_Menu_Admin.Detalle_Factura   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Veterinaria_.Views_Menu_Admin     5   	     � Title$  Detalle_Factura��5   	   $	��450��6!   $	��530��6.   .��5	      � .+�5
   
   �� $��0��6   $��DETALLE DE FACTURA��5      $��30(�5      $��Segoe UI)�5      $
��Bold"�5      $
��Left=�5      $��127,10,0,374q�6&   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FF339A73��6#    � Offset$ 1Q�65   5      5      �� 5   
   ���#2D6E48$��52,56,44,374q�6#   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtg_Tabla_Compra��5      $��54,119,54,129q�5         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         SelectionUnit$ FullRow=�5      ���#2D6E48$��1q�5!      	   RowBackground	 �#F3F9F6
   AlternatingRowBackground
 �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5$         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�5&      $��14(�5'      
���   � � 	Resources 5*      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 5,      "  6   .�5-      ��  � �� �#2D6E4863   �� 5.       � ��
 �����63   �� 5/       � ��$
 Bold"�63   �� 50       � ��$ 8q�60   �� 51       � ��$ Center=�6C   52      �� 55      "  6   .�56      ��  � ��$ 14(�61    57      P� 58       �@ 
IsSelected . . �59      ��  � �� �#A8D5BA6;   �� 5:       � ��
 �   �6;   5;      5=      5>         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *producto.id+6Q     5B      $ Nombre��6%   $	 140 6Y    65   �� *producto.nombre+6Y     5C      $ Cantidad��6%   $	 100 6T    67   �� *
cantidad+6T     5D      $ 	Sub Total��6%   $	 100 6n    68   �� *	sub_total+ �� StringFormat$ {0:C}��6n   5F      5H      5I      