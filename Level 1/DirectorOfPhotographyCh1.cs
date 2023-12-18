/* a photoset consists of N cells numbered 1 to N, represented by string C of length N, each cell can be 'P','A','B',or '.'
** a photo is considered artistic if the distance between ('P' and 'A') and ('B' and 'A') is between X and Y (inclusive) 
** determine number of artistic photos that are within the set where at least one element is different
*/
// Write any using statements here
using System.Collections.Generic;
class Solution
{

    public int getArtisticPhotographCount(int N, string C, int X, int Y)
    {
        // Write your code here
        // first attempt solved 39/39 test cases
        int mCount = 0;
        for (int i = 0; i < C.Length; i++)
        {
            char firstChar = C[i];
            if (firstChar == 'P')
            {
                for (int j = i + 1; j < C.Length; j++)
                {
                    char secondChar = C[j];
                    if (secondChar == 'A' && IsArtistic(X, Y, i, j))
                    {
                        for (int k = j + 1; k < C.Length; k++)
                        {
                            char thirdChar = C[k];
                            if (thirdChar == 'B' && IsArtistic(X, Y, j, k))
                            {
                                mCount++;
                            }
                        }
                    }
                }

                for (int j = i - 1; j >= 0; j--)
                {
                    char secondChar = C[j];
                    if (secondChar == 'A' && IsArtistic(X, Y, i, j))
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            char thirdChar = C[k];
                            if (thirdChar == 'B' && IsArtistic(X, Y, j, k))
                            {
                                mCount++;
                            }
                        }
                    }
                }
            }
        }
        return mCount;

    }

    public bool IsArtistic(int minDist, int maxDist, int index1, int index2)
    {
        bool temp = false;
        if (Math.Abs(index1 - index2) >= minDist && Math.Abs(index1 - index2) <= maxDist)
        {
            temp = true;
        }
        return temp;
    }
}