// Write any using statements here

class Solution
{

    public long getMinCodeEntryTime(int N, int M, int[] C)
    {
        // Write your code here
        //solved 32/32 test cases
        //
        //possible numbers N, starts at 1
        //sequence C length of M, 1 second to rotate, 0 seconds to select when pointing
        //determine min seconds

        long time = CalculateMinSeconds(N, C);

        return time;
    }
    public long CalculateMinSeconds(int numbers, int[] combination)
    {
        long position = 1;
        long time = 0;

        for (long i = 0; i < combination.Length; i++)
        {
            if (position != combination[i])
            {
                long targetPosition = combination[i];

                // Calculate clockwise and anticlockwise turns separately
                long clockwiseDistance = (targetPosition - position + numbers) % numbers;
                long anticlockwiseDistance = (position - targetPosition + numbers) % numbers;

                time += Math.Min(clockwiseDistance, anticlockwiseDistance);

            }
            position = combination[i];

        }

        // Return the minimum of clockwise and anticlockwise turns
        return time;
    }


}
