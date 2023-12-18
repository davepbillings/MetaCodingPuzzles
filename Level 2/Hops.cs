// Write any using statements here

class Solution
{

    public long getSecondsRequired(long N, int F, long[] P)
    {
        // Write your code here
        //F frogs need to cross to Lilypad N
        //lilypads P[] have frogs on P[i], frogs will jump to next empty pad and over all taken pads

        //sort taken lilypad list, fewest jumps will equal distance from farthest frog (P[0]) to final pad, any pad already taken will be skipped so no jumps can repeat 
        //solves 32/32 test cases
        Array.Sort(P);

        return Math.Abs(P[0] - N);

    }

}
