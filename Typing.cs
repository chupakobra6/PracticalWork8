using System.Diagnostics;

namespace ConsoleApp11
{
    internal class Typing
    {
        static string[] texts = new string[10];
        public static int TypingTest(string textsFile)
        {
            textsFile = "C:\\C#\\ConsoleApp11\\texts.txt";

            if (File.Exists(textsFile))
            {
                texts = File.ReadAllLines(textsFile);
            }

            else
            {
                Console.WriteLine("Ошибка чтения файла с текстами! Введите путь вручную: ");
                textsFile = Console.ReadLine();
                Typing.TypingTest(textsFile);
            }

            Random text = new Random();
            int choice = text.Next(0, texts.Length);

            Console.WriteLine(texts[choice]);
            Console.WriteLine(new string('=', 31));
            Console.WriteLine("Нажмите Enter для запуска теста");
            Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo key = Console.ReadKey();

            int index = 0;

            if (key.Key == ConsoleKey.Enter)
            {
                Thread timer = new((_) =>
                {
                    Stopwatch stopwatch = new();
                    Stopwatch timer = stopwatch;
                    timer.Start();
                    TimeSpan ts;

                    do
                    {
                        ts = timer.Elapsed;
                        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                        Console.SetCursorPosition(0, texts[choice].Length / Console.WindowWidth + 4);
                        Console.WriteLine("Время: " + elapsedTime);
                        Thread.Sleep(1000);

                    } while (ts.Seconds <= 59);

                    Console.SetCursorPosition(0, texts[choice].Length / Console.WindowWidth + 5);
                    Console.WriteLine("Стоп!");
                });

                timer.Start();

                do
                {
                    ConsoleKeyInfo letter = Console.ReadKey(true);

                    if (letter.KeyChar == texts[choice][index])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(index, index / Console.WindowWidth);
                        Console.Write(letter.KeyChar);
                        Console.ForegroundColor = ConsoleColor.White;

                        index++;
                    }

                } while (timer.IsAlive);

                Thread.Sleep(1000);
                Console.SetCursorPosition(0, texts[choice].Length / Console.WindowWidth + 5);
                Console.WriteLine("Для продолжения нажмите любую кнопку");
                
                Console.ReadKey();

                Console.Clear();
            }

            return index;
        }
    }
}
