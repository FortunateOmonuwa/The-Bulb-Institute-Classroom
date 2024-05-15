using WorkingWithCollections;
//int idCount = 0;
//List<Staff> staff = new List<Staff>()
//{

//};


while (true)
{

    Console.WriteLine("Enter the Username or Email");
    var emailorusername = Console.ReadLine();
    Console.WriteLine("Enter the Password");
    var password =Console.ReadLine();

    var student = new Student();

    var loginresponse = student.Login(emailorusername, password);
    Console.WriteLine(loginresponse);

    //var response = student.GetStaff(input);
    //Console.WriteLine(response);

  
}


//foreach(var staf in staff2)
//{
//    Console.WriteLine($"{staf.StaffID} {staf.StaffName}");
//}
//List<Staff> staff3 = new List<Staff>()
//{
//    new Staff(){StaffID = 1, StaffName = " Korede"},
//    new Staff(){StaffID = 2, StaffName = " Gabriel"},
//    new Staff(){StaffID = 3, StaffName = " Lamidi"},
//};




