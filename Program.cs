using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static bool CompareTwoList(List<int> a, List<int> b) // to check two integer lists are same or not
        {
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] != b[i]) return false;
                }
                return true;
            }
            return false;
        }

        private static List<List<int>> Merge(List<List<int>> a, List<List<int>> b) 
       // to join a list of integer lists b into a. If a element from b can be found in a, it will be discarded  
        {
            List<List<int>> result = new List<List<int>>();
            a.ForEach(m => result.Add(m));

            foreach (var itemb in b)
            {
                bool repeated = false;
                foreach (var itema in a)
                {
                    if (CompareTwoList(itemb, itema) == true)
                        repeated = true;
                }
                if (!repeated) result.Add(itemb);
            }
            return result;
        }

        private static List<List<int>> Shrink(List<int> a, int n) 
            // to remove the last element (a[tail]) in list a, and add it to a previous element (a[k]), i.e., a[k] += a[tail] while satisfying:
            // 1. a[tail]+a[k] <= n
            // 2. after adding, a[k] <= a[k-1]
        {
            List<List<int>> result = new List<List<int>>();
            int length = a.Count;//get size of a
            for (int i = 0; i <= length - 2; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j <= length - 2; j++)
                {
                    temp.Add(a[j]);
                }
                temp[i] += a[length - 1]; 
                if (temp[i] > n) continue;
                if (i - 1 >= 0)
                    if (temp[i] > temp[i - 1]) continue;
                result.Add(temp);
            }
            return result;
        }

        public static int partition(int m, int n)
        {
            List<List<List<int>>> S = new List<List<List<int>>>();// store all solutions, S[i] is solutions with number of elements = m-i
            //initializing//////////////////////////////////////////////////////////////////////////////
            List<int> a = new List<int>(); 
            List<List<int>> b = new List<List<int>>(); 
            int total = 0;
            for (int i = 0; i < m; i++)
                a.Add(1);
            b.Add(a);
            S.Add(b);
            total++;
            ////////////////////////////////////////////////////////////////////////////////////////////

            for (int i = 1; i < m; i++)
            {
                List<List<int>> Current_level = new List<List<int>>(); // to store solutions with item number = n-i
                for (int j = 0; j < S[i - 1].Count; j++)
                {
                    List<List<int>> temp = new List<List<int>>(); // to store solutions generated from one of solution from previous level( with one more number of item )
                    temp = Shrink(S[i - 1][j], n);
                    if (temp.Count > 0)
                        Current_level = Merge(Current_level, temp);
                }
                if (Current_level.Count > 0)
                {
                    S.Add(Current_level);
                    total += Current_level.Count;
                }
                if (Current_level.Count == 0) break;
            }

            /////////print results to console///////////////////////////////////
            foreach (var bi in S){
                foreach (var ai in bi) {
                    foreach (var num in ai) {
                        Console.Write("{0}  ",num);
                    }
                    Console.WriteLine("        <---------------{0} items",ai.Count);
                    
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); 
            }
            ////////////////////////////////////////////////////////////////////
            return total;
        }

        static void Main(string[] args)
        {
            int result = 0;
            int m = 6;
            int n = 6;
            Console.WriteLine("Partition ({0}, {1})", m, n);
            Console.WriteLine("===================================================");
            result = partition(m, n);
            Console.WriteLine("Total number of solutions = {0}", result);
            Console.ReadKey();
        }
    }
}
