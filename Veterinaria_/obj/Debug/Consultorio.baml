   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Veterinaria_Veterinaria_  5      �Eclr-namespace:Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion7Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion  5          Veterinaria_.Consultorio   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ,localclr-namespace:Veterinaria_     5      gConsultar_InformacionEclr-namespace:Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion     5      
������ $	��800��5      $	��600��5      .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6$��10q�64   ._�5   
   � -   5         �Name$ GridConsulta��5      .+�5      �� $��0��5      $��6��5      $��Consulta��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,10,0,20q�5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5       5"      �� 5%      $��Visible=�6   $��Disabled=�6A   $	��554��6j   $	��Top=�6w   .��5&      �� $
��1589��6   .+�5(      �� $��Información de Mascota��6   $
��10,5q�6?   ���#E0F8E0.��5)      �� .+�5*      �� $��
ID Mascota��6$   ���#2D6E48$��14(�6N   $��Segoe UI)�6\   �� 5+      -   5         ��Name$ txt_Id_Mascota��5+   &   $	��130��6>   $��Right=�6J   �� 5,      -   5        $��lb_Codigo_cita��5,   $   ���#2D6E48$��14(�6O   $��Segoe UI)�6]   $��Código de la Cita��6s   �� 5-      -   5        $ txt_Codigo_Cita��5-   &   $	��130��6?   $��Right=�6K   �� 5.      $��Nombre Mascota��6$   ���#2D6E48$��14(�6R   $��Segoe UI)�6`   �� 5/      -   5        $ txt_Nombre_Mascota��5/   &   $	��130��6B   $��Right=�6N   �� 50      -   5        $��lb_Descripcion��50   $   ���#2D6E48$��14(�6O   $��Segoe UI)�6]   $��Descripción��6s   �� 51      -   5        $ txt_Descripcion��51   &   $	��130��6?   $��Right=�6K   52      53      �� 56      $��Vacunas Previas��6   ���#2D6E48$��14(�6K   $��Segoe UI)�6Y   $��Center=�6o   $
��10,5q�6�   �� 57      -   5         ��Name$ cmb_Vacunas_Previas��57      $	��120��6<   $��Center=�6H   .@�58      �� .��6'   
*NO HAY*61   �� 59      .��6'   	Distemper62   �� 5:      .��6'   *Parvovirus*65   �� 5;      .��6'   Adenovirus tipo 16:   �� 5<      .��6'   Vanguard® -Plus 56:   �� 5=      .��6'   Nobivac® - Canine Flu H36A   �� 5>      .��6'   Vanguard® - CIV H3N2/H3N86B   5?      �� 5@      -	   5        $ txt_Vacunas_Previas��5@      $	��244��6;   $��Segoe UI)�6G   ���#E0F8E0���#2D6E48$	��100��6�   $��Center=�6�   $
��10,5q�6�    �� TextWrapping$
 Wrap=�6�   �� 5B      $(��"Vacunas Previas y Desparasitación��6   ���#2D6E48$��14(�6]   $��Segoe UI)�6k   $��Center=�6�   $
��10,5q�6�   �� 5C      -
   5        $) #cmb_Vacunas_Previas_Desparasitacion��5C      $	��120��6L   $��Center=�6X   .@�5D      �� .��6'   
*NO HAY*61   �� 5E      .��6'   Nobivac - DHPPi/L6:   �� 5F      .��6'   Eurican -DAPPi-L69   �� 5G      .��6'   Bronchicine - CAe6:   �� 5H      .��6'   Nobivac Tricat Trio6<   �� 5I      .��6'   Purevax - RCP66   �� 5J      .��6'   Filavac - VHD K + V6<   �� 5K      .��6'   Equivac - T64   5L      �� 5M      -   5        $) #txt_Vacunas_Previas_Desparasitacion��5M      $��Segoe UI)�6K   ���#E0F8E0���#2D6E48$	��244��6�   $	��100��6�   $��Center=�6�   $
��10,5q�6�   $
 Wrap=�6�   �� 5P      $��Información Adicional��6   $
