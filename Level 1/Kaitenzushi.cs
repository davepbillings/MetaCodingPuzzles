// Write any using statements here
using System.Collections.Generic;

class Solution
{

    public int getMaximumEatenDishCount(int N, int[] D, int K)
    {
        // Write your code here
        //N dishes to go through
        //D sushi belt D[i] = sushi type
        //K how many dishes can eat before repeats

        return CountDishesToEat(D, K);
    }
    static int CountDishesToEat(int[] belt, int K)
    {

        /*
        //first attempt solved 32/33 test cases, time limit exceeded on 1 test case
            List<int> recentDishes = new List<int>();
            int count = 0;

            for (int i = 0; i < belt.Length; i++)
            {
              if(recentDishes.Count > K)
              {
                recentDishes.RemoveAt(0);
              }
              if(!recentDishes.Contains(belt[i]))
              {
                recentDishes.Add(belt[i]);
                count++;
              }
            }
          return count;
        */
        //second attempt solved 33/33 test cases
        HashSet<int> rDishes = new HashSet<int>();
        List<int> types = new List<int>();
        int count = 0;
        int tCount = 0;
        for (int i = 0; i < belt.Length; i++)
        {
            if (rDishes.Count > K)
            {
                rDishes.Remove(types[tCount]);
                tCount++;
            }
            if (rDishes.Add(belt[i]))
            {
                count++;
                types.Add(belt[i]);
            }
        }

        return count;

    }
}
