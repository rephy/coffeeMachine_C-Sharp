using System;
using org.mariuszgromada.math.mxparser;

public static class Calculator {
    static Calculator() {
        License.iConfirmNonCommercialUse("Raphael Manayon");
    }

    public static double Calculate(string expression) {
        Expression exp = new Expression(expression);
        return exp.calculate();
    }
}