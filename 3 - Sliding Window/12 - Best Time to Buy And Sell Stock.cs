public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        int highestPrice = 0;
        
        for (int i = prices.Length - 1; i >= 0; i--) {
            int price = prices[i];
            int profit = highestPrice - price;

            // Update max profit, if needed.
            if (profit > maxProfit)
                maxProfit = profit;

            // Update highest price, if needed.
            if (price > highestPrice)
                highestPrice = price;
        }

        return maxProfit;
    }
}
