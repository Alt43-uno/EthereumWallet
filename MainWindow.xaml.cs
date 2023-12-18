using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EthereumWallet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main main;

        public MainWindow(Main mainInstance)
        {
            InitializeComponent();
            main = mainInstance;
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            if (main.CurrentAccount != null)
            {
                AddressTextBlock.Text = $"Адрес кошелька: {main.CurrentAccount.Address}";
                SeedPhraseTextBlock.Text = $"Seed фраза: {main.GetSeedPhrase()}"; // Предполагая, что метод GetSeedPhrase() реализован в классе Main
            }
            UpdateBalance();
        }

        private void ShowSeedButton_Click(object sender, RoutedEventArgs e)
        {
            // Показываем или скрываем сид-фразу
            SeedPhraseTextBlock.Visibility = SeedPhraseTextBlock.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void UpdateBalance()
        {
            if (main.CurrentAccount == null)
            {
                // Обработка ситуации, когда CurrentAccount еще не инициализирован
                return;
            }

            decimal balance = await main.GetBalanceAsync(main.CurrentAccount.Address);
            BalanceTextBlock.Text = $"Balance: {balance} ETH";
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string toAddress = RecipientAddressTextBox.Text;
            decimal amount = decimal.Parse(AmountTextBox.Text);
            string transactionHash = await main.SendTransactionAsync(main.CurrentAccount.PrivateKey, toAddress, amount);
            MessageBox.Show($"Транзакция отправлена. Hash: {transactionHash}");
            UpdateBalance();
        }

        

    }


}
