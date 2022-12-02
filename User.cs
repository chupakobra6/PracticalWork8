using Newtonsoft.Json;

namespace ConsoleApp11
{
    public class User
    {
        public string name;
        public int charsPerMinute; public float charsPerSecond;

        public User(string nameArg, int charsPerMinuteArg)
        {
            name = nameArg;
            charsPerMinute = charsPerMinuteArg;
            charsPerSecond = (float)charsPerMinuteArg / 60;
        }

        public static List<User> Serializing(string name, int index)
        {
            string json = File.ReadAllText("C:\\C#\\ConsoleApp11\\record.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User user = new User(name, index);
            users.Add(user);

            json = JsonConvert.SerializeObject(users);
            File.WriteAllText("C:\\C#\\ConsoleApp11\\record.json", json);

            return users;
        }
    }
}
