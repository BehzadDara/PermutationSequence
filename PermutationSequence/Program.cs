#region Problem
/*
The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

Example 1:
Input: n = 3, k = 3
Output: "213"

Example 2:
Input: n = 4, k = 9
Output: "2314"

Example 3:
Input: n = 3, k = 1
Output: "123"

LeetCode link: https://leetcode.com/problems/permutation-sequence/
*/
#endregion

#region Solution

Console.WriteLine(GetPermutation(4, 15));
static string GetPermutation(int n, int k)
{
    if (n == 1)
        return "1";

    var nextBase = Factorail(n - 1);

    var digit = Math.Ceiling((double)k / nextBase);
    if (digit == 0)
        digit = n;
    
    var result = digit.ToString();

    var tmpResult = GetPermutation(n - 1, k % nextBase);
    foreach (char c in tmpResult)
    {
        var tmpDigit = int.Parse(c.ToString());

        if (tmpDigit >= digit)
            result += tmpDigit + 1;
        else
            result += tmpDigit;
    }

    return result;
}

static int Factorail(int n)
{
    var result = 1;

    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }

    return result;
}

#endregion