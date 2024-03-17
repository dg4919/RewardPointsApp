using RewardPointsApp;
using System;

namespace RewardPointsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerTransactions = new CustomerTransactions();

            // Calculate reward points for each customer per month and total
            var rewards = customerTransactions.CalculateRewardPoints();

            // Display reward points earned for each customer per month and total
            foreach (var customer in rewards)
            {
                Console.WriteLine($"Customer ID: {customer.Key}");
                foreach (var month in customer.Value)
                {
                    Console.WriteLine($"  Month: {month.Key}, Reward Points: {month.Value}");
                }
                Console.WriteLine($"  Total Reward Points: {customerTransactions.GetTotalRewardPoints(customer.Value)}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
