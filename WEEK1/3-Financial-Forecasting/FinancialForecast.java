public class FinancialForecast {
    public static double forecastValueIterative(double currentValue, double growthRate, int years) {
        for (int i = 0; i < years; i++) {
            currentValue *= (1 + growthRate);
        }
        return currentValue;
    }

    public static double forecastValueOptimized(double currentValue, double growthRate, int years) {
        return currentValue * Math.pow(1 + growthRate, years);
    }

    // Recursive method to calculate future value
    public static double forecastValue(double currentValue, double growthRate, int years) {
        if (years == 0) {
            return currentValue;
        }

        return forecastValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    public static void main(String[] args) {
        double initialValue = 1000.0; // Initial investment
        double annualGrowthRate = 0.10; // 10% annual growth
        int years = 5;

        double forecastedValue = forecastValue(initialValue, annualGrowthRate, years);
        double forecastedValueIterative = forecastValueIterative(initialValue, annualGrowthRate, years);
        double forecastedValueOptimized = forecastValueOptimized(initialValue, annualGrowthRate, years);
        System.out.printf("Forecasted value after %d years: %.2f\n", years, forecastedValue);
        System.out.printf("forecastedIterative value after %d years: %.2f\n", years, forecastedValueIterative);
        System.out.printf("forecastedOptimized value after %d years: %.2f\n", years, forecastedValueOptimized);
    }
}
