// See https://aka.ms/new-console-template for more information
//.WriteLine("Hello, World!");


using ExpenseApp.DataAccess.Repositories;

var expenseCategoryRepository = new ExpenseCategoryRepository();

var categories = await expenseCategoryRepository.GetAllCategories();
foreach (var category in categories)
{
    Console.WriteLine($"Id: {category.Id}\nName: {category.Name}\nUserId: {category.UserId ?? 0}");
}


//ASP.NET