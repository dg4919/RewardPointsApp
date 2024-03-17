using System.Collections.Generic;

namespace RewardPointsApp
{
    public class CustomerTransactions
    {
        public Dictionary<int, List<double>> transactions { get; set; }

        public CustomerTransactions()
        {
            // Sample data representing transactions(customer ID, transaction amount) for three months
            transactions = new Dictionary<int, List<double>>()
            {
                { 1, new List<double> { 120, 80, 50 } },
                { 2, new List<double> { 60, 150, 90 } }
            };
        }
        public Dictionary<int, Dictionary<string, int>> CalculateRewardPoints()
        {
            var rewards = new Dictionary<int, Dictionary<string, int>>();

            foreach (var customer in transactions)
            {
                int customerId = customer.Key;
                List<double> monthlyTransactions = customer.Value;

                Dictionary<string, int> monthlyRewards = new Dictionary<string, int>();

                for (int i = 0; i < monthlyTransactions.Count; i++)
                {
                    double totalPoints = 0;

                    // Calculate reward points for each transaction
                    totalPoints += CalculatePoints(monthlyTransactions[i]);

                    // Store reward points for each month
                    monthlyRewards.Add($"Month {i + 1}", (int)totalPoints);
                }

                // Store reward points for each customer
                rewards.Add(customerId, monthlyRewards);
            }

            return rewards;
        }

        private double CalculatePoints(double transactionAmount)
        {
            double points = 0;

            if (transactionAmount > 100)
            {
                points += (transactionAmount - 100) * 2; // 2 points for every dollar over $100
                points += 50; // 1 point for every dollar over $50
            }
            else
            {
                points += (transactionAmount - 50); // 1 point for every dollar over $50
            }

            return points;
        }

        public int GetTotalRewardPoints(Dictionary<string, int> monthlyRewards)
        {
            int totalPoints = 0;
            foreach (var reward in monthlyRewards)
            {
                totalPoints += reward.Value;
            }
            return totalPoints;
        }

    }
}
