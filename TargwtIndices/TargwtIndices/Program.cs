// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



int num = int.Parse(Console.ReadLine());
int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());
int num4 = int.Parse(Console.ReadLine());
int num5 = int.Parse(Console.ReadLine());
int num6 = int.Parse(Console.ReadLine());


Console.WriteLine("Add Target");
int target = int.Parse(Console.ReadLine());

Numbers([num, num1, num2, num3, num4, num5, num6], target);
static int Numbers(int[] num, int target)
{
    int length = num.Length;
   // int[2] result = [];
   int number = 0;
    for(int i = 0; i < length; i++)
    {
        var results = num.FirstOrDefault(x => x + num[i] == target);
        if(results == 0)
        {
            Console.WriteLine(" No indices equal to num");
        }

        number = results;
    }
    return number;

}