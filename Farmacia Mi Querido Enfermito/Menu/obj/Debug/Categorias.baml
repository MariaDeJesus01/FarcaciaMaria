   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5   	       Menu.Categorias   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Menu     5   	     � Title$  
Categorias��5   	   $	��337��6   $��788.858��6)   ��5	      �� 5
   
    �� ImageSource$ Imagenes/fondo.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �  � Orientation$ Vertical=�6   $��0��6+   $��3��6;   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��150��6   $��4q�6$   $��Nombre de la Categoria��6/   �� 5      -   5         ��Name$ NombreCategorias��5   =   $��30��6   $	��150��6&   $��4q�62   6=   5      5      � 5   
   $ 
Horizontal=�6   $��
0,36,1,134q�6-   $��4��6A   $��3��6N   .+�5       �� -   5         ��Name$ btnRegresar��5    ,   $��4q�6   $	��120��6    
�������.��5!      �� .+�5"      �� .��6   
Regresar6&   �� 5#      $&�� /Imagenes/text_indent_remove.png��6   $��16��6F   6S   5$      5%      �� 5&      -   5        $ btnEliminar��5&   ,   $��4q�6   $	��120��6    
�������.��5'      �� .+�5(      �� .��6   
Eliminar6&   �� 5)      $$��/Imagenes/textfield_delete.png��6   $��16��6D   5*      5+      �� 5,      -   5        $ 
btnGuardar��5,   ,   $��4q�6   $	��120��6    
�������.��5-      �� .+�5.      �� .��6   	Guardar6%   �� 5/      $��/Imagenes/page_save.png��6   $��16��6=   6J   50      51      �� 52      -   5        $ btnNuevo��52   ,   $��4q�6   $	��120��6    
�������.��53      �� .+�54      �� .��6   Nuevo6#   �� 55      $!��/Imagenes/textfield_add.png��6   $��16��6A   6N   56      57      �� 58      -   5        $ btnCancelar��58   ,   $��4q�6   $	��120��6    
�������.��59      �� .+�5:      �� .��6   
Cancelar6&   �� 5;      $��/Imagenes/cancel.png��6   $��16��6:   6G   5<      5=      �� 5>      -   5        $ 	btnEditar��5>   ,   $��4q�6   $	��120��6    
�������.��5?      �� .+�5@      �� .��6   Editar6$   �� 5A      $��/Imagenes/cart_edit.png��6   $��16��6=   6J   5B      5C      5D      &   System.Windows.Controls.DataGrid  5E   
   -   5          Name$ CategoriasTabla��5E      $��4��6,   $��2��69   $��
30,97,26,0q�6I   $	��150��6]   $	��Top=�6j   6�   5F      5G      