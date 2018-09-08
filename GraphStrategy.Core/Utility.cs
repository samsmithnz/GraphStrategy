using System;

namespace GraphStrategy.Core
{
    public static class Utility
    {
        /// <summary>
        /// Generate a random number (int) within lower and upper bounds
        /// </summary>
        private static System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        public static int GenerateRandomNumber(int lowerBound, int upperBound)
        {
            int result = rnd.Next(lowerBound, upperBound + 1); //+1 because the upperbound is never used
            //Debug.LogWarning("GenerateRandomNumber (range " + lowerBound + "-" + upperBound + "): " + result);
            return result;
        }

        ///// <summary>
        ///// Take in a chanced to hit from 1- 100. Compare against a random number to return a result
        ///// </summary>
        ///// <param name="chanceToHit">% chance to hit</param>
        ///// <returns>int > 0 if hit, <= 0 if missed</returns>
        //public static int CalculateChanceToHit(int chanceToHit)
        //{
        //    int randomNumber = GenerateRandomNumber(1, 100);

        //    //By subtracting 100 from the chance, we are reversing it. 
        //    //So an 85% chance will hit if the roll is 15 or higher. 
        //    //This makes more sense to me, as a high roll means a critical hit and a lot roll means a critical miss. 
        //    //if ((100 - chanceToHit) < randomNumber)
        //    //{
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
        //    //Debug.Log("chanceToHit result: " + (randomNumber - (100 - chanceToHit)).ToString());
        //    return randomNumber - (100 - chanceToHit);
        //}
    }
}
