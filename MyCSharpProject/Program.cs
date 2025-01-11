using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Helpers;
using MyProject.Helpers;

class Program
{
    static void Main(string[] args)
    {
        // // Task 1: Create variables
        // Console.WriteLine("任务1：创建变量\n");
        // int low = GetValidatedInput("请输入低数值（正整数）： ", positiveOnly: true);
        // int high = GetValidatedInput($"请输入高数值（必须大于{low}）： ", positiveOnly: false, minimumValue: low);
        // Console.WriteLine($"低数值: {low}, 高数值: {high}, 差值: {high - low}\n");

        // // Task 2: Loops and input validation (Placeholder)
        // Console.WriteLine("任务2：循环与输入验证待实现。\n");

        // // Task 3: Use arrays and file I/O
        // Console.WriteLine("任务3：使用数组和文件I/O\n");
        // List<int> numbers = GenerateNumberList(low, high);

        // // 显示数字列表
        // Console.WriteLine("范围内的数字：");
        // foreach (var number in numbers)
        // {
        //     Console.Write(number + " ");
        // }
        // Console.WriteLine("\n");

        // // string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        // // string filePath = Path.Combine(documentsPath, "numbers.txt");
        // // 获取项目根目录
        // string projectRoot = GetProjectRootDirectory(3); // 假设需要向上3层
        // if (projectRoot == null)
        // {
        //     Console.WriteLine("无法找到项目根目录。");
        //     return;
        // }
        
        // // 设置文件路径到项目根目录
        // string filePath = Path.Combine(projectRoot, "numbers.txt");

        // // string filePath = Path.Combine(Environment.CurrentDirectory, "numbers.txt");
        // try
        // {
        //     WriteNumbersToFile(numbers, filePath);
        //     Console.WriteLine($"数字已以逆序写入文件: {filePath}\n");
        // }
        // catch (IOException ex)
        // {
        //     Console.WriteLine($"写入文件时发生错误: {ex.Message}");
        //     return;
        // }

        // try
        // {
        //     int sum = CalculateSumFromFile(filePath);
        //     Console.WriteLine($"文件中数字的总和为: {sum}\n");
        // }
        // catch (IOException ex)
        // {
        //     Console.WriteLine($"读取文件时发生错误: {ex.Message}");
        //     return;
        // }

        // Console.WriteLine("范围内的素数：");
        // PrintPrimesInRange(low, high);

        // // 等待用户按回车键后退出
        // Console.WriteLine("\n按回车键退出。");
        // Console.ReadLine();
      // 显示当前工作目录
            Console.WriteLine($"当前工作目录: {Environment.CurrentDirectory}\n");

            // 任务1：获取并验证用户输入
            Console.WriteLine("任务1：获取并验证用户输入\n");
            double low = InputHelper.GetValidatedInput("请输入低数值（正数）： ", positiveOnly: true);
            double high = InputHelper.GetValidatedInput($"请输入高数值（必须大于{low}）： ", positiveOnly: false, minimumValue: low);
            Console.WriteLine($"低数值: {low}, 高数值: {high}, 差值: {high - low}\n");

            // 任务2：循环与输入验证（占位符）
            Console.WriteLine("任务2：循环与输入验证待实现。\n");

            // 任务3：使用列表和文件I/O
            Console.WriteLine("任务3：使用列表和文件I/O\n");
            List<double> numbers = GenerateNumberList(low, high);

            // 显示数字列表
            Console.WriteLine("范围内的数字：");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");

            // 设置文件路径到项目根目录
            string projectRoot = FileHelper.GetProjectRootDirectory(3); // 根据项目结构调整层数
            if (projectRoot == null)
            {
                Console.WriteLine("无法找到项目根目录。");
                return;
            }
            string filePath = System.IO.Path.Combine(projectRoot, "numbers.txt");
            Console.WriteLine($"文件将被保存到: {filePath}\n");

            // 写入文件
            try
            {
                FileHelper.WriteNumbersToFile(numbers, filePath);
                Console.WriteLine($"数字已以逆序写入文件: {filePath}\n");
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"写入文件时发生错误: {ex.Message}");
                return;
            }

            // 读取文件并计算总和
            try
            {
                double sum = FileHelper.CalculateSumFromFile(filePath);
                Console.WriteLine($"文件中数字的总和为: {sum}\n");
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"读取文件时发生错误: {ex.Message}");
                return;
            }

            // 打印范围内的质数
            Console.WriteLine("范围内的质数：");
            PrimeHelper.PrintPrimesInRange(low, high);

            // 等待用户按回车键后退出
            Console.WriteLine("\n按回车键退出。");
            Console.ReadLine();
    }

        /// <summary>
        /// 生成从low到high的双精度浮点数列表。
        /// </summary>
        /// <param name="low">起始数值。</param>
        /// <param name="high">结束数值。</param>
        /// <returns>双精度浮点数列表。</returns>
        static List<double> GenerateNumberList(double low, double high)
        {
            List<double> numbers = new List<double>();
            for (double i = low; i <= high; i++)
            {
                numbers.Add(i);
            }
            return numbers;
        }

    /// <summary>
    /// 向上遍历指定层数以获取项目根目录。
    /// </summary>
    /// <param name="levels">需要向上遍历的层数。</param>
    /// <returns>项目根目录的路径，如果未找到则返回null。</returns>
    static string GetProjectRootDirectory(int levels)
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        for (int i = 0; i < levels; i++)
        {
            if (path == null) return null;
            path = Directory.GetParent(path)?.FullName;
        }
        return path;
    }
    // Method: Get and validate user input with specific error messages
    static int GetValidatedInput(string prompt, bool positiveOnly = false, int minimumValue = int.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("输入的不是有效的整数。请重试。");
                continue;
            }
            if (positiveOnly && result <= 0)
            {
                Console.WriteLine("数值必须为正整数。请重试。");
                continue;
            }
            if (result <= minimumValue)
            {
                Console.WriteLine($"数值必须大于{minimumValue}。请重试。");
                continue;
            }
            return result;
        }
    }

    // Method: Generate a list of integers from low to high
    static List<int> GenerateNumberList(int low, int high)
    {
        return Enumerable.Range(low, high - low + 1).ToList();
    }

    // Method: Write numbers to file in reverse order
    static void WriteNumbersToFile(List<int> numbers, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var number in numbers.AsEnumerable().Reverse())
            {
                writer.WriteLine(number);
            }
        }
    }

    // Method: Read numbers from file and calculate the sum
    static int CalculateSumFromFile(string filePath)
    {
        return File.ReadLines(filePath)
                   .Select(line => int.TryParse(line, out int num) ? num : 0)
                   .Sum();
    }

    // Method: Print primes in the range
    static void PrintPrimesInRange(int low, int high)
    {
        bool found = false;
        for (int i = low; i <= high; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("在指定范围内未找到素数。");
        }
    }

    // Method: Check if a number is prime with optimizations
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
