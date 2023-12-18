/*cafeteria table consists of N seats 1 to N from left to right. K seats to left and K seats to right must remain empty.
**currently M diners sitting in S seats.
**determine maximum number of additional diners who can sit assuming that existing diners cannot move.
**
*/
// Write any using statements here
using System.Collections.Generic;
using System.Collections;
using System.Linq;
class Solution
{

    public long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
    {
        // Write your code here
        //second attempt, solved 32/32 test cases
        long minSeats = K + 1;
        if (M == 0)
        {
            return N / minSeats + 1;
        }

        Array.Sort(S);
        long result = 0L;

        long firstChair = S[0];
        long firstAvailableIndex = (firstChair - 1) - minSeats;
        if (firstAvailableIndex >= 0)
        {
            result += firstAvailableIndex / minSeats + 1;
        }

        for (int index = 0; index < M - 1; index++)
        {

            long leftFreeChair = S[index] + minSeats;
            long rightFreeChair = S[index + 1] - minSeats;
            long diffSpace = rightFreeChair - leftFreeChair;
            if (diffSpace >= 0)
            {
                result += diffSpace / minSeats + 1;
            }
        }

        long lastChair = S[M - 1];
        long lastAvailableIndex = (lastChair - 1) + minSeats;
        if (lastAvailableIndex <= N - 1)
        {
            result += (N - 1 - lastAvailableIndex) / minSeats + 1;
        }

        return result;

        /*
        //first attempt, solved 29/32 test cases, runtime error on 3/32 test cases
        BitArray takenSeatIndices = new BitArray(Convert.ToInt32(N));
        long maxSeats = 0L;
        int step = (int)K+1;
        for (int t = 0; t < S.Length; ++t)
        {
            int start = (int)(Math.Max(0, S[t] - 1 - K));
            int end = (int)(Math.Min(N, S[t] + K));

            for (int i = start; i < end; ++i)
            {
                takenSeatIndices.Set(i, true);
            }
        }

        for (int i = 0; i < N;)
        {
            if (!takenSeatIndices[i])
            {
                ++maxSeats;
                i += step;
            }
            else
            {
                ++i;
            }
        }

        return maxSeats;
        */
    }

}