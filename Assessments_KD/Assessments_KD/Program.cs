// See https://aka.ms/new-console-template for more information


string[] arrayofstrings = { "Volvo", "BMW", "Ford", "Mazda" , "Esther", "Qosim", "Doskit", "Dosunmu", "Kolawole", "Kazeem","Idowu", "Temitayo"};

arrayofstrings[3] = "Taiwo";
arrayofstrings[0] = "Lexus";
arrayofstrings[1] = "Toyota";

//for (int i = 0; i < arrayofstrings.Length; i++)
foreach (string s in arrayofstrings)
{
    char lastLetter = s[s.Length - 1];

    char lastLetterToUpper = char.ToUpper(lastLetter);

    //arrayofstrings = lastLetterToUpper.ToString();
        
    Console.WriteLine(s.Replace(lastLetter, lastLetterToUpper));
    
}



