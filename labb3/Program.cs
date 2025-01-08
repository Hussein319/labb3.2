using System;
using System.Linq;
using System.Collections.Generic;

namespace labb3
{
    

    class Program
    {
        static void Main(string[] args)
        {
            const int DaysInMay = 31;
            TemperatureAnalyzer analyzer = new TemperatureAnalyzer(DaysInMay);

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. List all temperatures");
                Console.WriteLine("2. Calculate average temperature");
                Console.WriteLine("3. Find the highest temperature");
                Console.WriteLine("4. Find the lowest temperature");
                Console.WriteLine("5. Calculate median temperature");
                Console.WriteLine("6. Sort temperatures");
                Console.WriteLine("7. Filter temperatures above a threshold");
                Console.WriteLine("8. Get surrounding temperatures for a specific day");
                Console.WriteLine("9. Find the most common temperature");
                Console.WriteLine("0. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        analyzer.ListTemperatures();
                        break;
                    case 2:
                        Console.WriteLine($"Average Temperature: {analyzer.CalculateAverageTemperature()}°C");
                        break;
                    case 3:
                        var (maxDay, maxTemp) = analyzer.FindMaxTemperature();
                        Console.WriteLine($"Highest Temperature: {maxTemp}°C on Day {maxDay}");
                        break;
                    case 4:
                        var (minDay, minTemp) = analyzer.FindMinTemperature();
                        Console.WriteLine($"Lowest Temperature: {minTemp}°C on Day {minDay}");
                        break;
                    case 5:
                        Console.WriteLine($"Median Temperature: {analyzer.CalculateMedianTemperature()}°C");
                        break;
                    case 6:
                        Console.WriteLine("Sort in ascending order? (yes/no):");
                        string sortChoice = Console.ReadLine()?.ToLower();
                        analyzer.SortTemperatures(sortChoice == "yes");
                        break;
                    case 7:
                        Console.WriteLine("Enter threshold temperature:");
                        int threshold;
                        if (int.TryParse(Console.ReadLine(), out threshold))
                        {
                            analyzer.FilterTemperaturesAboveThreshold(threshold);
                        }
                        else
                        {
                            Console.WriteLine("Invalid threshold.");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter the day (1-31):");
                        int day;
                        if (int.TryParse(Console.ReadLine(), out day))
                        {
                            analyzer.GetSurroundingTemperatures(day);
                        }
                        else
                        {
                            Console.WriteLine("Invalid day.");
                        }
                        break;
                    case 9:
                        Console.WriteLine($"Most Common Temperature: {analyzer.FindMostCommonTemperature()}°C");
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}