   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Veterinaria_.Views_Menu_AdminVeterinaria_.Views_Menu_Admin  5      ;    5Veterinaria_.Views_Menu_Admin.Consultar_Recepcionista   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Veterinaria_.Views_Menu_Admin     5      
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$  GridConsultarRecepcionista��5      .+�5      �� $��0��6   $��Consultar Recepcionista��5      $��36(�5   5   $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,0,0,520q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��43,53,55,508q�62   $��2��6H   �� 5      $��Nombre��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��	49,88,0,0q�6y   $	��Top=�6�   $��26��6�   $��60��6�   �� 5      -   5         ��Name$ 
txt_Nombre��5      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��
114,92,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 5       $��Apellido��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��
43,124,0,0q�6{   $	��Top=�6�    J� RenderTransformOrigin$ -0.526,0.039&�6�   �� 5!      -   5        $ txt_Apellido��5!      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��114,131,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 5"      $��Telefono��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��
484,81,0,0q�6{   $	��Top=�6�   �� 5#      -   5        $ txt_Telefono��5#      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��
583,84,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 5$      $
��Sexo��6   ���#2D6E48$��14(�68   $��Segoe UI)�6F   $
��Left=�6\   $��496,131,0,0q�6w   $	��Top=�6�   �� 5%      -   5        $��cmb_Sexo��5%      $
��Left=�6'   $��583,131,0,0q�6B   $	��Top=�6W   $	��120��6o   .@�5&      �� .��6   	Masculino6*   �� 5'      .��6   
Femenino6)   �� 5(      .��6   Otros6&   5)      �� 5*      $��Fecha de nacimiento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��484,170,0,0q�6�   $	��Top=�6�   �� 5+      $��Tipo de documento��6   ���#2D6E48$��14(�6E   $��Segoe UI)�6S   $
��Left=�6i   $��
31,163,0,0q�6�   $	��Top=�6�   �� 5,      -   5        $��cmb_Tipo_documento��5,      $
��Left=�61   $��180,170,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�5-      �� .��6   Cedula6'   �� 5.      .��6   Targeta de indentidad66   �� 5/      .��6   Otros6&   50      �� 51      $��Numero de documento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��
31,210,0,0q�6�   $	��Top=�6�   �� 52      -   5        $ txt_Numero_documento��52      $��14(�64   $��Segoe UI)�6B   ���#E0F8E0���#2D6E48$
��Left=�6�   $��207,213,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��146��6�   $��22��6�   (  "System.Windows.Controls.DatePicker  53      -   5        $��	dtp_Fecha��53      $
��Left=�6*   $��643,175,0,0q�6E   $	��Top=�6Z   �� 54      $��Fecha de contrato��6   ���#2D6E48$��14(�6E   $��Segoe UI)�6S   $
��Left=�6i   $��492,204,0,0q�6�   $	��Top=�6�     55      -	   5        $��dtp_Fecha_contrato��55      $
��Left=�63   $��643,207,0,0q�6N   $	��Top=�6c   $	��171��6{   &   System.Windows.Controls.DataGrid  56      -
   5        $��dtg_Tabla_Recepcionistas��58      $��10,305,10,10q�57      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    SelectionMode$ Single=�5;         SelectionUnit$ FullRow=�5<      ���#2D6E48$��1q�5?         RowBackground �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5B         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�5D      $��14(�5E      
���   � � 	Resources 5H      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 5J      "  6   .�5K      ��  � �� �#2D6E4867   �� 5L       � ��
 �����67   �� 5M       � ��$
 Bold"�67   �� 5N       � ��$ 8q�64   �� 5O       � ��$ Center=�6G   5P      �� 5S      "  6   .�5T      ��  � ��$ 14(�65    5U      P� 5V       �@ 
IsSelected . . �5W   "   ��  � �� �#A8D5BA6?   �� 5X   "    � ��
 �   �6?   5Y      5[      5\         Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5`      $ Nombre��6)   $	 130 6T    69   �� *nombre+6T     5a      $ Apellido��6)   $	 130 6X    6;   �� *
apellido+6X     5b      $ 	Documento��6)   $	 100 6Z    6<   �� *	documento+6Z     5c      $ Tipo Documento��6)   $	 100 6d    6A   �� *tipo_documento+6d     5d      $
 Sexo��6)   $ 50 6P    67   �� *sexo+6P     5e      $ Fecha Nacimiento��6)   $	 125 6�    6C   �� *Fecha_nacimiento+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5f      $ Fecha Contrato��6)   $	 125 6�    6A   �� *fecha_contrato+$ {0:dd/MM/yyyy}��6�     5g      $ 	Teléfono��6)   $	 113 6X    6;   �� *
telefono+6X   5i      �� 5k      -   5         ��Name$ btn_Eliminar��5k      $��Eliminar��6+   
�������$��14(�6R   $��Segoe UI)�6`   $
��Bold"�6v   ���#2D6E48$
��Left=�6�   $��316,257,0,0q�6�   $	��Top=�6�   $��34��6  $��84��6  ��5l      �� 5m      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5n      � $ Black��6'   � 5o      $ 	#FF339A73��6'   $ 1Q�69   5p      5r      �� 5s      -   5        $ btn_Actualizar��5s      $��
Actualizar��6-   
�������$��14(�6V   $��Segoe UI)�6d   $
��Bold"�6z   ���#2D6E48$
��Left=�6�   $��433,257,0,0q�6�   $	��Top=�6�   $��34��6  $��82��6  ��5t      �� 5u      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5v      � $ Black��6'   � 5w      $ 	#FF339A73��6'   $ 1Q�69   5x      5z      �� 5{      $��Buscar��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��703,259,0,0q�6y   $	��Top=�6�   �� 5|      -   5        $ 
txt_Buscar��5|      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��772,267,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   5~      5      5�      