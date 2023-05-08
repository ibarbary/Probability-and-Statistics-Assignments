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
        Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
        Dictionary<int, int> freq = new Dictionary<int, int>();

        for (int i = 0; i < a.Length; i++)
        {
            if (freq.ContainsKey(a[i]) == false)
                freq[a[i]] = 1;
            else
                freq[a[i]] = freq[a[i]] + 1;
        }

        
        foreach(var n in freq)
        {
            if (d.ContainsKey(n.Value) == false)
                d[n.Value] = new List<int>() {n.Key};
            else
                d[n.Value].Add(n.Key);
        }

        if(d.Count == 1)
        {
            Console.WriteLine("All items have same Frequency so mode is 0");
            return;
        }

        int mostFrequency = 0;
        foreach(var n in d)
        {
            if (n.Key > mostFrequency)
                mostFrequency = n.Key;
        }

        Console.Write("Mode = { ");
        foreach (var n in d[mostFrequency])
        {
            Console.Write(n + " ");
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

    static double P90(int[] A)
    {
        int indx = (int)Math.Ceiling(A.Length * 0.90);

        if(A.Length * 0.90 == indx)
        {
            return (double)(A[indx - 1] + A[indx]) / 2;
        }

        return (double)(A[indx - 1]);
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

        double IQR = interQuartile(Quartile(A, 1), Quartile(A, 3));

        Console.WriteLine();
        Console.WriteLine($"Median = {median(A)}");
        mode(A);
        Console.WriteLine($"Range = {range(A)}");
        if(A.Length > 3)
        {
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
        
        Console.WriteLine($"90th Percentile = {P90(A)}");
    }
}
