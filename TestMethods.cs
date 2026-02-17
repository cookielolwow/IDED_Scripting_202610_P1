namespace IDED_Scripting_202610_P1
{
using System;
using System.Collections.Generic;


    
        internal class TestMethods
        {

       


        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

   
            Stack<int> tempInc = new Stack<int>();
            Stack<int> tempExc = new Stack<int>();

            while (input.Count > 0)
            {
                int value = input.Dequeue();
                if (IsInSeries(value))
                    tempInc.Push(value);
                else
                    tempExc.Push(value);
            }


            while (tempInc.Count > 0) included.Push(tempInc.Pop());
            while (tempExc.Count > 0) excluded.Push(tempExc.Pop());
        }

     
        private static bool IsInSeries(int x)
        {
            if (x == 0) return false;

            int abs = Math.Abs(x);
            int root = (int)Math.Sqrt(abs);

         
            if (root * root != abs) return false;

         
            return (root % 2 == 1) ? (x < 0) : (x > 0);
        }




        public static List<int> GenerateSortedSeries(int n) 
        { 
            List<int> series = new List<int>();

         
            for (int i = 1; i <= n; i++)
            {
                int term = i * i;

             
                if (i % 2 == 1)
                    term = -term;

                series.Add(term);
            }


            for (int i = 0; i<series.Count - 1; i++)
            {
                for (int j = 0; j<series.Count - 1 - i; j++)
                {
                    if (series[j] > series[j + 1])
                    {
                        int temp = series[j];
                     series[j] = series[j + 1];
                        series[j + 1] = temp;
                    }
                }
            }

            return series;
        }
        public static bool FindNumberInSortedList(int target, in List<int> list) => false;

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> temp = new Stack<int>();
            int result = 0;

            while (list.Count > 0)
            {
                int value = list.Pop();
                temp.Push(value);

                if (IsPrime(value))
                {
                    result = value;
                    break;
                }
            }

           
            while (temp.Count > 0)
                list.Push(temp.Pop());

            return result;
        }


        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            bool removed = false;

            while (stack.Count > 0)
            {
                int value = stack.Pop();

                if (!removed && IsPrime(value))
                {
                    removed = true; 
                    continue;
                }

                temp.Push(value);
            }

           
            while (temp.Count > 0)
                stack.Push(temp.Pop());

            return stack;
        }


        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Queue<int> queue = new Queue<int>();
            Stack<int> temp = new Stack<int>();

            
            while (stack.Count > 0)
                temp.Push(stack.Pop());

         
            while (temp.Count > 0)
            {
                int value = temp.Pop();
                queue.Enqueue(value);
                stack.Push(value); 
            }

            return queue;
        }

    }
}
