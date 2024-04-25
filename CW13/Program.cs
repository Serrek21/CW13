using System;
class Program
{
    static void Main()
    {
        //task1

        Console.Write("Введіть шлях до файлу: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Вміст файлу:");
            Console.WriteLine(fileContent);
        }
        else
        {
            Console.WriteLine("Помилка: Файл не існує.");
        }

        //task2 / task3


        int[] array;

        Console.WriteLine("1. Завантажити масив з файлу");
        Console.WriteLine("2. Ввести масив з клавіатури");
        Console.Write("Виберіть дію: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Введіть шлях до файлу: ");
            string filePath1 = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filePath1);
                array = new int[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    array[i] = int.Parse(lines[i]);
                }

                Console.WriteLine("Масив завантажено з файлу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return;
            }
        }
        else if (choice == 2)
        {
            Console.Write("Введіть розмір масиву: ");
            int size = int.Parse(Console.ReadLine());
            array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір.");
            return;
        }

        Console.Write("Введіть шлях до файлу для збереження: ");
        string savePath = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(savePath))
            {
                foreach (int element in array)
                {
                    writer.WriteLine(element);
                }
            }

            Console.WriteLine("Вміст масиву збережено у файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        //task4

        Random random = new Random();
        int[] numbers = new int[10000];

        // Генеруємо 10000 випадкових цілих чисел
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next();
        }

        int[] evenNumbers = Array.FindAll(numbers, x => x % 2 == 0);
        int[] oddNumbers = Array.FindAll(numbers, x => x % 2 != 0);

        // Зберігаю парні числа у файл
        SaveToFile("even_numbers.txt", evenNumbers);

        // Зберігаю непарні числа у файл
        SaveToFile("odd_numbers.txt", oddNumbers);

        // Відображаємо статистику
        Console.WriteLine($"Кількість парних чисел: {evenNumbers.Length}");
        Console.WriteLine($"Кількість непарних чисел: {oddNumbers.Length}");
    }

    static void SaveToFile(string filePath, int[] numbers)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }

            Console.WriteLine($"Збережено {numbers.Length} чисел у файл {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка збереження у файл {filePath}: {ex.Message}");
        }
    }
}