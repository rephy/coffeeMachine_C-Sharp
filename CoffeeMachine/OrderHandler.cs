using System;
using System.Threading;
using System.Globalization;

namespace CoffeeMachine;

public enum Order {
    Espresso,
    Latte,
    Cappuccino,
    Report,
    Supply,
    Unknown,
    Quit
}

internal static class OrderHandler {
    internal static void HandleOrder(Order order) {
        switch (order) {
            case Order.Report:
                Console.Clear();
                Resources.Report();
                break;
            case Order.Supply:
                Console.Clear();
                bool authenticated = Supplier.Authenticate();

                if (authenticated) {
                    Supplier.Restock();
                } else {
                    Console.WriteLine("\nAuthentication Failed.");
                    Thread.Sleep(5000);
                }

                break;
            default:
                DrinkInfo info = new DrinkInfo(order);
                bool sufficient_resources = Resources.SufficientResources(info);
                if (sufficient_resources) {
                    Console.Clear();
                    Transaction transaction = new Transaction(info);
                    if (transaction.approved) {
                        transaction.GiveChange();
                        DrinkMaker.MakeDrink(info);
                    } else {
                        decimal short_of = transaction.change * -1M;
                        string formatted_short_of = string.Format(new CultureInfo("en-US"), "{0:C}", short_of);
                        Console.WriteLine($"\nSorry, but you need {formatted_short_of} more. Your money has been refunded.");
                        Thread.Sleep(5000);
                    }
                } else {
                    Console.WriteLine($"\nSorry, but there aren't enough supplies to make your {info.this_order.ToString().ToLower()}.");
                    Thread.Sleep(5000);
                }
                break;
        }
    }

    internal static Order PreOrder(string[] args) {
        string input = "";
        foreach (string arg in args) {
            input += $"{arg} ";
        }
        input = input.Trim();

        Order order = FindOrder(input, false);

        return order;
    }

    internal static Order MakeOrder() {
        Console.WriteLine("Hello, welcome to Rephy's Cafe!");
        Thread.Sleep(3000);
        Console.Write("What would you like to order? ");
        string input = Console.ReadLine() ?? "";
        Order order = FindOrder(input);

        return order;
    }

    internal static Order FindOrder(string input, bool quittable = true) {
        Order order;
        if (quittable) {
            order = input.ToLower() switch {
                "espresso" => Order.Espresso,
                "latte" => Order.Latte,
                "cappuccino" => Order.Cappuccino,
                "report" => Order.Report,
                "supply" => Order.Supply,
                "off" => Order.Quit,
                _ => Order.Unknown
            };
        } else {
            order = input.ToLower() switch {
                "espresso" => Order.Espresso,
                "latte" => Order.Latte,
                "cappuccino" => Order.Cappuccino,
                "report" => Order.Report,
                "supply" => Order.Supply,
                _ => Order.Unknown
            };
        }
        return order;
    }

    internal static void InvalidOrder() {
        Console.WriteLine("\nSorry, but the requested order is invalid.");
        Thread.Sleep(3000);
        Console.Clear();
    }
}