// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


////Entity Framework... ORM used to communicate/query your database ..
//..ORM: Object relational mapper...



//Relationships
//One to one ...One customer to one account
//One to many... One customer to many accounts
//Many to Many... Joint table

//Nugget Packages
//entityframeworkcore.sqlserver
//entityframeworkcore.Design
//entityframeworkcore.Tools
//


using Todolist.DataAccess.Repositories;
using Todolist.Domain.DTOs;

UserRepository userRepository = new UserRepository();

Console.WriteLine("Welcome to GbemGbem Alajo Saboooo");


while (true)
{


    Console.WriteLine("Work with user or work with task\n1 : work with user\n2 : work with task");
    var userChoice = int.Parse(Console.ReadLine());
   
    if (userChoice == 1)
    {
        UserSelection();
    }
    else
    {

    }


    async void UserSelection()
    {
        Console.WriteLine("Pls enter a valid option\n1 : Add User.\n2 : Remove User.\n3 : update.\n5 .\n---------------------------------------");
        var choice = int.Parse(Console.ReadLine());


        switch (choice)
        {
            case 1:
            Console.Write("Enter you name: ");
            var name = Console.ReadLine();
            var newUser = new CreateUserDTO
            {
                Name = name
            };
            var user = await userRepository.AddUser(newUser);
            Console.WriteLine($"User successfully created\n\nId:{user.Id}\nName:{user.Name} ");
            break;
            //----------------------------------------------------------------------------------------
            case 2:
            Console.Write("Enter user id");
            var idToDelete = int.Parse(Console.ReadLine());
            var user_to_delete = await userRepository.DeleteUser(idToDelete);
            Console.WriteLine(user_to_delete);
            break;

            //----------------------------------------------------------------------

            case 3:
            Console.Write("Enter id for whom you need to update: ");
            var idToUpdate = int.Parse(Console.ReadLine());
            Console.Write("Enter name: ");
            var nametoupdate = Console.ReadLine();
            var updateModel = new CreateUserDTO
            {
                Name = nametoupdate
            };

            var updatedUser = await userRepository.UpdateUser(updateModel, idToUpdate);

            Console.WriteLine($"User successfully updated..\n\nId:{updatedUser.Id}\nName:{updatedUser.Name}");
            break;
        }

    }
    async void TaskSelection()
    {

    }

}



