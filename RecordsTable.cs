namespace ConsoleApp11
{
    internal class RecordsTable
    {
        public static void Table()
        {
            Console.WriteLine("Введите имя для таблицы рекордов: ");
            string name = Console.ReadLine();
            Console.Clear();

            int index = Typing.TypingTest("");

            List<User> users = User.Serializing(name, index);

            Console.WriteLine("Таблица рекордов: ");
            Console.WriteLine(new string('=', 18));

            foreach (User item in users)
            {
                Console.WriteLine($"{item.name}\t{item.charsPerMinute} символов в минуту\t{item.charsPerSecond} символ в секунду");
            }

            Console.WriteLine("Чтобы пройти тест заново - нажмите Enter");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Table();
            }
        }
    }
}
