// Write any using statements here
using System.Collections.Generic;
class Solution
{
    //same problem as Level 1 director of photography but with a larger constraint on N, requiring more time efficiency

    public long getArtisticPhotographCount(int N, string C, int X, int Y)
    {
        // Write your code here
        //solves 39/39 test cases
        long[] B = new long[N + 1], P = new long[N + 1];
        long ans = 0;
        //running sum of P and B characters to compare in later

        for (int i = 1; i <= N; i++)
        {
            char curr = C[i - 1];
            P[i] = P[i - 1] + ((curr == 'P') ? 1 : 0);
            B[i] = B[i - 1] + ((curr == 'B') ? 1 : 0);
        }
        //check every Actor index against sum of P's and B's on either side within windows

        for (int i = 0; i < N; i++)
        {
            if (C[i] == 'A')
            {
                int fstart = (i + X) <= N ? (i + X) : N;
                int fend = (i + Y + 1) <= N ? (i + Y + 1) : N;
                int bend = (i - X + 1) >= 0 ? (i - X + 1) : 0;
                int bstart = (i - Y) >= 0 ? (i - Y) : 0;
                ans += (P[fend] - P[fstart]) * (B[bend] - B[bstart]);
                ans += (B[fend] - B[fstart]) * (P[bend] - P[bstart]);
            }
        }

        return ans;


        /*
        first pass, solved 35/39, exceeded runtime on 4/39

        int aCount =0;
        for(int i = 0; i < C.Length; i++)
        {
          if(C[i] == 'A')
          {
            //if minDistance + index is greater than last actor or index is less than min distance, can't be artistic, break
            if(i < X)
            {
              continue;
            }
            if(i+X > C.Length-1)
            {
              break;
            }

            aCount += ArtisticCounter('P','B',i,C,X,Y);
            aCount += ArtisticCounter('B','P',i,C,X,Y);
          }
        }
        return aCount
        */

    }

    /*public int ArtisticCounter(char left, char right, int index, string s,int minD, int maxD)
    {

      int lCount = 0;
      int rCount = 0;
      //count left

      for(int i = minD; i <= maxD; i++)
      {
        if(index-i >=0)
        {
          if(s[index-i] == left)
          {
            lCount++;
          }
        }
        if(index+i < s.Length)
        { 
          if(s[index+i] == right)
          {
            rCount++;
          }
        }
      }
      if(lCount>0 && rCount>0)
      {
        return lCount*rCount;
      }
      return 0;
    }
    */
}