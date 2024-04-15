using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool Blocked { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();


        Console.WriteLine("Введіть список користувачів з полями username, email, role, blocked, розділені комами (наприклад: user1,email1,role1,true): ");
        string input = Console.ReadLine();
        string[] userStrings = input.Split(',');
        for (int i = 0; i < userStrings.Length; i += 4)
        {
            User user = new User
            {
                Username = userStrings[i],
                Email = userStrings[i + 1],
                Role = userStrings[i + 2],
                Blocked = bool.Parse(userStrings[i + 3])
            };
            users.Add(user);
        }

       
        var activeUsers = users.Where(u => !u.Blocked);

       
        var groupedUsers = activeUsers.GroupBy(u => u.Role);

        
        foreach (var group in groupedUsers.OrderBy(g => g.Key))
        {
            Console.WriteLine($"Роль: {group.Key}");
            foreach (var user in group.OrderBy(u => u.Username))
            {
                Console.WriteLine($"Username: {user.Username}, Email: {user.Email}, Blocked: {user.Blocked}");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
