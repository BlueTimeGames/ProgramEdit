   M S B A M L   `   `   `  ����F  BProgramEdit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProgramEditProgramEdit  5   	       ProgramEdit.SponsorEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProgramEdit     5   	     � Title$  SponsorEdit��5   	   $	��355��6   $	��550��6*   .��5	      � .+�5
   
   �� -   5        $��SponsorsList��5
      $
��Left=�6&   $	��195��6A   $��	10,10,0,0q�6N   $	��Top=�6a   $	��170��6y   6�   �� 5   
   -   5        $��AddNewSponsor��5      $#��Přidat jako nového sponsora��6&   $
��Left=�6L   $��
10,275,0,0q�6g   $	��Top=�6{   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $��UpdateSponsor��5      $��Uložit��6&   $
��Left=�67   $��
10,225,0,0q�6R   $	��Top=�6f   $	��170��6~   $��30��6�   6�   �� 5   
   -   5        $
��Back��5      $��Odejít bez uložení��6   $
��Left=�6:   $��220,275,0,0q�6U   $	��Top=�6j   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $��Delete��5      $��Odstranit sponsora��6   $
��Left=�6<   $��220,225,0,0q�6W   $	��Top=�6l   $	��170��6�   $��30��6�   6�   �� 5   
   -   5        $
��Name��5      $
��Left=�6   $��25��69   $��
400,20,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $��MonthlyPayment��5      $
��Left=�6(   $��25��6C   $��
400,60,0,0q�6O   $
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��
RenewBonus��5      $
��Left=�6$   $��25��6?   $��400,100,0,0q�6K   $
 Wrap=�6`   $��TextBox��6t   $	��Top=�6�   $	��120��6�   �� 5   
   -	   5        $��MinReputation��5      $
��Left=�6'   $��25��6B   $��400,140,0,0q�6N   $
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��120��6�   �� 5   
   -
   5        $��SuccessPayment��5      $
��Left=�6(   $��25��6C   $��400,180,0,0q�6O   $
 Wrap=�6d   $��TextBox��6x   $	��Top=�6�   $	��120��6�   �� 5   
   $��Název:��6   $��Right=�6!   $
��Left=�6D   $��
220,20,0,0q�6_   $	��Top=�6s   $��25��6�   $	��150��6�   �� 5   
   $��Měsíční platba:��6   $��Right=�6*   $
��Left=�6M   $��
220,60,0,0q�6h   $	��Top=�6|   $��25��6�   $	��150��6�   �� 5   
   $��Bonus při podepsání:��6   $��Right=�6/   $
��Left=�6R   $��220,100,0,0q�6m   $	��Top=�6�   $��25��6�   $	��150��6�   �� 5   
   $!��Minimální reputace týmu:��6   $��Right=�63   $
��Left=�6V   $��220,140,0,0q�6q   $	��Top=�6�   $��25��6�   $	��150��6�   �� 5   
   $��Turnajový bonus [%]:��6   $��Right=�6/   $
��Left=�6R   $��220,180,0,0q�6m   $	��Top=�6�   $��25��6�   $	��150��6�   �� 5   
   -   5        $��Saved��5      $��Uloženo��6   $
��Left=�6/   $��200,245,0,0q�6J   $	��Top=�6_   $��20(�6w   $	��170��6�   $y�Hidden=�6�   5      5      