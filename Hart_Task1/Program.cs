using Hart_Task1.Classes;
using Hart_Task1.Common;

internal class Program
{
    private static void Main(string[] args)
    {

        int selectedAction=0;
        decimal netto = 0.00m, brutto = 0.00m, tax = 0.00m ;
        string? currency=string.Empty,temp = string.Empty;

        Console.WriteLine("############################################################");
        Console.WriteLine("###################### TAX CALCULATOR ######################");
        Console.WriteLine("############################################################");
        for (; ; )
        {

            try
            {
                Console.WriteLine("\r\n\r\nWhat You want to do? Select action:");
                Console.WriteLine("\t1 - Insert netto value");
                Console.WriteLine("\t2 - Choose currency and VAT tax related to it");
                Console.WriteLine("\t3 - Show tax value and brutto value\r");
                Console.WriteLine("Type a number and press enter");
                selectedAction = Convert.ToInt32(Console.ReadLine());

                switch(selectedAction)
                {
                    case 1:
                        Console.WriteLine("Insert netto value:");
                        netto = Convert.ToDecimal(Console.ReadLine());
                        break;
                    case 2:
                        for (;;)
                        {
                             Console.WriteLine("Choose currency and VAT tax related to it:");
                            foreach(var vat in CurrencyVat.CurrencyVatList)
                            {
                                Console.WriteLine($"\t{vat.Key} {vat.Value}%");
                            }
                            temp = Console.ReadLine();
                            if (temp == null)
                            {
                                temp = string.Empty;
                                Console.WriteLine("\r\nWrong currency selected. Try again or type EXIT to go to main menu");
                            }
                            else if (temp.ToUpper() == "EXIT")
                            {
                                Console.WriteLine("\r\nCurrency not changed");
                                break;
                            }
                            else if (!CurrencyVat.CurrencyVatList.ContainsKey(temp.ToUpper()))
                            {
                                temp = string.Empty;
                                Console.WriteLine("\r\nWrong currency selected. Try again or type EXIT to go to main menu");
                            }
                            else
                            {
                                currency = temp.ToUpper();
                                Console.WriteLine($"Currency successfully chosen. Selected currency: {currency}");
                                break;
                            }
                        }
                        break;
                    case 3:
                        if(netto<1 && string.IsNullOrEmpty(currency))
                        {
                            Console.WriteLine("\r\nIn order to calculate tax You need to insert netto value and select currency");
                        }
                        else if (netto < 1)
                        {
                            Console.WriteLine("\r\nIn order to calculate tax You need to insert netto value");
                        }
                        else if (string.IsNullOrEmpty(currency))
                        {
                            Console.WriteLine("\r\nIn order to calculate tax You need to select currency");
                        }
                        else { 
                            TaxCalculator calculator = new(currency);
                           tax =  calculator.Calculate(netto);
                            brutto = netto + tax;
                            Console.WriteLine("##################### RESULTS #####################");
                            Console.WriteLine($"\tNETTO: {netto}");
                            Console.WriteLine($"\tCURRENCY: {currency} {CurrencyVat.CurrencyVatList[currency]}%");
                            Console.WriteLine($"\tTAX: {tax}");
                            Console.WriteLine($"\tBRUTTO: {brutto}");
                            Console.WriteLine("###################################################");
                        }
                        break;
                    default:
                        throw new OverflowException();
                }

            }
            catch (OverflowException ex)
            {
                Console.WriteLine("\r\nWrong number. Type letters from 1 to 3");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\r\nWrong format. Type letters from 1 to 3");
            }
        }
    }
}