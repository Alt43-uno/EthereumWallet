using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.HdWallet;
using Nethereum.Util;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System;
using NBitcoin;
using Nethereum.Hex.HexTypes;
using System.Windows;

public class Main
{
    private Web3 web3;
    public Account CurrentAccount { get; private set; }

    public Main()
    {
        web3 = new Web3("https://sepolia.infura.io/v3/364adc95affa44dd8014643f7fbad620");
    }

    public (string Address, string PrivateKey, string Mnemonic) CreateWallet()
    {
        var mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);
        var wallet = new Wallet(mnemonic.ToString(), null);
        var account = wallet.GetAccount(0);

        CurrentAccount = account;

        return (account.Address, account.PrivateKey, mnemonic.ToString());
    }


    private string seedPhrase; // Храните мнемоническую фразу

    public string GetSeedPhrase()
    {
        return seedPhrase;
    }



    public void LoginWithSeedPhrase(string seedPhrase)
    {
        this.seedPhrase = seedPhrase;
        var wallet = new Wallet(seedPhrase, null);
        var account = wallet.GetAccount(0); // Получаем первый аккаунт из кошелька
        CurrentAccount = account; // Устанавливаем текущий аккаунт
        web3 = new Web3(account, "https://sepolia.infura.io/v3/364adc95affa44dd8014643f7fbad620");
    }

    public async Task<decimal> GetBalanceAsync(string address)
    {
        var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
        return Web3.Convert.FromWei(balance.Value);
    }

    public async Task<string> SendTransactionAsync(string privateKey, string toAddress, decimal amount)
    {
        var account = new Account(privateKey);
        web3 = new Web3(account, "https://sepolia.infura.io/v3/364adc95affa44dd8014643f7fbad620");

        var transactionInput = new TransactionInput()
        {
            From = account.Address,
            To = toAddress,
            Value = new HexBigInteger(Web3.Convert.ToWei(amount)),
            GasPrice = new HexBigInteger(Web3.Convert.ToWei(20, UnitConversion.EthUnit.Gwei)),
            Gas = new HexBigInteger(21000)
        };

        var txId = await web3.Eth.Transactions.SendTransaction.SendRequestAsync(transactionInput);

        return txId;
    }

}
