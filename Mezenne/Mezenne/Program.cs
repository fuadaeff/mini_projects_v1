using System;
using System.Collections.Generic;

class CurrencyExchangeSystem
{
    static Dictionary<string, decimal> currencyRates = new Dictionary<string, decimal>
    {
        { "USD", 1.7m },
        { "EUR", 1.85m },
        { "RUB", 0.023m },
        { "TRY", 0.1m }
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Komandaları daxil edin:");
            Console.WriteLine("1. Mövcud məzənnələrin göstərilməsi");
            Console.WriteLine("2. Spesifik məzənnənin göstərilməsi");
            Console.WriteLine("3ş Məbləği məzənnəyə uyğun hesablama");
            Console.WriteLine("exit - Programdan çıxış.");

            Console.Write("\nKomandanı daxil edin: ");
            string command = Console.ReadLine()?.Trim().ToLower();

            switch (command)
            {
                case "1":
                    ShowRecentCurrencyRates();
                    break;

                case "2":
                    FindCurrencyRateByCode();
                    break;

                case "3":
                    CalculateAmountByCurrency();
                    break;

                case "/exit":
                    Console.WriteLine("Programdan çıxılır...");
                    return;

                default:
                    Console.WriteLine("Yanlış komanda daxil etdiniz! Zəhmət olmasa, düzgün komanda daxil edin.");
                    break;
            }
        }
    }

    static void ShowRecentCurrencyRates()
    {
        Console.WriteLine("\nMəzənnələr:");
        foreach (var currency in currencyRates)
        {
            Console.WriteLine($"{currency.Key}: {currency.Value} AZN");
        }
    }

    static void FindCurrencyRateByCode()
    {
        Console.Write("Məzənnə kodunu daxil edin (USD, EUR, RUB, TRY): ");
        string code = Console.ReadLine()?.Trim().ToUpper();

        if (currencyRates.ContainsKey(code))
        {
            Console.WriteLine($"{code} məzənnəsi: {currencyRates[code]} AZN");
        }
        else
        {
            Console.WriteLine("Bu məzənnə sistemdə tapılmadı.");
        }
    }

    static void CalculateAmountByCurrency()
    {
        Console.Write("Məbləği daxil edin: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Xahiş olunur düzgün məbləğ daxil edin.");
            return;
        }

        Console.Write("Məzənnə kodunu daxil edin (USD, EUR, RUB, TRY): ");
        string code = Console.ReadLine()?.Trim().ToUpper();

        if (currencyRates.ContainsKey(code))
        {
            decimal result = amount * currencyRates[code];
            Console.WriteLine($"{amount} {code} = {result} AZN");
        }
        else
        {
            Console.WriteLine("Bu məzənnə sistemdə tapılmadı.");
        }
    }
}
