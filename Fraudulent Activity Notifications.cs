using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     */

    public static int activityNotifications(List<int> expenditure, int d)
    {
        int notifications = 0;
        int[] freq = new int[201]; // Since expenditure values are between 0-200
        
        // Initialize frequency array with first d elements
        for (int i = 0; i < d; i++)
        {
            freq[expenditure[i]]++;
        }
        
        for (int i = d; i < expenditure.Count; i++)
        {
            // Get median for current trailing d days
            double median = GetMedian(freq, d);
            
            // Check if current expenditure triggers notification
            if (expenditure[i] >= 2 * median)
            {
                notifications++;
            }
            
            // Update frequency array: remove oldest, add current
            freq[expenditure[i - d]]--;
            freq[expenditure[i]]++;
        }
        
        return notifications;
    }
    
    private static double GetMedian(int[] freq, int d)
    {
        int count = 0;
        int medianPos1 = (d + 1) / 2;
        int medianPos2 = d / 2 + 1;
        int val1 = -1, val2 = -1;
        
        // Find the median value(s)
        for (int i = 0; i < freq.Length; i++)
        {
            count += freq[i];
            
            if (val1 == -1 && count >= medianPos1)
            {
                val1 = i;
            }
            if (count >= medianPos2)
            {
                val2 = i;
                break;
            }
        }
        
        // If d is odd, median is the middle value
        // If d is even, median is average of two middle values
        return d % 2 == 1 ? val1 : (val1 + val2) / 2.0;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
