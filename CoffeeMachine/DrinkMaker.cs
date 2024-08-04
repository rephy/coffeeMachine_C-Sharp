using System;
using System.Threading;

namespace CoffeeMachine;

internal static class DrinkMaker {
    internal static void MakeDrink(DrinkInfo info) {
        Console.WriteLine("Please wait as we make your order...");
        Thread.Sleep(10000);

        Resources.water -= info.water_required;
        Resources.milk -= info.milk_required;
        Resources.coffee -= info.coffee_required;
        Resources.money += info.cost;

        Console.WriteLine($"\nHere you go! Enjoy your {info.this_order.ToString().ToLower()}!");
        Thread.Sleep(5000);
    }
}