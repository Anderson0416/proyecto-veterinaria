   M S B A M L   `   `   `  ����G  CVeterinaria_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Veterinaria_.Views_Menu_AdminVeterinaria_.Views_Menu_Admin  5      ;    5Veterinaria_.Views_Menu_Admin.Registrar_Recepcionista   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Veterinaria_.Views_Menu_Admin     5      
������ .��5      ��   �� CornerRadius$  10��6   ���#b6e8c6._�5   
   � -   5         �Name$  GridRegistrarRecepcionista��5      .+�5      �� $��0��6   $��Registrar Recepcionista��5      $��36(�5      $��Segoe UI)�5      $
��Bold"�5      $��Center=�5      $��	0,0,0,506q�6-   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ Black��6'   � 5      $ 	#FF339A73��6'    � Offset$ 1Q�69   5      5      �� 5      ���#2D6E48$��4��6'   $��52,56,44,505q�62   �� 5      ���#2D6E48$��4��5       $��Center=�5!      $	��Top=�5"      $��	0,251,0,0q�5#      $	��385��5$       J� RenderTransformOrigin$ 0.5,0.5&�6   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)       �� Angle$ 90.939Q�6*   T� 5*      5+      5-      �� 5/      $��Nombre��6   ���#2D6E48$��14(�6:   $��Segoe UI)�6H   $
��Left=�6^   $��
52,236,0,0q�6y   $	��Top=�6�   $��26��6�   $��60��6�   �� 50      -   5         ��Name$ 
txt_Nombre��50      $��14(�6*   $��Segoe UI)�68   ���#E0F8E0���#2D6E48$
��Left=�6y   $��140,240,0,0q�6�   	 �� TextWrapping$
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 51      $��Apellido��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��
52,282,0,0q�6{   $	��Top=�6�   $ -0.526,0.039&�6�   �� 52      -   5        $ txt_Apellido��52      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��140,285,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 53      $��Telefono��6   ���#2D6E48$��14(�6<   $��Segoe UI)�6J   $
��Left=�6`   $��
52,326,0,0q�6{   $	��Top=�6�   �� 54      -   5        $ txt_Telefono��54      $��14(�6,   $��Segoe UI)�6:   ���#E0F8E0���#2D6E48$
��Left=�6{   $��140,329,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   �� 55      $
��Sexo��6   ���#2D6E48$��14(�68   $��Segoe UI)�6F   $
��Left=�6\   $��
52,366,0,0q�6w   $	��Top=�6�   �� 56      -   5        $��cmb_Sexo��56      $
��Left=�6'   $��140,369,0,0q�6B   $	��Top=�6W   $	��120��6o   .@�57      �� .��6   	Masculino6*   �� 58      .��6   
Femenino6)   �� 59      .��6   Otros6&   5:      �� 5;      $��Fecha de nacimiento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��540,129,0,0q�6�   $	��Top=�6�   �� 5<      $��Tipo de documento��6   ���#2D6E48$��14(�6E   $��Segoe UI)�6S   $
��Left=�6i   $��
52,152,0,0q�6�   $	��Top=�6�   �� 5=      -   5        $��cmb_Tipo_documento��5=      $
��Left=�61   $��206,155,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�5>      �� .��6   Cedula6'   �� 5?      .��6   Targeta de indentidad66   �� 5@      .��6   Otros6&   5A      �� 5B      $��Numero de documento��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��
52,192,0,0q�6�   $	��Top=�6�   �� 5C      -   5        $ txt_Numero_documento��5C      $��14(�64   $��Segoe UI)�6B   ���#E0F8E0���#2D6E48$
��Left=�6�   $��207,195,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��186��6�   $��22��6�   (  "System.Windows.Controls.DatePicker  5D      -   5        $��	dtp_Fecha��5D      $
��Left=�6*   $��714,129,0,0q�6E   $	��Top=�6Z   �� 5E      $��Fecha de contrato��6   ���#2D6E48$��14(�6E   $��Segoe UI)�6S   $
��Left=�6i   $��541,177,0,0q�6�   $	��Top=�6�     5F      -	   5        $��dtp_Fecha_contrato��5F      $
��Left=�63   $��710,182,0,0q�6N   $	��Top=�6c   $	��171��6{   �� 5G      $��Usuario��6   ���#2D6E48$��14(�6;   $��Segoe UI)�6I   $
��Left=�6_   $��552,237,0,0q�6z   $	��Top=�6�   �� 5H      -
   5        $ txt_Usuario��5H      $��14(�6+   $��Segoe UI)�69   ���#E0F8E0���#2D6E48$
��Left=�6z   $��666,245,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5I      $��Contraseña��6   ���#2D6E48$��14(�6>   $��Segoe UI)�6L   $
��Left=�6b   $��541,285,0,0q�6}   $	��Top=�6�   �� 5J      -   5        $ txt_Contraseña��5J      $��14(�6.   $��Segoe UI)�6<   ���#E0F8E0���#2D6E48$
��Left=�6}   $��666,296,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5K      $��Confimar contraseña��6   ���#2D6E48$��14(�6G   $��Segoe UI)�6U   $
��Left=�6k   $��512,335,0,0q�6�   $	��Top=�6�   �� 5L      -   5        $ txt_Confirmar_contraseña��5L      $��14(�68   $��Segoe UI)�6F   ���#E0F8E0���#2D6E48$
��Left=�6�   $��666,343,0,0q�6�   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5M      -   5        
 ��Name$
 btn_Guardar��5M      $��Guardar��6*   
�������$��14(�6O   $��Segoe UI)�6]   $
��Bold"�6s   ���#2D6E48$��Center=�6�   $��	0,490,0,0q�6�   $	��Top=�6�   $	��105��6�   $��40��6	  ��5N      �� 5O      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5P      � $ Black��6'   � 5Q      $ 	#FF339A73��6'   $ 1Q�69   5R      5T      5V      5W      5Y      