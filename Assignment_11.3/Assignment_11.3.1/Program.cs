/*


1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again


Given an array of integers arr, replace each element with its rank.

The rank represents how large the element is. The rank has the following rules:

    Rank is an integer starting from 1.
    ***The larger the element, the larger the rank. If two elements are equal, their rank must be the same***
    Rank should be as small as possible.

so it's basically golf score logic. Smallest nums get small rank.
we cannot use sort
we need to find a linear solution
Deepali mentioned LINQ in the chat so that's a good hint.

dealing with natural numbers only, and every number gets a rank, even dupes

examples:
Input: arr = [40,10,20,30]
Output: [4,1,2,3]

Input: arr = [100,100,100]
Output: [1,1,1]

I think using LINQ to make a dicitonary will work

make dict of unique values
assign ranks by values of each element

*/

int[] arr = {40, 10, 20, 30};

static int[] SimplestToRead(int[] arr)
{
    if (arr.Length == 0) return arr;
    
    // Create a lookup table: value -> rank
    var valueRankDict = new Dictionary<int, int>();
    
    var sortedUniqueValues = arr.Distinct().OrderBy(currentValue => currentValue).ToArray(); // For each element, use the element's own value for sorting

    
    for (int i = 0; i < sortedUniqueValues.Length; i++)
    {
        valueRankDict[sortedUniqueValues[i]] = i + 1; // creates a dict with the rank of each element as a kvp
    }
    
    // Now convert original array using the KVP's from the dict. replace the array values (keys in the dict) with the ranks (values in the dict)
    return arr.Select(value => valueRankDict[value]).ToArray();
}

static int[] HardToRead(int[] arr)
{
    if (arr.Length == 0) return arr;
    
    //Get unique values and sort them
    var uniqueValues = arr.Distinct().OrderBy(x => x);
    // For [40,10,20,30] this gives us: [10, 20, 30, 40]
    
    // Create value-to-rank pairs
    var valueRankPairs = uniqueValues.Select((value, index) => new { 
        Value = value, 
        Rank = index + 1 
    });
    // This creates: {10,1}, {20,2}, {30,3}, {40,4}
    
    // Convert to dictionary for fast lookup
    var rankDict = valueRankPairs.ToDictionary(
        pair => pair.Value,  // Key: the original value
        pair => pair.Rank    // Value: the rank
    );
    // Dictionary: {10:1, 20:2, 30:3, 40:4}
    
    // Map each original array element to its rank
    return arr.Select(originalValue => rankDict[originalValue]).ToArray();
}

static int[] ThisIsntEvenEnglish(int[] arr)
{
    if (arr.Length == 0) return arr;
    
    var rankDict = arr
        .Distinct()
        .OrderBy(value => value)
        .Select((value, index) => new { value, rank = index + 1 })
        .ToDictionary(item => item.value, item => item.rank);
    
    return arr.Select(value => rankDict[value]).ToArray();

}
var simplestToRead = SimplestToRead(arr);
var hardToRead = HardToRead(arr);
var thisIsntEvenEnglish = ThisIsntEvenEnglish(arr);

Console.WriteLine(string.Join(", ", simplestToRead));
Console.WriteLine(string.Join(", ", hardToRead));
Console.WriteLine(string.Join(", ", thisIsntEvenEnglish));