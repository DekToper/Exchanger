   M S B A M L   `   `   `  ����K  GMoneyExchangeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MoneyExchangeAppMoneyExchangeApp  5   	   $    MoneyExchangeApp.HistoryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MoneyExchangeApp     5   	     � Title$  HistoryWindow��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $��10,69,10,10q�6%   �� 5   
   -   5         ��Name$ 	searchBox��5   @   $
��Left=�6   $��	10,16,0,0q�6-    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��290��6   $��34��6�   $��18(�6�   �� 5   
   -   5        $��Search��5      $
��Left=�6"   $��
670,10,0,0q�6=   $	��Top=�6Q   $��40��6i   $	��105��6u   $��22(�6�   6�   �� 5   
   -   5         ��Name$ listBox��5   &   $��
315,17,0,0q�6   $
��Left=�67   $	��185��6R   $��33��6^   $	��Top=�6j   .@�5      �� .��6   Id5      �� 5      .��6   FromCurrency5      �� 5      .��6   
FromAmount5      �� 5      .��6   
ToCurrency5      �� 5      .��6   
ToAnount5      �� 5      .��6   Date5      5      �� 5   
   -   5        $��Update��5      $
��Left=�6=   $��
550,10,0,0q�6X   $	��Top=�6l   $��40��6�   $	��105��6�   $��22(�6�   5      5      