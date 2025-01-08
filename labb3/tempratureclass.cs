using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb3
{
    class TemperatureAnalyzer
    {
        static private int[] temperatures;

        public TemperatureAnalyzer(int daysInMonth)
        {
            temperatures = new int[daysInMonth];
            PopulateRandomTemperatures();
        }

        private void PopulateRandomTemperatures()
        {
            Random random = new Random();
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = random.Next(-10, 31); // Temperatures between -10 and 30 degrees
            }
        }

        public void ListTemperatures()
        {
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: {temperatures[i]}°C");
            }
        }

        public int CalculateAverageTemperature()
        {
            return (int)Math.Round(temperatures.Average());
        }

        public (int day, int temperature) FindMaxTemperature()
        {
            int maxTemp = temperatures.Max();
            int day = Array.IndexOf(temperatures, maxTemp) + 1;
            return (day, maxTemp);
        }

        public (int day, int temperature) FindMinTemperature()
        {
            int minTemp = temperatures.Min();
            int day = Array.IndexOf(temperatures, minTemp) + 1;
            return (day, minTemp);
        }

        public double CalculateMedianTemperature()
        {
            var sortedTemps = temperatures.OrderBy(t => t).ToArray();
            int midIndex = sortedTemps.Length / 2;

            if (sortedTemps.Length % 2 == 0)
            {
                return (sortedTemps[midIndex - 1] + sortedTemps[midIndex]) / 2.0;
            }
            return sortedTemps[midIndex];
        }

        public void SortTemperatures(bool ascending = true)
        {
            var sortedTemps = ascending
                ? temperatures.OrderBy(t => t).ToArray()
                : temperatures.OrderByDescending(t => t).ToArray();

            Console.WriteLine("Sorted Temperatures:");

            // Keep track of used indices to handle duplicate temperatures correctly
            var usedIndices = new HashSet<int>();

            foreach (var temp in sortedTemps)
            {
                // Manually find the day (index) for the current temperature
                for (int i = 0; i < temperatures.Length; i++)
                {
                    if (temperatures[i] == temp && !usedIndices.Contains(i))
                    {
                        usedIndices.Add(i); // Mark this index as used
                        Console.WriteLine($"Day {i + 1}:\t{temp}°C"); // Day is 1-based
                        break; // Stop searching for this temperature
                    }
                }
            }
        }


        public void FilterTemperaturesAboveThreshold(int threshold)
        {
            Console.WriteLine($"Temperatures above {threshold}°C:");

            for (int i = 0; i < temperatures.Length; i++)
            {
                if (temperatures[i] > threshold)
                {
                    Console.WriteLine($"Day {i + 1}: {temperatures[i]}°C");
                }
            }
        }

        public void GetSurroundingTemperatures(int day)
        {
            if (day < 1 || day > temperatures.Length)
            {
                Console.WriteLine("Invalid day.");
                return;
            }

            int prevTemp = day > 1 ? temperatures[day - 2] : int.MinValue;
            int nextTemp = day < temperatures.Length ? temperatures[day] : int.MinValue;

            Console.WriteLine($"Day {day}: {temperatures[day - 1]}°C");
            if (prevTemp != int.MinValue)
                Console.WriteLine($"Previous Day: {prevTemp}°C");
            if (nextTemp != int.MinValue)
                Console.WriteLine($"Next Day: {nextTemp}°C");
        }

        public int FindMostCommonTemperature()
        {
            return temperatures.GroupBy(t => t).OrderByDescending(g => g.Count()).First().Key;
        }
    }
}