using System;
using System.Threading;

namespace CoffeeMachine;

public class Operation {
    public static void Operate(string[] args) {
        Order order = OrderHandler.PreOrder(args);
        while (true) {
            Console.Clear();
            while (order == Order.Unknown) {
                order = OrderHandler.MakeOrder();
                if (order == Order.Unknown) {
                    OrderHandler.InvalidOrder();
                } else if (order == Order.Quit) {
                    Console.WriteLine("\nTurning off...");
                    Thread.Sleep(5000);
                    System.Environment.Exit(1);
                }
            }
            OrderHandler.HandleOrder(order);
            order = Order.Unknown;
        }
    }
}