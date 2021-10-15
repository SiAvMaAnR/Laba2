using System;

namespace SecondLaba
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            Console.WriteLine(levenshtein(text, pattern));
            Console.ReadKey(true);
        }


        static int levenshtein(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return (!string.IsNullOrEmpty(b)) ? b.Length : 0;
            }
            if (string.IsNullOrEmpty(b))
            {
                return (!string.IsNullOrEmpty(a)) ? a.Length : 0;
            }

            int[,] d = new int[a.Length + 1, b.Length + 1];
            int cost, min1, min2, min3;

            int N = d.GetUpperBound(0);
            int M = d.GetUpperBound(1);

            for (int i = 0; i <= N; i++)
            {
                d[i, 0] = i;
            }
            for (int i = 0; i <= M; i++)
            {
                d[0, i] = i;
            }
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[N, M];
        }
    }
}
