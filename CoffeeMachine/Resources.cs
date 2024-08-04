using System;
using System.Globalization;

namespace CoffeeMachine;

public static class Resources {
    public static int water = 300;
    public static int milk = 200;
    public static int coffee = 100;
    public static decimal money = 0M;

    public static void Report() {
        string formatted_money = string.Format(new CultureInfo("en-US"), "{0:C}", money);

        Console.WriteLine($"Water: {water} mL");
        Console.WriteLine($"Milk: {milk} mL");
        Console.WriteLine($"Coffee: {coffee} g");
        Console.WriteLine($"Money: {formatted_money}");

        Console.Write($"\nPress enter to continue: ");
        Console.ReadLine();
    }

    public static bool SufficientResources(DrinkInfo info) {
        if (water >= info.water_required && milk >= info.milk_required && coffee >= info.coffee_required) {
            return true;
        } else {
            return false;
        }
    }
}