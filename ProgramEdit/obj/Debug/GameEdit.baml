   M S B A M L   `   `   `  ����F  BProgramEdit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProgramEditProgramEdit  5   	       ProgramEdit.GameEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProgramEdit     5   	     � Title$  GameEdit��5   	   $��351.451��6   $��543.536��6+   .��5	      � .+�5
   
   �� -   5        $��	GamesList��5
      $
��Left=�6#   $	��200��6>   $��	10,10,0,0q�6K   $	��Top=�6^   $	��170��6v   6�   �� 5   
   -   5        $��
AddNewGame��5      $��Přidat jako novou sekci��6#   $
��Left=�6E   $��
10,275,0,0q�6`   $	��Top=�6t   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $��
UpdateGame��5      $��Uložit��6#   $
��Left=�64   $��
10,225,0,0q�6O   $	��Top=�6c   $	��170��6{   $��30��6�   6�   �� 5   
   -   5        $
��Back��5      $��Odejít bez uložení��6   $
��Left=�6:   $��220,275,0,0q�6U   $	��Top=�6j   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $��Delete��5      $��Odstranit sekci��6   $
��Left=�69   $��220,225,0,0q�6T   $	��Top=�6i   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $
��Name��5      $
��Left=�6   $��25��69   $��
400,20,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $��Shortcut��5      $
��Left=�6"   $��25��6=   $��
400,60,0,0q�6I   $
 Wrap=�6]   $��TextBox��6q   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��NumOfPlayers��5      $
��Left=�6&   $��25��6A   $��400,140,0,0q�6M   $
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��120��6�   �� 5   
   -	   5        $��PositionRequired��5      $
��Left=�6+   $��400,106,0,0q�6F   $	��Top=�6[   �� 5   
   $��Název:��6   $��Right=�6!   $
��Left=�6D   $��
220,20,0,0q�6_   $	��Top=�6s   $��25��6�   $	��150��6�   �� 5   
   $��Zkratka:��6   $��Right=�6#   $
��Left=�6F   $��
220,60,0,0q�6a   $	��Top=�6u   $��25��6�   $	��150��6�   �� 5   
   $��Povinné pozice:��6   $��Right=�6*   $
��Left=�6M   $��220,100,0,0q�6h   $	��Top=�6}   $��25��6�   $	��150��6�   �� 5   
   $��Počet hráčů:��6   $��Right=�6'   $
��Left=�6J   $��220,140,0,0q�6e   $	��Top=�6z   $��25��6�   $	��150��6�   �� 5   
   $��Názvy pozic:��6   $��Right=�6'   $
��Left=�6J   $��220,180,0,0q�6e   $	��Top=�6z   $��25��6�   $	��150��6�   �� 5   
   -
   5        $��Saved��5      $��Uloženo��6   $
��Left=�6/   $��200,173,0,0q�6J   $	��Top=�6_   $��20(�6w   $	��170��6�   $y�Hidden=�6�   �� 5   
   -   5        $��	Positions��5      $
��Left=�6#   $	��125��6>   $��400,180,0,0q�6K   $��TextBox��6`   $	��Top=�6o   $	��120��6�    �� AcceptsReturn . $
 Wrap=�6�   5      5      