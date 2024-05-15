// See https://aka.ms/new-console-template for more information

//Introduction to OOP

//Abstraction

using OOP.Interfaces;
using OOP.Models;
using OOP.Operations;
using System.Collections;

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

//Generics are classes that can  accept any data type when creating an object of the class
//Collections are classes in C# that allow to have a collection or group of any data type
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
    //Console.WriteLine(name);
} 

var nameP = test.FirstOrDefault(x=> x.Key == 3);
//Console.Write(nameP);

ResponseModel<int> response = new ResponseModel<int>();


//Console.WriteLine(response.GetValue(30));
//response.Value = someClass;

var someClass = new Class();
Dictionary<int, string> classPairs = new Dictionary<int, string>();

classPairs.Add(1, "Kazeem");
classPairs.Add(2, "Kazeem");


foreach (var value in classPairs)
{

  //  Console.WriteLine(value);
}

HashSet<int> values = new HashSet<int>();
values.Add(1);
values.Add(2);
values.Add(2);
values.Add(3);
values.Add(4);
values.Add(1);// this guy won't be added because it's the same as the first one


ArrayList arrayList = new ArrayList();
arrayList.Add(values);


//Stacks FILO.. First in, last out
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);


stack.Pop();
//foreach (var value in stack)
//{

//    Console.WriteLine(value);
//}


//Queues FIFO.. First in, First out

Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

queue.Dequeue();
foreach (var value in queue)
{

    //Console.WriteLine(value);
}




