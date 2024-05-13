// See https://aka.ms/new-console-template for more information

//Introduction to OOP

//Abstraction

using OOP.Interfaces;
using OOP.Models;

//Animal animal = new Animal();



//Animal animal = new Cat();

//animal.CreateAnimal("Cat", "Meo Meow", 30);
//Console.Write(animal.CreateAnimal(description: "woof woof", number:12, name: "Dog"));


IAnimal animal1 = new Cat();



//Encapsulation 


//Inheritance 
//A class can inherit from only one class
//A class can inherit from multiple interfaces
//An interface can inherit from only interfaces and not classes
//An interface can inherit from multiple interfaces

//Polymorphism



//SOLID Principles
//S: Single responsibility...  class should be responsible for only one thing....


//Collections
//Arrays
//ArrayList
//List
//Dictionaries
//HashSets
//Stacks
//Queues

//Generics.... Classes in c# that allow you to pass in any type T


//int[] animal = []; //arrays are not generic
Class[] clas = new Class[10];
clas[0]= new Class();

clas[1]= new Class();
//Systems.Collection.Generic
List<Class> classes = new List<Class>()
{
    new Class(),
    new Class(),
    new Class(),
    new Class(),
    new Class()
};


classes.Add(new Class());
classes.Add(new Class());
classes.Add(new Class());


List<string> names = new List<string>()
{
    "Fortunate",
    "Akanbi",
    "Sulaiman",
    "Afeez",
    "Kazeem"
};



names.Add("Fortunate");
//foreach(var name in names)
//{
//    Console.WriteLine(name);
//}
Class @class = new Class();


Dictionary<int, string> test = new Dictionary<int, string> ();

test.Add(1, "Fortunate");//key and value pairs
test.Add(2, "Kazeem");//key and value pairs
test.Add(3, "Afeez");//key and value pairs
test.Add(4, "Akanbi");//key and value pairs
test.Add(5, "Sulaiman");//key and value pairs

foreach (var name in test)
{
    Console.WriteLine(name);
} 

var nameP = test.FirstOrDefault(x=> x.Key == 3);
Console.Write(nameP);