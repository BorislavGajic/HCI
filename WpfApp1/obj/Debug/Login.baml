   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp1.LogWpfApp1.Log  5   	       WpfApp1.Log.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfApp1.Log     5   	     � Title$  Prijava��5   	   $��274.358��6   $��376.643��6+    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � .+�5   
   �� -   5         ��Name$ 
label_Copy��5      $��Korisničko ime:��6$   $
��Left=�6>   $��30��6Y   $��	61,40,0,0q�6e   $	��Top=�6x   $��99��6�   �� 5   
   -   5        $ label_Copy1��5      $��Lozinka:��6%   $
��Left=�68   $��30��6S   $��	61,75,0,0q�6_   $	��Top=�6r   $��75��6�   �� 5   
   -   5         ��Name$ korisnickoImeBox��5       � ToolTip$&  Polje za unos korisničkog imena��6K   $
��Left=�6u   $��30��6�   $��
165,40,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��137��6�   $��16(�6�   ��6,   �� *KorisnickoIme+6�   �� 5   
   -   5         ��Name$ prijava��5      $��Prijava��6"   $
��Left=�64   $��27��6O   $��
58,194,0,0q�6[   $	��Top=�6o   $��78��6�   6�   �� 5   
   -   5        $ registracija��5      $��Registracija��6'   $
��Left=�6>   $��27��6Y   $��141,194,0,0q�6e   $	��Top=�6z   $��97��6�   6�   G� 5   
   -   5         G�Name$ passwordBox��5      $ Polje za unos lozinke��6Y   $
��Left=�6y   $��
165,75,0,0q�6�   $	��Top=�6�   $	��137��6�   $��30��6�   $��16(�5      �� 5   
   -   5        $ helper��5      $y�Hidden=�6;   {�.  $
��Left=�6a   $��30��6|   $��165,123,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��137��6�   $��16(�6�   ��6"   �� *	Lozinka+6�   �� 5   
   -   5        $ helpime��5      $F @Ukoliko ste se već registrovali, unestite Vaše korisničko ime��6!   $��?��6i   
�������$
��Left=�6�   $��30��6�   $��
302,40,0,0q�6�   $	��Top=�6�   $��19��6�   �� 5   
   -	   5        $ helploz��5      $> 8Ukoliko ste se već registrovali, unestite Vašu lozinku��6!   $��?��6b   
�������$
��Left=�6�   $��30��6�   $��
302,75,0,0q�6�   $	��Top=�6�   $��19��6�   �� 5   
   -
   5        $��Pomoć��5      $
��Bold"�6!   $
��Left=�63   $��246,194,0,0q�6N   $	��Top=�6c   $��75��6{   $��27��6�   6�   5      5      