/*
1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

Natural numbers only? need for signed ints?
How to return data? do we need a count and a value or just the value that is the mode?
majority matters here. not just most frequent, but since we assume that majority is always present, then mode will also work here

int[] = {1,2,2,2,2,4,3,2} --> 2
int[] = {1,2,3,3,3,3,1,1,1,1} --> 1

first thought is to create a dict and the value is the count
return the key for the highest value
use LINQ to create dict

inputArray[]
arrayDict =  new
foreach i in inputArray
if (arrayDict !contains i)
    add to dict
else 
    value++
    
foreach value in kvp
if (value  > inputArray.lenght/2
int majority = value
*/

int[] inputArray = {1,2,2,2,2,4,3,2};
var arrayDict = new Dictionary<int, int>();

int FindMajority(int[] inputArray)
{
    int majority = 0;

    foreach (var i in inputArray)
        if (!arrayDict.ContainsKey(i))
            arrayDict.Add(i, 1);
        else
            arrayDict[i]++;

    foreach (var kvp in arrayDict)
        if (kvp.Value > inputArray.Length / 2)
            return kvp.Key;
    return -1;
}


Console.WriteLine($"""
                   
                   The majority element in array {string.Join(", ", inputArray)} 
                   is: {string.Join(", ", FindMajority(inputArray))}
                   
                   """);