   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Veterinaria_.Views_Menu_AdminVeterinaria_.Views_Menu_Admin  5      ;    5Veterinaria_.Views_Menu_Admin.Registrar_Tipo_Consulta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Veterinaria_.Views_Menu_Admin     5      
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$ GridRegistrarTipoConsulta��5      .+�5      �� $��0��6   $��Registrar Tipo Consulta��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,0,0,511q�6)   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��52,56,44,505q�62   �� 5      $��Nombre��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��
87,168,0,0q�6y   $	��Top=�6�   �� 5      -   5         ��Name$ 
txt_Nombre��5      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��167,172,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5       $��Descripcion��6   ���#2D6E48$��14(�6?   $��Segoe UI)�6M   $
��Left=�6c   $��305,168,0,0q�6~   $	��Top=�6�   �� 5!      -   5        $ txt_Descripcion��5!      $��14(�6/   $��Segoe UI)�6=   ���#E0F8E0���#2D6E48$
��Left=�6~   $��391,172,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5"      $��Precio��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��546,168,0,0q�6y   $	��Top=�6�   �� 5#      -   5        $ 
txt_Precio��5#      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��620,168,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5$      $��Codigo del producto : ��6   ���#2D6E48$��14(�6J   $��Segoe UI)�6X   $
��Left=�6n   $��
95,105,0,0q�6�   $	��Top=�6�   �� 5%      -   5        $��lb_Id��5%      $�� ��6!   $
��Left=�6,   $��249,105,0,0q�6G   $	��Top=�6\   �� 5&      $��Busqueda��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��666,243,0,0q�6{   $	��Top=�6�   �� 5'      -   5        $ 
txt_buscar��5'      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��761,248,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   &   System.Windows.Controls.DataGrid  5(      -   5        $��dtg_Tabla_Tipo_Consulta��5*      $��10,305,10,10q�5)         AutoGenerateColumns .  	   
IsReadOnly	 . 
   SelectionMode$
 Single=�5-         SelectionUnit$ FullRow=�5.      ���#2D6E48$��1q�51         RowBackground �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�54         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�56      $��14(�57      
���   � � 	Resources 5:      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 5<      "  6   .�5=      ��  � �� �#2D6E4867   �� 5>       � ��
 �����67   �� 5?       � ��$
 Bold"�67   �� 5@       � ��$ 8q�64   �� 5A       � ��$ Center=�6G   5B      �� 5E      "  6   .�5F      ��  � ��$ 14(�65    5G      P� 5H       �@ 
IsSelected . . �5I   "   ��  � �� �#A8D5BA6?   �� 5J   "    � ��
 �   �6?   5K      5M      5N         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5R      $ Nombre��6)   $	 200 6T    69   �� *nombre+6T     5S      $ Descripción��6)   $	 420 6^    6>   �� *descripcion+6^     5T      $ Precio��6)   $	 150 6l    69   �� *precio+ �� StringFormat$ {0:C}��6l   5V      �� 5X      -   5         ��Name$ btn_Guardar��5X      $��Guardar��6*   
�������$��14(�6O   $��Segoe UI)�6]   $
��Bold"�6s   ���#2D6E48$
��Left=�6�   $��190,257,0,0q�6�   $	��Top=�6�   $��33��6�   $��74��6	  ��5Y      �� 5Z      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5[      � $ Black��6'   � 5\      $ 	#FF339A73��6'   $ 1Q�69   5]      5_      �� 5`      -	   5        $ btn_Eliminar��5`      $��Eliminar��6+   
�������$��14(�6Q   $��Segoe UI)�6_   $
��Bold"�6u   ���#2D6E48$
��Left=�6�   $��295,257,0,0q�6�   $	��Top=�6�   $��33��6   $��76��6  ��5a      �� 5b      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5c      � $ Black��6'   � 5d      $ 	#FF339A73��6'   $ 1Q�69   5e      5g      �� 5h      -
   5        $ btn_Actualizar��5h      $��
Actualizar��6-   
�������$��14(�6U   $��Segoe UI)�6c   $
��Bold"�6y   ���#2D6E48$
��Left=�6�   $��408,257,0,0q�6�   $	��Top=�6�   $��33��6  $��86��6  ��5i      �� 5j      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5k      � $ Black��6'   � 5l      $ 	#FF339A73��6'   $ 1Q�69   5m      5o      5q      5r      5t      