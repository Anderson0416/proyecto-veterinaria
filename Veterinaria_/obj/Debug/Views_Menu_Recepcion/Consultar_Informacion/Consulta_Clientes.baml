   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Veterinaria_.ViewsVeterinaria_.Views  5      *    $Veterinaria_.Views.Consulta_Clientes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Veterinaria_.Views     5      
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$ GridConsultarPropietario��5      .+�5      �� $��0��6   $+��%Consultar informacion del Propietario��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,0,0,522q�66   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��43,53,55,508q�62   $��2��6H   �� 5      $��ID��6   ���#2D6E48$��14(�66   $��Segoe UI)�6D   $
��Left=�6Z   $��
118,81,0,0q�6u   $	��Top=�6�   �� 5      -   5        $��lb_Id��5      $�� ��6!   $
��Left=�6,   $��
145,81,0,0q�6G   $	��Top=�6[   �� 5       $��Nombre��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��118,124,0,0q�6y   $	��Top=�6�   �� 5!      -   5         ��Name$ 
txt_Nombre��5!      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��184,133,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.508,0.485&�6�   �� 5"      $��Apellido��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��117,162,0,0q�6{   $	��Top=�6�   �� 5#      -   5        $ txt_Apellido��5#      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��184,166,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5$      $��Fecha de nacimiento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��
484,87,0,0q�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5%      -   5        $��	dtp_Fecha��5%      $
��Left=�6*   $��
633,92,0,0q�6E   $	��Top=�6Y   �� 5&      $��Telefono��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��484,154,0,0q�6{   $	��Top=�6�   $ 0.255,-1.468&�6�   �� 5'      -   5        $ txt_Telefono��5'      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��553,158,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $ 0.458,0.533&�6  �� 5(      $
��Sexo��6   ���#2D6E48$��14(�68   $��Segoe UI)�6F   $
��Left=�6\   $��484,121,0,0q�6w   $	��Top=�6�   $ 0.559,0.105&�6�   $��33��6�   �� 5)      -   5        $��cmd_Sexo��5)      $
��Left=�6'   $��553,126,0,0q�6B   $	��Top=�6W   $	��120��6o   .@�5*      �� .��6   	Masculino6*   �� 5+      .��6   
Femenino6)   �� 5,      .��6   Otros6&   5-      �� 5.      $��Tipo de documento��6   ���#2D6E48$��14(�6E   $��Segoe UI)�6S   $
��Left=�6i   $��118,200,0,0q�6�   $	��Top=�6�   �� 5/      -   5        $��cmb_Tipo_documento��5/      $
��Left=�61   $��254,204,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�50      �� .��6   Cedula6'   �� 51      .��6   Targeta de indentidad66   �� 52      .��6   Otros6&   53      �� 54      $��Numero de documento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��117,233,0,0q�6�   $	��Top=�6�   �� 55      -	   5        $ txt_Numero_documento��55      $��14(�64   $��Segoe UI)�6B   ���#E0F8E0���#2D6E48$
��Left=�6�   $��277,241,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  56      -
   5        $��dtg_Tabla_propietarios��57      $��10,305,10,10q�56      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    SelectionMode$ Single=�5:         SelectionUnit$ FullRow=�5;      ���#2D6E48$��1q�5>         RowBackground �#F3F9F6   AlternatingRowBackground �#E3F2E9   GridLinesVisibility$ 
Horizontal=�5A         HorizontalGridLinesBrush �#B5D6C6   HeadersVisibility$	 All=�5C       � 	Resources 5D      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  '        '  �     �� 5F      "  6   .�5G      ��  � �� �#2D6E4867   �� 5H       � ��
 �����67   �� 5I       � ��$
 Bold"�67   �� 5J       � ��$ 8q�64   �� 5K       � ��$ Center=�6G   5L      �� 5N      "  6   .�5O      ��  � ��$ 14(�65    5P      P� 5Q       �@ 
IsSelected . . �5R   "   ��  � �� �#A8D5BA6?   �� 5S   "    � ��
 �   �6?   5T      5V      5W         Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+6L     5Z      $ Nombre��6)   $	 100 6T    69   �� *nombre+6T     5[      $ Apellido��6)   $	 100 6X    6;   �� *
apellido+6X     5\      $ Correo��6)   $	 130 6T    69   �� *correo+6T     5]      $ 	Documento��6)   $	 120 6Z    6<   �� *	documento+6Z     5^      $ Tipo Documento��6)   $	 110 6d    6A   �� *tipo_documento+6d     5_      $
 Sexo��6)   $ 70 6P    67   �� *sexo+6P     5`      $ Fecha Nacimiento��6)   $	 125 6�    6C   �� *Fecha_nacimiento+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5a      $ 	Teléfono��6)   $	 100 6X    6;   �� *
telefono+6X   5c      �� 5e      -   5         ��Name$ btn_Actualizar��5e      $��
Actualizar��6-   
�������$��14(�6U   $��Segoe UI)�6c   $
��Bold"�6y   ���#2D6E48$
��Left=�6�   $��504,251,0,0q�6�   $	��Top=�6�   $��28��6  $��73��6  ��5f      �� 5g      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5h      � $ Black��6'   � 5i      $ 	#FF339A73��6'   $ 1Q�69   5j      5l      �� 5m      -   5        $ btn_Eliminar��5m      $��Eliminar��6+   
�������$��14(�6Q   $��Segoe UI)�6_   $
��Bold"�6u   ���#2D6E48$
��Left=�6�   $��625,251,0,0q�6�   $	��Top=�6�   $��28��6   $��75��6  ��5n      �� 5o      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5p      � $ Black��6'   � 5q      $ 	#FF339A73��6'   $ 1Q�69   5r      5t      �� 5u      $��Buscar��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��761,245,0,0q�6y   $	��Top=�6�   �� 5v      -   5        $ 
txt_Buscar��5v      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��	800,0,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��105��6�   6�   �� 5w      $��Correo electronico��6   ���#2D6E48$��14(�6F   $��Segoe UI)�6T   $
��Left=�6j   $��484,188,0,0q�6�   $	��Top=�6�   �� 5x      -   5        $ 
txt_Correo��5x      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��618,194,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��164��6�   5z      5{      5}      