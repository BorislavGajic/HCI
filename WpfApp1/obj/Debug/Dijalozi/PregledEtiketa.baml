   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApp1.DijaloziWpfApp1.Dijalozi  5   	   %    WpfApp1.Dijalozi.PregledEtiketa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WpfApp1.Dijalozi     5   	     � Title$  PregledEtiketa��5   	   $��371.923��6    $��564.615��61    � WindowStartupLocation$ CenterScreen=�6A   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tableEtiketa��5         
IsReadOnly .    AutoGenerateColumns .  $	��277��6u   $	��Top=�6�   ��6*   �� *Etik+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $
 Boja��6%   $ 3* 6K    63   �� *Sss+6K     5      $
 Opis��6%   $ 6* 6L    63   �� *Opis+6L   5      �� 5   
   -   5        $��Obrisi��5      $
��Left=�6"   $��399,282,0,0q�6=   $	��120��6R   $��21��6^   $	��Top=�6   �� 5   
   -   5        $��Izmeni��5      $
��Left=�6"   $��252,282,0,0q�6=   $	��120��6R   $��21��6^   $	��Top=�6�   �� 5   
   $��Pretraga po boji:��6   $
��Left=�6,   $��
10,277,0,0q�6G   $	��Top=�6[   $��97��6s   �� 5   
   -   5        $
��Left=�5      $��112,282,0,0q�6-   	 �� TextWrapping$
	 Wrap=�6B   $	��120��6V   $��23��6�   $	��Top=�6�   5      5      