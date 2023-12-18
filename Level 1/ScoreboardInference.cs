// Write any using statements here
// solved 34/34 test cases
// there are N competitors who's scores are stored in array S, each score can be made up of a combination of 1's or 2's
// determine the minimum possible number of problems in the contest

class Solution
{

    public int getMinProblemCount(int N, int[] S)
    {
        // Write your code here

        int minCases = 0;
        int maxVal = 0;
        bool hasOddVal = false;

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] > maxVal)
            {
                maxVal = S[i];
            }
            if (S[i] % 2 > 0)
            {
                hasOddVal = true;
            }
        }
        minCases = maxVal / 2;
        if (hasOddVal)
        {
            minCases++;
        }

        return minCases;
    }

}
