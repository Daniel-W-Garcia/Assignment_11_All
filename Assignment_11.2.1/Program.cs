/*
1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

You are given an array prices where prices[i] is the price of a given stock on the ith day.
You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

we are basically trying to get the largest possible total of 2 subtracted ints.
array is sequential in that you can only subtract ints that are indexed after your starting int

for :
int[] {8, 6, 7, 5, 3, 0, 9}

the answer is 9 because we can buy at index 5 and sell at index 6

we need to find the largest n value of i[start] + n = i[end]

this seems like a pretty straight forward task. only question is if we have to handle only natural numbers of decimals
problem doesnt state complexity restraints or memory constraints.
we know we can't use a hashset for this because we can't eliminate dupes

I think we start with a right pointer and subtract previous index. 
store 'highest n value' and compare. 

option 1: 2 pointers

n = right pointer minus left pointer
if n > current max, n = current max
Outer loop right pointer
inner loop all nums to the left of right pointer

O(n^2)

option 2: 1 pointer and compare as we go. grab smallest value 

set max profit to 0
set a minimum price to the start of the array. 
if min price is greater than i, then min price = i
profit = i - min price

O(n)

*/

int BuffetsCrystalBall(int[] stockPrices)
{
    if(stockPrices.Length <= 1)
    {
        Console.WriteLine("You can't make any money. You are now holding bags");
        return 0; // you are now a 'bag holder'
    }
    
    int minPrice = stockPrices[0];
    int maxProfit = 0;
    
    for(int i = 1; i < stockPrices.Length; i++)
    {
        if(stockPrices[i] < minPrice) // also Math.Min(minPrice, stockPrices[i]) does this in one line
        {
            minPrice = stockPrices[i];
        }
        int profit = stockPrices[i] - minPrice;
        if(profit > maxProfit) // also Math.Max(maxProfit, profit) does this in one line
        {
            maxProfit = profit;
        }
    }
    return maxProfit;
}

int[] riggedStockMarket = {8, 6, 7, 5, 3, 0, 9};
int getPaid = BuffetsCrystalBall(riggedStockMarket);

Console.WriteLine();
Console.WriteLine($"By knowing the price of a stock all week, you can make: {getPaid} dollars.");
Console.WriteLine();