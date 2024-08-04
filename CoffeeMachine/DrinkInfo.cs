using System;

namespace CoffeeMachine;

public class DrinkInfo {
    public Order this_order;
    public int water_required;
    public int milk_required;
    public int coffee_required;
    public decimal cost;

    public DrinkInfo(Order order) {
        this.this_order = order;
        switch (order) {
            case Order.Espresso:
                this.water_required = 50;
                this.coffee_required = 18;
                this.cost = 1.50M;
                break;
            case Order.Latte:
                this.water_required = 200;
                this.coffee_required = 24;
                this.milk_required = 150;
                this.cost = 2.50M;
                break;
            case Order.Cappuccino:
                this.water_required = 250;
                this.coffee_required = 24;
                this.milk_required = 100;
                this.cost = 3M;
                break;
        }
    }
}