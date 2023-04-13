using AssetFinanziari.Model;
using System;

namespace AssetFinanziari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CREATE CENTRAL SWIFT BANK
            SwiftCentralBank bancaDItalia = new SwiftCentralBank("Banca d'Italia", "Roma", "Ignazio Visco", "Italia");

            // CREATE STOCK MARKET
            StockMarket piazzaAffari = new StockMarket("Piazza Affari", "Italia", "Milano", "P.za degli Affari, 6", "Raffaele Jerusalmi");

            //CREATE COMMERCIAL BANK
            CommercialBank unicredit = new CommercialBank("Unicredit", "Milano", "Andrea Orcel", "Italia");
            bancaDItalia.AddCommercialBank(unicredit);

            CommercialBank intesaSanPaolo = new CommercialBank("Intesa San Paolo", "Torino", "Carlo Messina", "Italia");
            bancaDItalia.AddCommercialBank(intesaSanPaolo);

            //ADD STOCK MARKET TO COMMERCIAL BANK
            unicredit.AddStockMarket(piazzaAffari);
            intesaSanPaolo.AddStockMarket(piazzaAffari);

            //CREATE A CLIENT
            bool marioIsAdded = unicredit.AddBankClient("Mario", "Rossi", "MRARSS23S08H501W", "23/12/1992", "maschio", "mario.rossi@gmail.com", "3457652211", "Via Condotti", "Roma", "Italia");
            if (!marioIsAdded) return;

            //CREATE A BANK ACCOUNT linked to CLIENT
            unicredit.AddBankAccount("Mario", "Rossi", "MRARSS23S08H501W");
            long marioAccountIban = Test.Test.getIban(unicredit, "MRARSS23S08H501W");

            //BUY STOCK ASSET NO MONEY
            piazzaAffari.CreateStockAsset("Tesla", 1000, 340M);
            unicredit.BuyStockAsset("Meta", 20000, "Euro", marioAccountIban);

            //ADD ASSET TO ACCOUNT
            unicredit.AddFiatAsset("Euro", marioAccountIban);
            unicredit.AddFiatAsset("GBP", marioAccountIban);
            unicredit.AddCryptoAsset("Bitcoin", marioAccountIban);

            //FIAT OPERATIONS
            unicredit.DepositFiat("Euro", 10000M, marioAccountIban);
            unicredit.DepositFiat("GBP", 1000M, marioAccountIban);
            unicredit.WithdrawFiat("Euro", 4000M, marioAccountIban);
            unicredit.WithdrawFiat("Euro", 1000M, marioAccountIban);

            //BUY STOCK ASSET WITH MONEY
            unicredit.BuyStockAsset("Meta", 1000, "Euro", marioAccountIban);

            //CENTRAL BANK OUT OF SWIFT
            CentralBank russianCentralBank = new CentralBank("Central Bank of the the Russian Federation", "Mosca", "El'vira Nabiullina", "Russia");

            //RUSSIAN COMMERCIAL BANK
            CommercialBank gazpromBank = new CommercialBank("Gazprombank", "Mosca", "Andrey Akimov", "Russia");
            russianCentralBank.AddCommercialBank(gazpromBank);

            //CREATE RUSSIAN CLIENT
            bool dimitriIsAdded = gazpromBank.AddBankClient("Dimitri", "Smirnof", "DMTSMF22OI07U231", "10/10/1996", "maschio", "dimitri.smirnof@gmail.com", "355566656", "Ulitsa Potylikha", "Mosca", "Russia");
            if (!dimitriIsAdded) return;

            //CREATE RUSSIAN BANK ACCOUNT
            gazpromBank.AddBankAccount("Dimitri", "Smirnof", "DMTSMF22OI07U231");
            long dimitriAccountIban = Test.Test.getIban(gazpromBank, "DMTSMF22OI07U231");

            //ADD ASSET TO RUSSIAN BANK
            gazpromBank.AddFiatAsset("rublo", dimitriAccountIban);
            gazpromBank.AddCryptoAsset("ETH", dimitriAccountIban);

            //BANK TRANSFER TO RUSSIAN 
            unicredit.Transfer(intesaSanPaolo, new FIATTransferRequest { AssetName = "Euro", Amount = 500M, IBANFrom = marioAccountIban, IBANTo = dimitriAccountIban });

            
            //REMOVE COMMERCIAL BANK
            bancaDItalia.RemoveCommercialBank(intesaSanPaolo);

            unicredit.RemoveBankClient("Dimitri", "Smirnof", "DMTSMF22OI07U231");
            unicredit.RemoveBankAccount(marioAccountIban);

            //REMOVE ASSET FROM EUROPEAN BANK
            unicredit.RemoveFiatAsset("Euro", marioAccountIban);
            unicredit.RemoveCryptoAsset("Bitcoin", marioAccountIban);
        }
    }
}
