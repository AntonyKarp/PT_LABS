using System;

namespace TaskBlocksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Выберите блок задач:");
                Console.WriteLine("1. Переменные и операторы");
                Console.WriteLine("2. Условные операторы if-else, switch");
                Console.WriteLine("3. Циклы while, do-while, for");
                Console.WriteLine("4. Массивы");
                Console.WriteLine("5. Функции");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Block1();
                            break;
                        case 2:
                            Block2();
                            break;
                        case 3:
                            Block3();
                            break;
                        case 4:
                            Block4();
                            break;
                        case 5:
                            Block5();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        // Блок 1: Переменные и операторы
        static void Block1()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 1: Переменные и операторы");
                Console.WriteLine("2. Индекс массы тела (ИМТ)");
                Console.WriteLine("4. Перевод времени");
                Console.WriteLine("6. Цена со скидкой");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int task))
                {
                    switch (task)
                    {
                        case 2:
                            Task1_2();
                            break;
                        case 4:
                            Task1_4();
                            break;
                        case 6:
                            Task1_6();
                            break;
                        case 0:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        static void Task1_2()
        {
            Console.Write("Введите рост в сантиметрах: ");
            if (double.TryParse(Console.ReadLine(), out double heightCm) && heightCm > 0)
            {
                Console.Write("Введите вес в килограммах: ");
                if (double.TryParse(Console.ReadLine(), out double weightKg) && weightKg > 0)
                {
                    double heightM = heightCm / 100.0;
                    double bmi = weightKg / (heightM * heightM);
                    Console.WriteLine($"ИМТ = {bmi:F1}");
                }
                else
                {
                    Console.WriteLine("Некорректный вес.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный рост.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task1_4()
        {
            Console.Write("Введите количество секунд: ");
            if (long.TryParse(Console.ReadLine(), out long totalSeconds) && totalSeconds >= 0)
            {
                long hours = totalSeconds / 3600;
                long minutes = (totalSeconds % 3600) / 60;
                long seconds = totalSeconds % 60;
                Console.WriteLine($"{totalSeconds} секунд = {hours} ч {minutes} мин {seconds} сек");
            }
            else
            {
                Console.WriteLine("Некорректное значение.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task1_6()
        {
            Console.Write("Введите первоначальную цену товара: ");
            if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
            {
                Console.Write("Введите размер скидки в процентах: ");
                if (double.TryParse(Console.ReadLine(), out double discount) && discount >= 0 && discount <= 100)
                {
                    double finalPrice = price * (100 - discount) / 100;
                    Console.WriteLine($"Итоговая цена: {finalPrice:F2}");
                }
                else
                {
                    Console.WriteLine("Скидка должна быть от 0 до 100%.");
                }
            }
            else
            {
                Console.WriteLine("Некорректная цена.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        // Блок 2: Условные операторы
        static void Block2()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 2: Условные операторы");
                Console.WriteLine("2. Тип треугольника");
                Console.WriteLine("4. Оценка по числу");
                Console.WriteLine("6. Конвертация валют");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int task))
                {
                    switch (task)
                    {
                        case 2:
                            Task2_2();
                            break;
                        case 4:
                            Task2_4();
                            break;
                        case 6:
                            Task2_6();
                            break;
                        case 0:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        static void Task2_2()
        {
            Console.Write("Введите длину первой стороны: ");
            if (double.TryParse(Console.ReadLine(), out double a) && a > 0)
            {
                Console.Write("Введите длину второй стороны: ");
                if (double.TryParse(Console.ReadLine(), out double b) && b > 0)
                {
                    Console.Write("Введите длину третьей стороны: ");
                    if (double.TryParse(Console.ReadLine(), out double c) && c > 0)
                    {
                        if (a + b > c && a + c > b && b + c > a)
                        {
                            if (a == b && b == c)
                                Console.WriteLine("Треугольник равносторонний.");
                            else if (a == b || b == c || a == c)
                                Console.WriteLine("Треугольник равнобедренный.");
                            else
                                Console.WriteLine("Треугольник разносторонний.");
                        }
                        else
                        {
                            Console.WriteLine("Такой треугольник не существует.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректная длина стороны.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректная длина стороны.");
                }
            }
            else
            {
                Console.WriteLine("Некорректная длина стороны.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task2_4()
        {
            Console.Write("Введите оценку (от 1 до 5): ");
            if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 1 && grade <= 5)
            {
                string description = grade switch
                {
                    1 => "Плохо",
                    2 => "Неудовлетворительно",
                    3 => "Удовлетворительно",
                    4 => "Хорошо",
                    5 => "Отлично",
                    _ => "Неизвестно"
                };
                Console.WriteLine($"Оценка: {description}");
            }
            else
            {
                Console.WriteLine("Оценка должна быть от 1 до 5.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task2_6()
        {
            Console.Write("Введите сумму в рублях: ");
            if (double.TryParse(Console.ReadLine(), out double rubles) && rubles >= 0)
            {
                Console.WriteLine("Выберите валюту:");
                Console.WriteLine("1. Доллар (курс: 90 руб)");
                Console.WriteLine("2. Евро (курс: 100 руб)");
                Console.WriteLine("3. Фунт (курс: 115 руб)");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int currency))
                {
                    double rate = currency switch
                    {
                        1 => 90,
                        2 => 100,
                        3 => 115,
                        _ => 0
                    };

                    if (rate > 0)
                    {
                        double result = rubles / rate;
                        string currencyName = currency switch
                        {
                            1 => "долларов",
                            2 => "евро",
                            3 => "фунтов"
                        };
                        Console.WriteLine($"{rubles} руб = {result:F2} {currencyName}");
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор валюты.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            else
            {
                Console.WriteLine("Некорректная сумма.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        // Блок 3: Циклы
        static void Block3()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 3: Циклы");
                Console.WriteLine("2. Переворот числа");
                Console.WriteLine("4. Максимальное нечётное число");
                Console.WriteLine("6. Арифметическая прогрессия");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int task))
                {
                    switch (task)
                    {
                        case 2:
                            Task3_2();
                            break;
                        case 4:
                            Task3_4();
                            break;
                        case 6:
                            Task3_6();
                            break;
                        case 0:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        static void Task3_2()
        {
            Console.Write("Введите целое число: ");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                bool isNegative = number < 0;
                number = Math.Abs(number);
                long reversed = 0;
                while (number > 0)
                {
                    reversed = reversed * 10 + number % 10;
                    number /= 10;
                }
                if (isNegative) reversed = -reversed;
                Console.WriteLine($"Перевёрнутое число: {reversed}");
            }
            else
            {
                Console.WriteLine("Некорректное число.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task3_4()
        {
            Console.Write("Введите начало диапазона [a]: ");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.Write("Введите конец диапазона [b]: ");
                if (int.TryParse(Console.ReadLine(), out int b))
                {
                    if (a > b) (a, b) = (b, a); // swap

                    int maxOdd = int.MinValue;
                    bool found = false;
                    for (int i = b; i >= a; i--)
                    {
                        if (i % 2 != 0)
                        {
                            maxOdd = i;
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        Console.WriteLine($"Максимальное нечётное число: {maxOdd}");
                    else
                        Console.WriteLine("В диапазоне нет нечётных чисел.");
                }
                else
                {
                    Console.WriteLine("Некорректный конец диапазона.");
                }
            }
            else
            {
                Console.WriteLine("Некорректное начало диапазона.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task3_6()
        {
            Console.Write("Введите количество членов (n): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Console.Write("Введите первый член прогрессии: ");
                if (double.TryParse(Console.ReadLine(), out double first))
                {
                    Console.Write("Введите шаг прогрессии: ");
                    if (double.TryParse(Console.ReadLine(), out double step))
                    {
                        double sum = 0;
                        Console.Write("Члены прогрессии: ");
                        for (int i = 0; i < n; i++)
                        {
                            double term = first + i * step;
                            sum += term;
                            Console.Write($"{term} ");
                        }
                        Console.WriteLine($"\nСумма: {sum}");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный шаг.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный первый член.");
                }
            }
            else
            {
                Console.WriteLine("Количество членов должно быть положительным.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        // Блок 4: Массивы
        static void Block4()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 4: Массивы");
                Console.WriteLine("2. Второй по величине элемент");
                Console.WriteLine("4. Чётные элементы в столбцах");
                Console.WriteLine("6. Диагонали матрицы");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int task))
                {
                    switch (task)
                    {
                        case 2:
                            Task4_2();
                            break;
                        case 4:
                            Task4_4();
                            break;
                        case 6:
                            Task4_6();
                            break;
                        case 0:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        static void Task4_2()
        {
            Console.Write("Введите размер массива: ");
            if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
            {
                Random rand = new Random();
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(1, 101);
                }

                Console.WriteLine("Массив: [" + string.Join(", ", arr) + "]");

                int max = int.MinValue, secondMax = int.MinValue;
                int secondMaxIndex = -1;

                for (int i = 0; i < size; i++)
                {
                    if (arr[i] > max)
                    {
                        secondMax = max;
                        max = arr[i];
                    }
                    else if (arr[i] > secondMax && arr[i] < max)
                    {
                        secondMax = arr[i];
                        secondMaxIndex = i;
                    }
                }

                if (secondMaxIndex == -1)
                    Console.WriteLine("Второго по величине элемента нет.");
                else
                    Console.WriteLine($"Второй по величине элемент: {secondMax}, индекс: {secondMaxIndex}");
            }
            else
            {
                Console.WriteLine("Размер массива должен быть положительным.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task4_4()
        {
            Console.Write("Введите количество строк: ");
            if (int.TryParse(Console.ReadLine(), out int rows) && rows > 0)
            {
                Console.Write("Введите количество столбцов: ");
                if (int.TryParse(Console.ReadLine(), out int cols) && cols > 0)
                {
                    Random rand = new Random();
                    int[,] matrix = new int[rows, cols];
                    for (int i = 0; i < rows; i++)
                        for (int j = 0; j < cols; j++)
                            matrix[i, j] = rand.Next(1, 101);

                    Console.WriteLine("Матрица:");
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                            Console.Write($"{matrix[i, j],4}");
                        Console.WriteLine();
                    }

                    int[] evenCounts = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            if (matrix[i, j] % 2 == 0)
                                evenCounts[j]++;
                        }
                    }

                    Console.WriteLine("Количество чётных в столбцах: [" + string.Join(", ", evenCounts) + "]");

                    int maxEvenCount = -1, maxColIndex = -1;
                    for (int j = 0; j < cols; j++)
                    {
                        if (evenCounts[j] > maxEvenCount)
                        {
                            maxEvenCount = evenCounts[j];
                            maxColIndex = j;
                        }
                    }

                    Console.WriteLine($"Столбец с максимальным количеством чётных чисел: {maxColIndex} (количество: {maxEvenCount})");
                }
                else
                {
                    Console.WriteLine("Количество столбцов должно быть положительным.");
                }
            }
            else
            {
                Console.WriteLine("Количество строк должно быть положительным.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Task4_6()
        {
            Console.Write("Введите размер квадратной матрицы (n x n): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Random rand = new Random();
                int[,] matrix = new int[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = rand.Next(1, 101);

                Console.WriteLine("Матрица:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        Console.Write($"{matrix[i, j],4}");
                    Console.WriteLine();
                }

                int maxMain = int.MinValue, maxSecondary = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > maxMain)
                        maxMain = matrix[i, i];
                    if (matrix[i, n - 1 - i] > maxSecondary)
                        maxSecondary = matrix[i, n - 1 - i];
                }

                Console.WriteLine($"Максимум на главной диагонали: {maxMain}");
                Console.WriteLine($"Максимум на побочной диагонали: {maxSecondary}");
                Console.WriteLine($"Сумма максимумов: {maxMain + maxSecondary}");
            }
            else
            {
                Console.WriteLine("Размер матрицы должен быть положительным.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        // Блок 5: Функции
        static void Block5()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Блок 5: Функции");
                Console.WriteLine("2. Генерация массива");
                Console.WriteLine("4. Сумма цифр числа (рекурсия)");
                Console.WriteLine("6. Разделение числа");
                Console.WriteLine("8. Длины строк");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int task))
                {
                    switch (task)
                    {
                        case 2:
                            Task5_2();
                            break;
                        case 4:
                            Task5_4();
                            break;
                        case 6:
                            Task5_6();
                            break;
                        case 8:
                            Task5_8();
                            break;
                        case 0:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        static int[] GenerateArray(int count, int min, int max)
        {
            Random rand = new Random();
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = rand.Next(min, max + 1);
            }
            return arr;
        }

        static void Task5_2()
        {
            Console.Write("Введите количество элементов: ");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                Console.Write("Введите минимальное значение: ");
                if (int.TryParse(Console.ReadLine(), out int min))
                {
                    Console.Write("Введите максимальное значение: ");
                    if (int.TryParse(Console.ReadLine(), out int max) && max >= min)
                    {
                        int[] arr = GenerateArray(count, min, max);
                        Console.WriteLine("Сгенерированный массив: [" + string.Join(", ", arr) + "]");
                    }
                    else
                    {
                        Console.WriteLine("Максимум должен быть >= минимума.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное минимальное значение.");
                }
            }
            else
            {
                Console.WriteLine("Количество должно быть положительным.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static int DigitSum(int number)
        {
            number = Math.Abs(number);
            if (number == 0) return 0;
            return (number % 10) + DigitSum(number / 10);
        }

        static void Task5_4()
        {
            Console.Write("Введите целое число: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                int sum = DigitSum(num);
                Console.WriteLine($"Сумма цифр числа {num} = {sum}");
            }
            else
            {
                Console.WriteLine("Некорректное число.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static void Split(double number, out int whole, out double fraction)
        {
            whole = (int)Math.Truncate(number);
            fraction = Math.Abs(number - whole);
        }

        static void Task5_6()
        {
            Console.Write("Введите число: ");
            if (double.TryParse(Console.ReadLine(), out double num))
            {
                Split(num, out int wholePart, out double fractionalPart);
                Console.WriteLine($"Целая часть: {wholePart}");
                Console.WriteLine($"Дробная часть: {fractionalPart:F10}");
            }
            else
            {
                Console.WriteLine("Некорректное число.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }

        static int[] GetLengths(params string[] strings)
        {
            int[] lengths = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                lengths[i] = strings[i].Length;
            }
            return lengths;
        }

        static void Task5_8()
        {
            string[] testStrings = { "My", "Name", "Is", "Jabbar", "I", "Live", "In", "Qatar" };
            int[] lengths = GetLengths(testStrings);
            Console.WriteLine("Строки: [" + string.Join(", ", testStrings) + "]");
            Console.WriteLine("Длины:  [" + string.Join(", ", lengths) + "]");
            Console.WriteLine("\nПопробуйте ввести свои строки (через запятую):");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] userStrings = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < userStrings.Length; i++)
                    userStrings[i] = userStrings[i].Trim();
                int[] userLengths = GetLengths(userStrings);
                Console.WriteLine("Ваши строки: [" + string.Join(", ", userStrings) + "]");
                Console.WriteLine("Длины:       [" + string.Join(", ", userLengths) + "]");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
    }
}