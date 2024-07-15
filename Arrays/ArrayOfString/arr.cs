using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfString
{
    public class arr
    {
        string[] names = new string[] { "aknbi", "afeez", "fortunate", "kazeem", "sulaimon" };
         
      public void Getnames()
        {
            foreach (string name in names)
            
            {
                Console.WriteLine(name);
            }
        }
 
    public void GetCapitalizeLAstCharacter()
        {
            foreach (string name in names)
            {
                char lastAlphabet = name[name.Length - 1];

                char capitalizeLastAlphabet = char.ToUpper(lastAlphabet);



                //Console.WriteLine(capitalizeLastAlphabet);

                Console.WriteLine(name.Replace(lastAlphabet, capitalizeLastAlphabet));
            }
        }
      


}
}