��10,5q�6>   ���#f9f3f2.��5Q      �� .+�5R      �� $��Actividad Física��6$   ���#2D6E48$��14(�6T   $��Segoe UI)�6b   �� 5S      -   5        $ cmb_Actividad_Fisica��5S   '   $	��120��6E   $
��Left=�6Q   .@�5T   "   �� .��6/   Físicamente activo6C   �� 5U   "   .��6/   Físicamente inactivo6E   �� 5V   "   .��6/   
Sedentario6;   5W      �� 5X      $��Estado Reproductivo��6$   ���#2D6E48$��14(�6W   $��Segoe UI)�6e   �� 5Y      -   5        $ cmb_Estado_Reproductivo��5Y   '   $	��120��6H   $
��Left=�6T   .@�5Z   "   �� .��6/   	Intacto68   �� 5[   "   .��6/   Esterilizado6=   �� 5\   "   .��6/   
Castrado69   5]      �� 5^      $��Tipo de Vivienda��6$   ���#2D6E48$��14(�6T   $��Segoe UI)�6b   �� 5_      -   5        $ cmb_Tipo_Vivienda��5_   '   $	��120��6B   $
��Left=�6N   .@�5`   "   �� .��6/   Casa65   �� 5a   "   .��6/   Departamento6=   �� 5b   "   .��6/   	Callejero6:   �� 5c   "   .��6/   Finca66   5d      5e      5f      �� 5h      $��Consulta��6   $
��10,5q�61   ���#f9f3f2.��5i      �� .+�5j      �� $
��Peso��6$   ���#2D6E48$��14(�6H   $��Segoe UI)�6V   �� 5k      -   5        $ 	txt_Peso1��5k   &   $��Segoe UI)�69   ���#E0F8E0���#2D6E48$	��130��6z   $
��Left=�6�   �� 5l      -   5        $ 	txt_Peso2��5l   &   $��Segoe UI)�69   ���#E0F8E0���#2D6E48$	��130��6z   $
��Left=�6�   5m      5n      �� 5p      $��Motivo de la Consulta��6   ���#2D6E48$��14(�6Q   $��Segoe UI)�6_   $
��Left=�6u   $
��10,5q�6�   �� 5q      -   5        $ txt_Motivo_Consulta��5q      $��Segoe UI)�6;   ���#E0F8E0���#2D6E48$	��244��6|   $	��100��6�   $
��Left=�6�   $
 Wrap=�6�   $
��10,5q�6�   �� 5s      $��Síntomas de la Mascota��6   ���#2D6E48$��14(�6R   $��Segoe UI)�6`   $
��Left=�6v   $
��10,5q�6�   �� 5t      -   5        $ txt_Sintomas_Mascota��5t      $��Segoe UI)�6<   ���#E0F8E0���#2D6E48$	��244��6}   $	��100��6�   $
��Left=�6�   $
 Wrap=�6�   $
��10,5q�6�   �� 5v      $��Observaciones Adicionales��6   ���#2D6E48$��14(�6U   $��Segoe UI)�6c   $
��Left=�6y   $
��10,5q�6�   �� 5w      -   5        $# txt_Observaciones_Adicionales��5w      $��Segoe UI)�6E   ���#E0F8E0���#2D6E48$	��244��6�   $	��100��6�   $
��Left=�6�   $
 Wrap=�6�   $
��10,5q�6�   �� 5y      $��Dieta y Alimentación��6   ���#2D6E48$��14(�6P   $��Segoe UI)�6^   $
��Left=�6t   $
��10,5q�6�   �� 5z      -   5        $ txt_Dieta_Alimentacion��5z      $��Segoe UI)�6>   ���#E0F8E0���#2D6E48$	��244��6   $	��100��6�   $
��Left=�6�   $
 Wrap=�6�   $
��10,5q�6�   �� 5{      -   5        	 ��Name$	 btn_Guardar��5{      $��Guardar��62   
�������$��16(�6W   $��Segoe UI)�6e   $
��Bold"�6{   ���#2D6E48$��61��6�   $	��354��6�   ��5|      �� 5}      $ 0.5,1&�62   $ 0.5,0&�6C   .��5~   "   � $ Black��6/   � 5   "   $ 	#FF339A73��6/   $ 1Q�6A   5�      5�      �� 5�      -   5        $	 btn_Imprimir��5�      $��Imprimir��63   
�������$��16(�6Y   $��Segoe UI)�6g   $
��Bold"�6}   ���#2D6E48$��61��6�   $	��354��6�   ��5�      �� 5�      $ 0.5,1&�62   $ 0.5,0&�6C   .��5�   "   � $ Black��6/   � 5�   "   $ 	#FF339A73��6/   $ 1Q�6A   5�      5�      5�      5�      5�      5�      5�      