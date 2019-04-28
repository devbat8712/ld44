namespace LD44
{
    public class StaticPlayer
    {
        // Player stats
        public static float Heart = 100;
        public static float Soul = 100;

        //City stats
        public static float CityHealth = 50;
        public static float CityPopPercent = 100;
        public static float CityCrimeRate = 10;
        public static float CityUnemployment = 100;
        public static float CityHappiness = 100;
        public static bool IsCityDead = false;

        //Time
        public static int TimeHour = 9;
        public static int TimeMinute = 32;
        public static int Days;

        public static int TurnsSinceLastAction = 0;
        public static float StagnationCoefficient = 1;

        public static void ResetStats()
        {
            Heart = 100;
            Soul = 100;

            //City stats
            CityHealth = 50;
            CityPopPercent = 100;
            CityCrimeRate = 10;
            CityUnemployment = 100;
            CityHappiness = 100;
            IsCityDead = false;

            //Time
            TimeHour = 9;
            TimeMinute = 32;
            Days = 0;

            TurnsSinceLastAction = 0;
            StagnationCoefficient = 1;
        }

        public static void AddToCityHealth(float amount)
        {
            CityHealth += amount;
            if (CityHealth > 100) CityHealth = 100;
        }
    }
}