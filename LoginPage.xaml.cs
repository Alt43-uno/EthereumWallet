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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private Main main;

        public LoginPage()
        {
            InitializeComponent();
            main = new Main(); // Используйте ваш API ключ
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var main = new Main();

            // Используем сид-фразу, введенную пользователем, для входа
            string seedPhrase = SeedPhraseTextBox.Text;
            main.LoginWithSeedPhrase(seedPhrase);

            // Открываем главное окно после входа
            var mainWindow = new MainWindow(main);
            mainWindow.Show();
            this.Close();
        }

        private void CreateWalletButton_Click(object sender, RoutedEventArgs e)
        {
            // Ваша логика для создания нового кошелька
            var walletDetails = main.CreateWallet();
            MessageBox.Show($"Кошелек создан. Адрес: {walletDetails.Address}, Мнемоника: {walletDetails.Mnemonic}");
            // Открыть MainWindow после создания кошелька
            var mainWindow = new MainWindow(main);
            mainWindow.Show();
            this.Close();
        }
    }


}
