using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCode
{
    public class CodeHelper
    {
        static List<string> uniqueCodeList = new List<string>();
      
        public static string GenerateCode()
        {
            var charset = "ACDEFGHKLMNPRTXYZ234579";
            var charsetArray = charset.ToArray();

       

        s1:
           
            //8 karakterlik sonuç istendiğinden
            var result = new char[8];

            Random random = new();

            for (int i = 0; i < 8; i++)
            {
                var randomIndex = random.Next(charsetArray.Length);
                result[i] = charsetArray[randomIndex];
            }


            var generatedCode = new string(result);

            if (uniqueCodeList.Contains(generatedCode))
            {
                Console.WriteLine("S1 çalıştı");
                goto s1;
              
            }
            uniqueCodeList.Add(generatedCode);

            return generatedCode;
        }


        public static bool ValidateCode(string code)
        {
            //Gereklilikler
            //Girilen kod 8 karakter olmalı
            //Girilen kod ACDEFGHKLMNPRTXYZ234579 bu karakterleri içermeli


            //Herhangi bir veriseti içerisinde olmadan kodun üretilmiş bir kod olduğu nasıl doğrulanacak ??? 

            if(code.Length != 8)
            {
                return false;
            }

            var charset = "ACDEFGHKLMNPRTXYZ234579";

            foreach (var charItem in code.ToArray())
            {
                if (!charset.Contains(charItem))
                {
                    return false;
                } 

            }

            return true;
        }
    }
}
