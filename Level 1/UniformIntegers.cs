// Write any using statements here
using System.Linq;

class Solution
{
    //given two integers A and B determine the number of integers between them that are made up of the same number etc 22 33 44
    //first attempt solved 32/33 test cases, time limit exceeded on 1/33 test cases
    //second attempt solved 33/33 test cases

    public int getUniformIntegerCountInInterval(long A, long B)
    {
        // Write your code here
        //int uniforms = 0;
        
        /*
        if(A == B)
        {
          uniforms++;
          return uniforms;
        }

        for(long i = A; i <= B ; i++)
        {
            if(i<10)
            {
              uniforms++;
            }
            if(i>10)
            {
              if(isUniform(i.ToString()))
              {
                uniforms++;
                i += iterationJump(i)-1;
              }
            }
        }
        */
        return generateUniforms(A, B);//uniforms;
    }
    int generateUniforms(long A, long B)
    {
        int count = 0;
        long num = 1;
        while (num < A)
        {
            num = checkVal(num);
        }
        while (num >= A && num <= B)
        {
            num = checkVal(num);
            count++;
        }


        return count;
    }

    long checkVal(long i)
    {
        long val = i;
        if (val < 9)
        {
            val++;
            return val;
        }
        if (val == 9)
        {
            val = 11;
            return val;
        }

        if (i % 10 < 9)
        {
            string k = ((i % 10) + 1).ToString();
            val = long.Parse(new String(k[0], i.ToString().Length));
        }
        if (i % 10 == 9)
        {
            val = long.Parse(new String('1', i.ToString().Length + 1));
        }

        return val;
    }

    /*
    long iterationJump(long i)
    {
      long jump = 1;
      string s = i.ToString();
      int digit = s[0]-'0';

      if(digit < 9)
      {
        jump = i/(digit);
      }
      if(digit == 9)
      {
        long nextNum = long.Parse(new String('1',s.Length+1));
        jump = nextNum - i;
      }

      return jump;
    }

    bool isUniform(string s)
    {
      for(int i = 1; i < s.Length; i++)
      {
        if(s[i] != s[0])
        {
          return false;
        }
      }

      return true;
    }
    */
}