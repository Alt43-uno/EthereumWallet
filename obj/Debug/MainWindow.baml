   M S B A M L   `   `   `  ����  EthereumWallet    EthereumWallet.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Ethereum Wallet��5   	   $	��350��6!   $	��450��6.   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��8* �6   .+�5
   
   �� -   5         ��Name$ BalanceTextBlock��5
      $
��Left=�6.   $
��Wrap=�6I   $��Balance: 0 ETH��6]   $	��Top=�6s   $��	10,32,0,0q�6�   $��2��6�   �� 5   
   -   5         ��Name$ RecipientAddressTextBox��5      $
��Left=�63   $��23��6N   $��	10,57,0,0q�6Z    �� TextWrapping$
 Wrap=�6m   $��Recipient Address��6�   $	��Top=�6�   $	��200��6�   $��2��6�   �� 5   
   -   5        $ AmountTextBox��5      $
��Left=�6)   $��23��6D   $��	10,85,0,0q�6P   $
 Wrap=�6c   $��Amount��6w   $	��Top=�6�   $	��200��6�   $��2��6�   �� 5   
   -   5         ��Name$ 
SendButton��5      $
��Send��6%   $
��Left=�64   $��
175,87,0,0q�6O   $	��Top=�6c   $��75��6{   $��1��6�   �� 5   
   -   5        $ AddressTextBlock��5      $#��Адрес кошелька: ��6.   $��10,10,10,286q�6F   $��2��6\   �� 5   
   -   5        $ SeedPhraseTextBlock��5      $��Seed фраза: ��61   $y�	Collapsed=�6E   $��10,198,62,41q�6\   $��2��6r   �� 5   
   -   5        $ ShowSeedButton��5      $,��&Показать seed кошелька��6)   $��10,113,199,156q�6J   $��2��6   5      5      