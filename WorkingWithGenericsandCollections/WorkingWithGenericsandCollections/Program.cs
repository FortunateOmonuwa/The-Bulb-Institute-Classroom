//Generic
//A generic class can have both generic and non generic properties.
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;
Dictionary<int, GenericClass<string>> keyValues = [];

GenericClass<string> genericClass = new GenericClass<string>();
genericClass.Name = "Fortunate";
genericClass.Age = 30;

GenericClass<string> genericClass2 = new()
{
    Name = "Afeez",
    Age = 45
};

keyValues.Add(genericClass.Age, genericClass);
keyValues.Add(genericClass2.Age, genericClass2);

foreach (var key in keyValues)
{
    Console.WriteLine($"{key.Key} {key.Value.Name}");
}

//GenericClass<GenericClass2> genericClass3 = new ();
IGenericInterface2<string> genericClass21 = new GenericClass2<string>();



static int[] Sorting(int[] ints)
{
    return ints.OrderBy(x => x).ToArray();
}






Console.WriteLine("Enter an camelCased string");

string? userInput = Console.ReadLine();
string changeCase = CamelCase(userInput);
Console.WriteLine(changeCase);




static string CamelCase(string value)
{
    // You put in any code that can break you program...

    try
    {
        var builder = new StringBuilder();
        foreach (char i in value)
        {
            if (char.IsUpper(i))
            {
                builder.Append(' ');
            }
            builder.Append(i);
        }

        return builder.ToString();
    }

    catch (Exception) //Global exception handling...When you are not sure about the exception your project might throw
    {
        throw new Exception();
    }


}



//-----------------------------------------------------------------------------
class GenericClass<T>
{
    public int Age { get; set; }
    public T Name { get; set; }
}
class GenericClass2<T> : GenericClass<T>, IGenericInterface<string>
{
    public int Id { get; set; }
}

interface IGenericInterface<T> : IGenericInterface2<string>
{

}
interface IGenericInterface2<T>
{

}
//S: Single responsibility... A class is to be responsible for one thing and one thing only
//o: Open and close principle... A class should be open for extension, but closed for modification
//l: Liskov substitution princple... A child class can repreesent the parent class when 
//i: Interface segregation
//d: Dependency Inversion... Classes should only inherit inherit from interfaces or abstract classes


//Dictionary


//Exception Handling
//Try and Catch... Finally



//
