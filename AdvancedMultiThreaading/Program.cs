using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AdvancedMultiThreaading
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPLinqList(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            PrintPLinqListOrdered(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            //Task task = Task.Run(() => WriteToFile("empire"));
            ToExecute();
        }
        public static async void ToExecute()
        {
            await WriteToFile("empire");
        }

        public static void PrintPLinqList(IEnumerable<int> numbers)
        {
            numbers = numbers.AsParallel()
                .Where(num => num % 3 == 1);
            Console.WriteLine("Not ordered: " + string.Join(", ", numbers));
        }

        public static void PrintPLinqListOrdered(IEnumerable<int> numbers)
        {
            numbers = numbers.AsParallel().AsOrdered()
                .Where(num => num % 3 == 1);
            Console.WriteLine("Ordered: " + string.Join(", ", numbers));
        }

        public static Task WriteToFile(string message)
        {
            Task x = Task.Run(
                async delegate
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\thelittlecitizen13\Desktop\empire.txt"))
                {
                    file.WriteLine(message);

                }
            });
            return x;
            
        }
    }
}
