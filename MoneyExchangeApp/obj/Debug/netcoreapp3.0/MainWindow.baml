   M S B A M L   `   `   `  ����K  GMoneyExchangeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MoneyExchangeAppMoneyExchangeApp  5   	   !    MoneyExchangeApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MoneyExchangeApp     5   	     � Title$  	Exchanged��5   	   $	��264��6   $	��944��6(   
�������.��5	      � .+�5
   
   �� -   5         ��Name$ 	amountBox��5
   b   $��Center=�6   $
��Left=�64   $��	26,44,0,0q�6O    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $	��200��6�   $��60��6�   
�������$��20(�6�   �� 5   
   $��Amount: ��6   $
��Left=�6#   $��	26,24,0,0q�6>   $	��Top=�6Q   $��14(�6i   ���	#FF787676$��65��6�   �� 5   
   $
��Left=�6   $��1��6/   $��246,103,0,0q�6:   ���	#FF717171$	��Top=�6b   $	��180��6z    J� RenderTransformOrigin$ 0.5,0.5&�6�   5      �� 5   
   -   5         ��Name$ currencyFrom��5      $��
246,44,0,0q�6)   $
��Left=�6=   $	��180��6X   $��59��6d   $	��Top=�6p   �� 5   
   -   5         ��Name$ 
fromButton��5      $	��⮟��6%   $
��Left=�61   $��
366,58,0,0q�6L   $	��Top=�6`   $��44��6x   �� 5   
   $��Converted to: ��6   $
��Left=�6)   $��
499,24,0,0q�6D   $	��Top=�6X   $��14(�6p   ���	#FF787676$	��100��6�   �� 5   
   $
��Left=�6   $��1��6/   $��719,103,0,0q�6:   ���	#FF717171$	��Top=�6b   $	��180��6z   $ 0.5,0.5&�6�   �� 5   
   $
��Left=�6   $��1��6/   $��499,104,0,0q�6:   ���	#FF717171$	��Top=�6b   $	��200��6z   $ 0.5,0.5&�6�   �� 5   
   -   5        $ 
currencyTo��5      $��
719,44,0,0q�6'   $
��Left=�6;   $	��180��6V   $��60��6b   $	��Top=�6n   �� 5   
   -   5        $ toButton��5      $	��⮟��6#   $
��Left=�6/   $��
840,58,0,0q�6J   $	��Top=�6^   $��44��6v   �� 5   
   -   5        $ replaceButton��5      $	��⇄��6(   $
��Left=�64   $��
438,56,0,0q�6O   $	��Top=�6c   $��20(�6{   $��40��6�   �� 5   
   -   5         ��Name$ resaultLabel��5   2   $��Center=�6   $
��Left=�6H   $��
499,44,0,0q�6c   $	��Top=�6w   $��60��6�   $	��200��6�   $��20(�6�   
���   �6�   �� 5   
   -   5        $ exchangeButton��5      $��Exchange��6)   $
��Left=�6<   $��
26,144,0,0q�6W   $	��Top=�6k   $��45��6�   $	��124��6�   $��18(�6�   $
��Bold"�6�    � 5   
   -	   5          �Name$ 	fromFrame��5   D     � NavigationUIVisibility$ Hidden=�6   $y�Hidden=�60   $��246,104,0,0q�6W   $
��Left=�6l   $	��201��6�   $��59��6�   $	��Top=�6�    � 5   
   -
   5        $ toFrame��5   D   $ Hidden=�6   $y�Hidden=�60   $��719,104,0,0q�6U   $
��Left=�6j   $	��201��6�   $��59��6�   $	��Top=�6�   �� 5   
   -   5        $ erroreLabel��5      $
��Left=�6%   $��
26,189,0,0q�6@   $	��Top=�6T   ���	#DDFF0000$��Italic$�6�   $
��Bold"�6�   �� 5   
   -   5        $ historyButton��5   #   $��History��6   $��32��6:   $	��Top=�6F   $��Right=�6^   $��82��6z   $��0,2,2,0q�6�   5      5       