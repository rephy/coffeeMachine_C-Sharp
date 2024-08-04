using System;
using System.Threading;
using System.Collections.Generic;

namespace CoffeeMachine;

internal static class Supplier {
    internal static Dictionary<string, string> authorized_suppliers = new Dictionary<string, string>();

    static Supplier() {
        authorized_suppliers.Add("rephy", "Rephy2011!");
    }

    internal static bool Authenticate() {
        string id;
        string password;

        Console.Write("Please enter your ID: ");
        id = Console.ReadLine() ?? "0";

        if (authorized_suppliers.ContainsKey(id)) {
            Console.Clear();

            password = authorized_suppliers[id];

            Console.Write("Please enter your password: ");
            string input_password = Console.ReadLine() ?? "0";

            if (input_password.Equals(password)) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    internal static void Restock() {
        Console.Clear();
        Report();

        Console.Write($"\nWhich resources would you like to restock? Seperate multiple resources with commas: ");
        string resources_input = (Console.ReadLine() ?? "0").Replace(" ", "").ToLower();
        string[] resources = resources_input.Split(',');
        resources = resources.Distinct().ToArray();

        foreach (string resource in resources) {
            switch (resource) {
                case "water":
                    Resources.water = 300;
                    break;
                case "milk":
                    Resources.milk = 200;
                    break;
                case "coffee":
                    Resources.coffee = 100;
                    break;
                default:
                    break;
            }
        }

        Console.Clear();
        Report(true);
    }

    internal static void Report(bool wait = false) {
        Console.WriteLine($"Water: {Resources.water} mL");
        Console.WriteLine($"Milk: {Resources.milk} mL");
        Console.WriteLine($"Coffee: {Resources.coffee} g");

        if (wait) {
            Console.Write($"\nPress enter to continue: ");
            Console.ReadLine();
        }
    }
}