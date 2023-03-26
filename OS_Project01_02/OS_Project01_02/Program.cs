using System;

namespace OS_Project01_02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] servers = { 5, 1, 4, 3, 2 };
            int[] tasks = { 2, 1, 2, 4, 5, 2, 1 };

            int[] output = new int[tasks.Length];

            Solution solution = new Solution();
            //Console.WriteLine(solution.AssignTasks(servers, tasks));
            
            output = solution.AssignTasks(servers, tasks);

            for(int i = 0; i < tasks.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
            
        }
    }

    public class Solution
    {
        public int[] AssignTasks(int[] servers, int[] tasks)
        {
            int[] output = new int[tasks.Length];
            int[] share = new int[servers.Length];
            for(int i = 0; i < servers.Length; i++)
            {
                share[i] = 0;
            }

            int index = 0;

            int min = 0;
            int min_index = 0;

            while (true)
            {
                for(int i = 0; i < share.Length; i++)
                {
                    if(share[i] == 0)
                    {
                        min = servers[i];
                        min_index = i;
                        break;
                    }
                }

                for(int i = 0; i < share.Length; i++)
                {
                    if (share[i] != 0) continue;
                    if (servers[i] < min)
                    {
                        min = servers[i];
                        min_index = i;
                    }
                }

                share[min_index] = tasks[index];
                output[index] = min_index;

                index++;
                if (index >= tasks.Length) break;

                for(int i = 0; i < share.Length; i++)
                {
                    if (share[i] == 0) continue;
                    share[i]--;
                }
            }

            return output;
        }
    }
}
