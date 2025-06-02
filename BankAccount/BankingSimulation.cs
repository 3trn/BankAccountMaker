using AccountBlueprint;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace BankingSimulation
{
    class Bank
    {
        public static double cash = 100;
        static void Main (String [] args)
        {
            List<AccountBlueprint.Account> accounts = new List<AccountBlueprint.Account>();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("-- BANKING SIMULATION ---\n" +
                "1) LOGIN\n" +
                "2) SIGN UP\n" +
                "3) EXIT\n" +
                "-------------------------\n");
                int menuNavigationInput = Convert.ToInt32(Console.ReadLine());
                switch (menuNavigationInput)
                {
                    case 1:
                        Console.WriteLine("-- LOGIN ---\n" +
                        "ENTER YOUR FULL NAME");
                        string nameInput = Console.ReadLine().ToLower();
                        Console.WriteLine("\nENTER YOUR PASSWORD");
                        string passwordInput = Console.ReadLine();
                        Console.WriteLine("-----------------------\n");
                        var foundAccount = accounts.FirstOrDefault(a => a.GetName() == nameInput && a.VerifyPassword(passwordInput));

                        if (foundAccount != null)
                        {
                            bool logInRunning = true;
                            Console.WriteLine("--- LOGIN SUCCESSFUL ---\n" + "\n-----------------------\n");
                            while (logInRunning)
                            {
                                Console.WriteLine("-- LOGIN MENU ---\n" +
                                "\n1) ACCOUNT DETAILS\n" +
                                "2) CHECK BALANCE\n" +
                                "3) WITHDRAW\n" +
                                "4) DEPOSIT\n" +
                                "5) TRANSFER\n" +
                                "6) LOG OUT\n" +
                                "-----------------------\n");
                                int logInMenuNavigationInput = Convert.ToInt32(Console.ReadLine());
                                switch (logInMenuNavigationInput)
                                {
                                    case 1:
                                        Console.WriteLine(foundAccount.ToString());
                                        break;
                                    case 2:
                                        Console.WriteLine("BALANCE: £" + foundAccount.GetBalance());
                                        break;
                                    case 3:
                                        Console.WriteLine("BALANCE: £" + foundAccount.GetBalance());
                                        if (foundAccount.GetBalance() <= 0)
                                        {
                                            Console.WriteLine("CANNOT WITHDRAW DUE TO INSUFFICIENT FUNDS");
                                        } 
                                        else
                                        {
                                            Console.WriteLine("--- WITHDRAW AMOUNT ---");
                                            int withdrawnAmount = Convert.ToInt32(Console.ReadLine());
                                            if (withdrawnAmount > foundAccount.GetBalance())
                                            {
                                                Console.WriteLine("YOU CANNOT WITHDRAW THIS AMOUNT");
                                            } 
                                            else
                                            {
                                                transactionProcessor(foundAccount, withdrawnAmount, 0, "Withdrawing");
                                            }
                                        }
                                        
                                        break;
                                    case 4:
                                        Console.WriteLine("BALANCE: £" + foundAccount.GetBalance());
                                        Console.WriteLine("--- DEPOSIT AMOUNT ---");
                                        int depositAmount = Convert.ToInt32(Console.ReadLine());
                                        if (depositAmount > cash)
                                        {
                                            Console.WriteLine("YOU CANNOT WITHDRAW THIS AMOUNT");
                                        }
                                        else
                                        {
                                            transactionProcessor(foundAccount, 0, depositAmount, "Depositing");
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine(foundAccount.GetBalance());
                                        break;
                                    case 6:
                                        logInRunning = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("--- LOGIN UNSUCCESSFUL ---\n");
                        }
                            break;
                    case 2:
                        Console.WriteLine("-- SIGN UP ---\n" +
                        "ENTER YOUR FULL NAME");
                        string nameCreation = Console.ReadLine().ToLower();
                        Console.WriteLine("\nENTER A PASSWORD");
                        string passwordCreation = Console.ReadLine();
                        Console.WriteLine("\nENTER AN ACCOUNT TYPE");
                        string accountTypeCreation = Console.ReadLine();
                        Console.WriteLine("---------------\n" +
                            "\n--- ACCOUNT DETAILS ---\n");
                        AccountBlueprint.Account account = new AccountBlueprint.Account(nameCreation, passwordCreation, accountTypeCreation);
                        accounts.Add(account);
                        Console.WriteLine(account.ToString());
                        Console.WriteLine("-----------------------\n");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("INCORRECT OPTION");
                        break;

                }
            }
        }
        public static void transactionProcessor(AccountBlueprint.Account account, double withdrawAmount, double depositAmount, string transactionType)
        {
            if (transactionType == "Withdrawing")
            {
                if (account.WithdrawBalance(withdrawAmount))
                {
                    cash += withdrawAmount;
                    Console.WriteLine($"WITHDREW {withdrawAmount}, BANK CASH: {cash}, NEW BALANCE: {account.GetBalance()}");
                }
            }
            else if (transactionType == "Depositing")
            {
                account.DepositBalance(depositAmount);
                cash -= depositAmount;
                Console.WriteLine($"DEPOSITED {depositAmount}, BANK CASH: {cash}, NEW BALANCE: {account.GetBalance()}");
            }
        }

    }
}
