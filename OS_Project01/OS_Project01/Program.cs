using System;

namespace OS_Project01
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //char[] tasks = { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;

            Solution solution = new Solution();
            Console.WriteLine(solution.LeastInterval(tasks, n));
        }
    }

    public class Solution
    {
        public int LeastInterval(char[] tasks, int n)
        {
            char[] queue = new char[n + 1];
            int index = 0;
            int total = 0;
            bool stat = true;
            int nine_count = 0;

            if (n == 0)
            {
                return tasks.Length;
            }

            tasks = F_Sort(tasks);

            queue[index] = tasks[0];
            index++;
            total++;
            tasks[0] = '9';
            nine_count++;

            while (true)
            {
                for (int j = 1; j < tasks.Length; j++)
                {
                    if (tasks[j] == '9') continue;

                    for (int k = 1; k <= n; k++)
                    {
                        if (index < k) break;
                        if (tasks[j] == queue[index - k])
                        {
                            stat = false;
                            break;
                        }
                        stat = true;
                    }

                    if (stat)
                    {
                        queue[index] = tasks[j];
                        tasks[j] = '9';
                        nine_count++;
                        break;
                    }
                }

                if(!stat)
                {
                    queue[index] = '0';
                }
                stat = false;

                total++;

                for (int i = 0; i < n + 1; i++)
                {
                    Console.Write(queue[i] + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < tasks.Length; i++)
                {
                    Console.Write(tasks[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();

                if (index < n) index++;
                else
                {
                    for(int i = 0; i < n; i++)
                    {
                        queue[i] = queue[i + 1];
                    }
                }
                
                if(nine_count >= tasks.Length)
                {
                    for(int i = 0; i < index + 1; i++)
                    {
                        Console.Write(queue[i] + " ");
                    }
                    Console.WriteLine();
                    return total;
                }

                Console.WriteLine(index);
            }
        }

        public char[] F_Sort(char[] tasks)
        {

            int[] count_Tasks = new int[26];
            char[] arr = new char[tasks.Length];
            int current_arr = 0;
            int max = 0;
            int index = 0;

            for (int i = 0; i < 26; i++)
            {
                count_Tasks[i] = 0;
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                count_Tasks[tasks[i] - 65]++;
            }

            while (true)
            {
                max = 0;
                index = 0;

                for (int i = 0; i < count_Tasks.Length; i++)
                {
                    if (count_Tasks[i] >= max)
                    {
                        max = count_Tasks[i];
                        index = i;
                    }
                }
                if (max == 0) break;

                for (int i = 0; i < max; i++)
                {
                    arr[current_arr] = Convert.ToChar(index + 65);
                    current_arr++;
                }

                count_Tasks[index] = 0;
            }

            return arr;
        }

    }
}
