   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApp1.DijaloziWpfApp1.Dijalozi  5   	   "    WpfApp1.Dijalozi.PregledTipa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApp1.Dijalozi     5   	     � Title$  PregledTipa��5   	   $��368.5��6   $��654.5��6,    � WindowStartupLocation$ CenterScreen=�6:   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tableTip��5
         
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,75q�6p   ��6&   �� *Tip+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $ Naziv��6%   $ 3* 6L    64   �� *Ime+6L     5      $
 Opis��6%   $ 3* 6L    63   �� *Opis+6L   5      �� 5   
   -   5        $��Obrisi��5      $
��Left=�6"   $��516,281,0,25q�6=   $	��120��6S   $��21��6_   6k   �� 5   
   -   5        $��Izmeni��5      $
��Left=�6"   $��354,281,0,26q�6=   $	��120��6S   $��20��6_   6k   �� 5   
   $��Pretraga po oznaci:��6   $
��Left=�6.   $	��Top=�6I   $��
15,282,0,0q�6a   �� 5   
   -   5        $
��Left=�5      $��23��6-   $��127,286,0,0q�69   	 �� TextWrapping$
	 Wrap=�6N   $	��Top=�6b   $	��120��6z   6�   5      5      