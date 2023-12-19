// Write any using statements here

class Solution
{

    public double getMaxDamageDealt(int N, int[] H, int[] D, int B)
    {
        // Write your code here
        //solved 24/24 test cases

        //there are N warriors, each warrior has H[i] health and deals D[i] damage per second
        //each second the boss deals B damage to the first warrior until they run out of HP and then attacks the second warrior
        //damage is dealt simultaneously, a warrior will deal % damage equal to the time they survived a boss attack.
        //find the highest possible damage dealt by two warriors.

        int warrior1 = 0;
        int warrior2 = 0;
        double tempCombo = 0.0;

        //find highest combat potential for first warrior to check against
        for (int i = 0; i < N; i++)
        {
            if (combatPotential(i, B, D, H) >= combatPotential(warrior1, B, D, H))
            {
                warrior1 = i;
            }
        }

        //initial sort through all combos against highest combat potential to find possible answer for highest damage
        for (int i = 0; i < N; i++)
        {
            if (i != warrior1)
            {
                if (Math.Max(combatDamage(warrior1, i, B, D, H), combatDamage(i, warrior1, B, D, H)) > tempCombo)
                {
                    warrior2 = i;
                    tempCombo = Math.Max(combatDamage(warrior1, i, B, D, H), combatDamage(i, warrior1, B, D, H));
                }
            }
            if (i != warrior2)
            {
                if (Math.Max(combatDamage(warrior2, i, B, D, H), combatDamage(i, warrior2, B, D, H)) > tempCombo)
                {
                    warrior1 = i;
                    tempCombo = Math.Max(combatDamage(warrior2, i, B, D, H), combatDamage(i, warrior2, B, D, H));
                }
            }
        }

        //cleanup filter against pairs for total damage
        for (int i = 0; i < N; i++)
        {
            if (i != warrior1)
            {
                if (Math.Max(combatDamage(warrior1, i, B, D, H), combatDamage(i, warrior1, B, D, H)) > tempCombo)
                {
                    warrior2 = i;
                    tempCombo = Math.Max(combatDamage(warrior1, i, B, D, H), combatDamage(i, warrior1, B, D, H));
                }
            }
            if (i != warrior2)
            {
                if (Math.Max(combatDamage(warrior2, i, B, D, H), combatDamage(i, warrior2, B, D, H)) > tempCombo)
                {
                    warrior1 = i;
                    tempCombo = Math.Max(combatDamage(warrior2, i, B, D, H), combatDamage(i, warrior2, B, D, H));
                }
            }
        }


        return Math.Max(combatDamage(warrior1, warrior2, B, D, H), combatDamage(warrior2, warrior1, B, D, H));

    }
    double combatPotential(int warrior, int B, int[] D, int[] H)
    {
        decimal turnsW1Alive = Decimal.Divide(H[warrior], B);
        decimal damageW1 = (turnsW1Alive * D[warrior]);
        return (double)damageW1;
    }

    double combatDamage(int w1, int w2, int B, int[] D, int[] H)
    {
        decimal turnsW1Alive = Decimal.Divide(H[w1], B);
        decimal turnsW2Alive = Decimal.Divide(H[w2], B);
        decimal damageW1 = (turnsW1Alive * D[w1]);
        decimal damageW2 = (turnsW2Alive * D[w2]) + (turnsW1Alive * D[w2]);
        return (double)(damageW1 + damageW2);
    }
}