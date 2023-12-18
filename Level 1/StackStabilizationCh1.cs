// Write any using statements here

class Solution
{

    public int getMinimumDeflatedDiscCount(int N, int[] R)
    {
        // Write your code here
        int deflations = minDeflations(R);
        return deflations;
    }

    public int minDeflations(int[] R)
    {
        //second attempt, solved 33/33 test cases
        int N = R.Length;
        int toBeDeflated = 0;

        int prev = -1;
        for (int i = N - 1; i >= 0; i--)
        {
            if (i != N - 1 && R[i] >= prev)
            {
                if (prev <= i + 1)
                {
                    return -1;
                }
                toBeDeflated++;
                prev = prev - 1;
            }
            else
            {
                prev = R[i];
            }
        }
        return toBeDeflated;
    }
    /*
    //first attempt, solved test sample cases but only solved 9/32 test cases
    int stable=0;
    bool impossible = false;
    
    for(int i = 0; i < R.Length; i++)
    {
      if(R[i] <= i )
      {
        impossible = true;
        break;
      }
      
      for(int j = i+1; j < R.Length; j++)
      {
        if(R[i] >= R[j])
        {
          stable++;
        }
      }
      
    }
    if(stable == R.Length)
    {
      stable--;
    }
    if(impossible)
    {
      stable = -1;
    }
    return stable;
  }
  */
}