   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApp1.DijaloziWpfApp1.Dijalozi  5   	   %    WpfApp1.Dijalozi.PregledResursa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApp1.Dijalozi     5   	     � Title$  PregledResursa��5   	   $��498.79��6!   $	��970��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � $	��466��6   $	��Top=�6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color# � ��6    � Offset$ 1Q�6^   � 5      $ 	#FF2DE7F9��6   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMain��5         
IsReadOnly .    AutoGenerateColumns .  $	��322��6o   $	��Top=�6|   ��6%   �� *Res+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Oznaka��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $
 Naziv��6%   $ 3* 6L    64   �� *Ime+6L     5      $

 Opis��6%   $ 3* 6L    63   �� *Opis+6L     5      $	
 Tip��6%   $ 3* 6J    62   �� *Tip+6J     5      $
 Etiketa��6%   $ 3* 6R    66   �� *	Etiketa+6R     5      $
 Datum��6%   $ 3* 6m    64   �� *Datum+ �� StringFormat$ {0:dd.MM.yyyy}��6m     5      $
 Frekvencija pojavljivanja��6%   $ 5* 6v    6I   ��  �� Path$ FreqPojavljivanja�6�     5      $
 Jedinica mere��6%   $ 5* 6c    6<   �� $ JedinicaMere�6p     5      $

 Cena��6%   $ 4* 63    6>   �� *Cena+6Y   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 Obnovljivost��6)   $ 3* 6e    6@   �� $ 	Obnovljiv�6r     5      $
 Strateska vaznost��6)   $ 3* 6q    6E   �� $ StrateskaVaznost�6~     5      $
 Eksploatacija��6)   $ 3* 6j    6A   �� $ Eksploatacija�6w   5"      �� 5#   
   -   5        $
��Left=�5#      $��28��6-   $��117,344,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��170��6z   6�   �� 5$   
   -   5        $
��Left=�5$      $��28��6-   $��782,344,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��170��6z   6�   �� 5%   
   $��Pretraga po nazivu:��6   $
��Left=�6.   $��28��6I   $��654,344,0,0q�6U   $	��Top=�6j    J� RenderTransformOrigin$ 
0.474,0.36&�6�   �� 5&   
   $��Pretraga po oznaci:��6   $
��Left=�6.   $��28��6I   $��	0,344,0,0q�6U   $	��Top=�6h   �� 5(   
   -   5        $��Izmeni��5(      $
��Left=�6"   $��515,390,0,0q�6=   $	��Top=�6R   $	��120��6j   $��30��6v   6�   �� 5)   
   -   5        $��Obriši��5)      $
��Left=�6"   $��336,390,0,0q�6=   $	��Top=�6R   $	��120��6j   $��30��6v   6�   5*      5+      