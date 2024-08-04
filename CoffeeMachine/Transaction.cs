using System;
using System.Globalization;

namespace CoffeeMachine;

internal class Transaction {
    internal bool approved = false;
    internal decimal cost;
    internal decimal change;

    internal Transaction(DrinkInfo info) {
        this.cost = info.cost;
        this.approved = this.TakeCoins();
    }

    internal bool TakeCoins() {
        Console.WriteLine("Insert coins:\n");
        Console.Write("Pennies: ");
        int pennies = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nickels: ");
        int nickels = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Dimes: ");
        int dimes = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Quarters: ");
        int quarters = int.Parse(Console.ReadLine() ?? "0");

        decimal sum = CoinSum(pennies, nickels, dimes, quarters);
        this.change = sum - this.cost;

        return (this.change >= 0);
    }

    internal void GiveChange() {
        string formatted_change = string.Format(new CultureInfo("en-US"), "{0:C}", this.change);
        Console.WriteLine($"\nHere is your change: {formatted_change}");
    }

    internal decimal CoinSum(int pennies, int nickels, int dimes, int quarters) {
        decimal sum = (decimal) pennies * 0.01M + (decimal) nickels * 0.05M + (decimal) dimes * 0.1M + (decimal) quarters * 0.25M;
        return sum;
    }
}