using System.Reflection;
using MyCSharpProject.Helpers;

class Program
{
    static void Main(string[] args)
    {
        //TODO The current code belongs to Task 1-3 and can be used without comments.
        // Task1to3();
        //TODO The current code belongs to Additional task!!.
        AdditionalTask();
    }
    static void Task1to3()
    {
        // Task 1: Create variables
        Console.WriteLine("Task 1: Create variables\n");
        int low = GetValidatedInput("Please enter a lower value (positive integer)： ", positiveOnly: true);
        int high = GetValidatedInput($"Please enter a high value (must be greater than{low}）： ", positiveOnly: false, minimumValue: low);
        Console.WriteLine($"Low value: {low}, High value: {high}, diff value: {high - low}\n");

        // Task 2: Loops and input validation (Placeholder)
        Console.WriteLine("Task 2: Loop and input validation to be implemented。\n");

        // Task 3: Use arrays and file I/O
        Console.WriteLine("Task 3: Using arrays and filesI/O\n");
        List<int> numbers = GenerateNumberList(low, high);

        // 显示数字列表
        Console.WriteLine("Numbers in range：");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("\n");

        // string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        // string filePath = Path.Combine(documentsPath, "numbers.txt");
        // 获取项目根目录
        string projectRoot = GetProjectRootDirectory(3); // 假设需要向上3层
        if (projectRoot == null)
        {
            Console.WriteLine("Unable to find project root directory。");
            return;
        }

        // Set the file path to the project root directory
        string filePath = Path.Combine(projectRoot, "numbers.txt");

        // string filePath = Path.Combine(Environment.CurrentDirectory, "numbers.txt");
        try
        {
            WriteNumbersToFile(numbers, filePath);
            Console.WriteLine($"Numbers are written to the file in reverse order: {filePath}\n");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            return;
        }

        try
        {
            int sum = CalculateSumFromFile(filePath);
            Console.WriteLine($"The sum of the numbers in the file is: {sum}\n");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return;
        }

        Console.WriteLine("Prime numbers in the range：");
        PrintPrimesInRange(low, high);

        // 等待用户按回车键后退出
        Console.WriteLine("\nPress Enter to exit.");
        Console.ReadLine();
    }
    static void AdditionalTask()
    {
        // 任务1：获取并验证用户输入
        Console.WriteLine("Task 1: Obtain and validate user input\n");
        double low2 = InputHelper.GetValidatedInput("Please enter a lower value (positive number)： ", positiveOnly: true);
        double high2 = InputHelper.GetValidatedInput($"Please enter a high value (must be greater than {low2}）： ", positiveOnly: false, minimumValue: low2);
        Console.WriteLine($"Low value: {low2}, High value: {high2}, Difference:{high2 - low2}\n");

        // 任务2：循环与输入验证（占位符）
        Console.WriteLine("Task 2: Looping and input validation to be implemented.\n");

        // 任务3：使用列表和文件I/O
        Console.WriteLine("Task 3: Using Lists and File I/O\n");
        List<double> numbers2 = PrimeHelper.GenerateNumberList(low2, high2);

        // 显示数字列表
        Console.WriteLine("Numbers in range:");
        foreach (var number in numbers2)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("\n");

        // 设置文件路径到项目根目录
        string projectRoot2 = FileHelper.GetProjectRootDirectory(3); // 根据项目结构调整层数
        if (projectRoot2 == null)
        {
            Console.WriteLine("Unable to find project root directory.");
            return;
        }
        string filePath2 = System.IO.Path.Combine(projectRoot2, "additional_task_numbers.txt");
        Console.WriteLine($"The file will be saved to:{filePath2}\n");

        // 写入文件
        try
        {
            FileHelper.WriteNumbersToFile(numbers2, filePath2);
            Console.WriteLine($"The numbers are written to the file in reverse order: {filePath2}\n");
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine($"An error occurred while writing the file:{ex.Message}");
            return;
        }

        // 读取文件并计算总和
        try
        {
            double sum = FileHelper.CalculateSumFromFile(filePath2);
            Console.WriteLine($"The sum of the numbers in the file is:{sum}\n");
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file:{ex.Message}");
            return;
        }

        // 打印范围内的质数
        Console.WriteLine("Prime numbers in the range：");
        PrimeHelper.PrintPrimesInRange(low2, high2);

        // 等待用户按回车键后退出
        Console.WriteLine("\nPress Enter to exit.");
        Console.ReadLine();
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
                Console.WriteLine("The value entered is not a valid integer. Please try again.");
                continue;
            }
            if (positiveOnly && result <= 0)
            {
                Console.WriteLine("The value must be a positive integer. Please try again.");
                continue;
            }
            if (result <= minimumValue)
            {
                Console.WriteLine($"The value must be greater than{minimumValue}。Please try again.");
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
            Console.WriteLine("No prime numbers were found in the specified range.");
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
