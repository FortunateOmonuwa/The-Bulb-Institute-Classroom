using Class7;
using Class7.Utilities;

class Program
{
    static void Main(string[] args)
    {
        User[] users = new User[10];

        var input = 0;
        int currentIndex = 0;
        while (input != 2 && currentIndex < users.Length)
        {
            input = Startup.StartupMethod(); 

            switch (input)
            {
                case 1:
                var user = User.AddUser(); 
                users[currentIndex] = user;
                currentIndex++;
                users.Count();
                break;
                case 2:
                break; 
                default:
                Console.WriteLine("Invalid input. Please try again.");
                break;
            }
        }
    }
}
