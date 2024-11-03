﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utility
{
    public class Algorithms
    {


        public static int LevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return string.IsNullOrEmpty(b) ? 0 : b.Length;
            }

            if (string.IsNullOrEmpty(b))
            {
                return a.Length;
            }

            var costs = new int[b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
            {
                int lastValue = i;
                for (int j = 0; j <= b.Length; j++)
                {
                    if (i == 0)
                    {
                        costs[j] = j;
                    }
                    else if (j > 0)
                    {
                        int newValue = costs[j - 1];
                        if (a[i - 1] != b[j - 1])
                        {
                            newValue = Math.Min(Math.Min(newValue, lastValue), costs[j]) + 1;
                        }
                        costs[j - 1] = lastValue;
                        lastValue = newValue;
                    }
                }

                if (i > 0)
                {
                    costs[b.Length] = lastValue;
                }
            }

            return costs[b.Length];
        }



        public static double CalculateSimilarityPercentage(string source, string target)
        {
            int distance = LevenshteinDistance(source, target);
            int maxLength = Math.Max(source.Length, target.Length);

            return (1.0 - (double)distance / maxLength) * 100;
        }













    }
}
