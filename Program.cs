using System;
using System.Collections.Generic;
internal class Program
{
    static double median(int[] a)
    {
        int mid = a.Length / 2;
        if (a.Length % 2 == 0)
        {
            return (double)(a[mid - 1] + a[mid]) / 2;
        }
        else
        {
            return a[mid];
        }

    }

    static void mode(int[] a)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        int mostFreq = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (freq.ContainsKey(a[i]) == false)
                freq[a[i]] = 1;
            else
                freq[a[i]] = freq[a[i]] + 1;

            if (freq[a[i]] > mostFreq)
                mostFreq = freq[a[i]];
        }

        if (freq.Count == 1)
        {
            Console.Write("Mode = ");
            foreach (var n in freq)
                Console.WriteLine(n.Key);

            return;
        }

        bool isAllSameFreq = true;
        foreach (var n in freq)
        {
            if (n.Value != mostFreq)
            {
                isAllSameFreq = false;
                break;
            }
        }

        if (isAllSameFreq == true)
        {
            Console.WriteLine("No Mode as all items have same frequency");
            return;
        }

        Console.Write("Mode = { ");
        foreach (var n in freq)
        {
            if(n.Value == mostFreq)
                Console.Write(n.Key + " ");
        }

        Console.WriteLine("}");
    }

    static int range(int[] a)
    {
        return a[a.Length - 1] - a[0];
    }

    static double Quartile(int[] a, int nth)
    {
        int start = 0;
        int end = a.Length - 1;
        int mid = a.Length / 2;

        if (nth == 1)
        {
            end = mid - 1;
        }
        else
        {
            if (a.Length % 2 == 0)
                start = mid;
            else
                start = mid + 1;
        }

        int nOfElements = end - start + 1;

        int i = start + ((end - start) / 2);
        double quart = a[i];

        if (nOfElements % 2 == 0)
        {
            quart = (quart + a[i + 1]) / 2;
        }

        return quart;
        /*double q = 0;
        int i = 0;
        if(nth == 1)
        {
            i = (int)(0.25 * a.Length);
            
        }
        else
        {
            i = (int)Math.Ceiling(0.75 * a.Length);
        }

        if ((a.Length / 2) % 2 == 0)
        {
            q = (double)(a[i - 1] + a[i]) / 2;
        }
        else
        {
            q = a[i];

            if (nth == 3)
            --q;
        }
        
        return q;*/
    }

    static double interQuartile(double Q1, double Q3)
    {
        return Q3 - Q1;
    }

    static double lowBoundary(double Q1, double IQR)
    {
        return Q1 - (1.5 * IQR);
    }

    static double highBoundary(double Q3, double IQR)
    {
        return Q3 + (1.5 * IQR);
    }

    static void isOutlier(int[] A, double IQR)
    {
        double Q1 = Quartile(A, 1);
        double Q3 = Quartile(A, 3);

        Console.Write("The Outliers are: ");
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] < lowBoundary(Q1, IQR) || A[i] > highBoundary(Q3, IQR))
                Console.Write(A[i] + " ");
        }

        Console.WriteLine();
    }

    static int Percentile(int[] A, int k)
    {
        int position = (int)Math.Floor((double)A.Length * k / 100);
        
        return A[position - 1];
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter number of items: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] A = new int[n];
        Console.WriteLine("Enter values of items: ");
        for (int i = 0; i < n; ++i)
        {
            A[i] = Convert.ToInt32(Console.ReadLine());
        }

        Array.Sort(A);

        Console.WriteLine();
        Console.WriteLine($"Median = {median(A)}");
        mode(A);
        Console.WriteLine($"Range = {range(A)}");
        if(A.Length > 3)
        {
            double IQR = interQuartile(Quartile(A, 1), Quartile(A, 3));
            Console.WriteLine($"1st Quartile = {Quartile(A, 1)}");
            Console.WriteLine($"3rd Quartile = {Quartile(A, 3)}");
            Console.WriteLine($"InterQuartile = {IQR}");
            Console.WriteLine($"Outlier's Low Boundary = {lowBoundary(Quartile(A, 1), IQR)}");
            Console.WriteLine($"Outlier's High Boundary = {highBoundary(Quartile(A, 3), IQR)}");
            isOutlier(A, IQR);
        }
        else
        {
            Console.WriteLine("Size of array is < 3 so we can't get Quartiles, IQR or Outliers");
        }
        
        Console.WriteLine($"Percentile = {Percentile(A, 90)}");
    }
}
