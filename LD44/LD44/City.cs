using System;

namespace LD44
{
    public class City
    {
        public City()
        {
        }

        int lastCityPopPercent = 100;

        public void Simulate(Tile[,] tiles)
        {
            if (!StaticPlayer.IsCityDead)
            {
                StaticPlayer.StagnationCoefficient += StaticPlayer.TurnsSinceLastAction / 50;

                if ((int)StaticPlayer.CityPopPercent < 100)
                {
                    StaticPlayer.CityPopPercent += 0.01f / StaticPlayer.StagnationCoefficient;
                }

                if ((int)StaticPlayer.CityHappiness < 100)
                {
                    StaticPlayer.CityHappiness += 0.05f / StaticPlayer.StagnationCoefficient;
                }

                if (StaticPlayer.CityCrimeRate < 100)
                {
                    if (StaticPlayer.CityPopPercent < 100)
                        StaticPlayer.CityCrimeRate += (StaticPlayer.CityPopPercent / 100) * StaticPlayer.StagnationCoefficient;
                }

                if (StaticPlayer.CityHappiness > 0)
                {
                    if (lastCityPopPercent <= StaticPlayer.CityPopPercent) // city is stagnant
                        StaticPlayer.CityHappiness -= 0.01f;
                    StaticPlayer.CityHappiness -= ((StaticPlayer.CityCrimeRate * (StaticPlayer.CityUnemployment * 2)) / 1000) / StaticPlayer.StagnationCoefficient;
                }

                if (StaticPlayer.CityUnemployment < 100)
                {
                    if ((int)StaticPlayer.CityPopPercent > lastCityPopPercent)
                    {
                        StaticPlayer.CityUnemployment += 0.1f * StaticPlayer.StagnationCoefficient;
                    }
                }

                if (StaticPlayer.CityHealth > 0)
                {
                    StaticPlayer.CityHealth -= ((100 - StaticPlayer.CityHappiness) / 80) * StaticPlayer.StagnationCoefficient;
                }
                else
                {
                    StaticPlayer.IsCityDead = true;
                }
                lastCityPopPercent = (int)StaticPlayer.CityPopPercent;

                StaticPlayer.Heart -= 0.1f;
                StaticPlayer.Soul -= 0.1f;

                int numberOfBuildings = 0;
                foreach (Tile t in tiles)
                {
                    if (t.Name == "SUPERMART")
                    {
                        StaticPlayer.CityUnemployment -= (25 / (StaticPlayer.CityPopPercent / 25)) / (500 * StaticPlayer.StagnationCoefficient);
                        numberOfBuildings++;
                    }

                    if (t.Name == "GAS")
                    {
                        StaticPlayer.CityUnemployment -= (5 / (StaticPlayer.CityPopPercent / 25)) / (500 * StaticPlayer.StagnationCoefficient);
                        numberOfBuildings++;
                    }

                    if (t.Name == "OFFICE")
                    {
                        StaticPlayer.CityUnemployment -= (50 / (StaticPlayer.CityPopPercent / 25)) / (500 * StaticPlayer.StagnationCoefficient);
                        numberOfBuildings++;
                    }

                    if (t.Name == "HIGHRISE")
                    {
                        StaticPlayer.CityPopPercent -= (10 / (StaticPlayer.CityPopPercent / 10)) / (2 * StaticPlayer.StagnationCoefficient);
                        numberOfBuildings++;
                    }

                    if (t.Name == "HOUSE")
                    {
                        StaticPlayer.CityPopPercent -= (5 / (StaticPlayer.CityPopPercent / 10)) / (2 * StaticPlayer.StagnationCoefficient); 
                        numberOfBuildings++;
                    }

                    if (t.Name == "SHACK")
                    {
                        StaticPlayer.CityPopPercent -= (0.5f / (StaticPlayer.CityPopPercent / 10)) / (2 * StaticPlayer.StagnationCoefficient);
                        numberOfBuildings++;
                    }

                    if (t.Name == "POLICE")
                    {
                        StaticPlayer.CityCrimeRate -= (5 / (StaticPlayer.StagnationCoefficient * 2));
                        numberOfBuildings++;
                    }

                    if (t.Name == "GYM")
                    {
                        StaticPlayer.CityHappiness += 100 / (StaticPlayer.CityHappiness * 2.5f) / StaticPlayer.StagnationCoefficient;
                        numberOfBuildings++;
                    }

                    if (t.Name == "BAR")
                    {
                        StaticPlayer.CityHappiness += 250 / (StaticPlayer.CityHappiness * 2.5f) / StaticPlayer.StagnationCoefficient;
                        numberOfBuildings++;
                    }

                    if (t.Name == "PLAYGROUND")
                    {
                        StaticPlayer.CityHappiness += 150 / (StaticPlayer.CityHappiness * 2.5f) / StaticPlayer.StagnationCoefficient;
                        numberOfBuildings++;
                    }
                }

                StaticPlayer.CityCrimeRate += numberOfBuildings;

                if (StaticPlayer.CityCrimeRate > 100) StaticPlayer.CityCrimeRate = 100;
                if (StaticPlayer.CityUnemployment < 0) StaticPlayer.CityUnemployment = 0;
                if (StaticPlayer.CityPopPercent < 0) StaticPlayer.CityPopPercent = 0;
                if (StaticPlayer.CityCrimeRate < 0) StaticPlayer.CityCrimeRate = 0;
                if (StaticPlayer.CityHappiness > 100) StaticPlayer.CityHappiness = 100;
                if (StaticPlayer.CityHappiness < 0) StaticPlayer.CityHappiness = 0;
            }
        }
    }
}