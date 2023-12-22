// Write any using statements here
using System.Collections.Generic;
class Solution
{
    //solves 35/35 test cases
    public int getMaxCollectableCoins(int R, int C, char[,] G)
    {
        // Write your code here

        //grid of cells G, rows 1 to R top to bottoms and columns 1 to C left to right
        //the grid wraps horizontally
        //each cell contains one of the following
        // '.' = empty
        // '*' = coin
        // '>' = arrow pointing right
        // 'v' = arrow pointing down
        //each row may be shifted any number of times to the right (will wrap back around)
        //starting from the top left cell travel through the grid, traveling down until hitting an arrow pointing right. and then right until hitting a down arrow.
        //possible to loop forever on a row.
        //determine maximum number of coins you can collect

        List<RowData> rows = new List<RowData>();
        int maxCoins = 0;

        //get data for each row
        for (int i = 0; i < R; i++)
        {
            int e = 0;
            int c = 0;
            int r = 0;
            int d = 0;
            int ls = 0;
            int tempStreak = 0;
            bool canStreak = false;
            int? streakIndex = null;
            //go through row
            for (int j = 0; j < C; j++)
            {
                if (G[i, j] == '.') { e++; }
                if (G[i, j] == '*')
                {
                    c++;
                    if (canStreak)
                    {
                        tempStreak++;
                    }
                    if (tempStreak > ls)
                    {
                        ls = tempStreak;
                    }

                }
                if (G[i, j] == '>')
                {
                    canStreak = true;
                    if (streakIndex == null)
                    {
                        streakIndex = j;
                    }
                    r++;
                }
                if (G[i, j] == 'v')
                {
                    canStreak = false;
                    streakIndex = null;
                    tempStreak = 0;
                    d++;
                }
            }

            //set longestStreak to 1 if row contains no rightarrows && c > 0
            if (r == 0 && c > 0)
            {
                ls = 1;
            }
            //run back through row till first down arrow is hit to cover case when wrapping and see if its larger than ls
            if (r > 0)
            {
                for (int j = 0; j < C; j++)
                {
                    if (G[i, j] == '*' && canStreak)
                    {
                        tempStreak++;
                        if (tempStreak > ls)
                        {
                            ls = tempStreak;
                        }
                    }
                    //break when down arrow occurs
                    if (G[i, j] == 'v' || j == streakIndex)
                    {
                        tempStreak = 0;
                        break;
                    }
                }
            }
            //set ls to 1 if has coins to account for fallthrough if ls was previously 0
            if (ls == 0 && c > 0)
            {
                ls = 1;
            }
            //finished going through row, assign rowdata
            rows.Add(new RowData(c, e, d, r, ls));
            //stop calculating data if a row that cannot be passed occurs
            if (c == 0 && e == 0 && d == 0 && r > 0)
            {
                break;
            }
        }

        //start calculating total coins possible from bottom up and reset to 0 if encountering row that can't be passed
        for (int i = rows.Count - 1; i > -1; i--)
        {
            //when row contains impassible ie all right arrows
            if (rows[i].numCoins == 0 && rows[i].numEmpty == 0 && rows[i].numDown == 0 && rows[i].numRight > 0)
            {
                maxCoins = 0;
                continue;
            }
            //add largestStreak to running count if row has down direction
            if (rows[i].numDown > 0 && rows[i].numCoins > 0)
            {
                maxCoins += rows[i].largestStreak;
                continue;
            }
            //if rows largest streak is greater than current max coins and there is no down char, set max to largest streak and continue up chain
            if (rows[i].numDown == 0 && rows[i].largestStreak > maxCoins && rows[i].numCoins > 0)
            {
                maxCoins = rows[i].largestStreak;
                continue;
            }
            if (rows[i].numDown == 0 && rows[i].largestStreak <= maxCoins && rows[i].numCoins > 0)
            {
                maxCoins += 1;
                continue;
            }
        }



        return maxCoins;
    }



}
public class RowData
{
    public int numCoins = 0;
    public int numEmpty = 0;
    public int numDown = 0;
    public int numRight = 0;
    public int largestStreak = 0;

    public RowData(int c, int e, int d, int r, int ls)
    {
        this.numCoins = c;
        this.numEmpty = e;
        this.numDown = d;
        this.numRight = r;
        this.largestStreak = ls;
    }
}