
using FoodCode;

while (true)
{
    Console.WriteLine("Yapmak istediğiniz işlemi seçiniz (1 veya 2):");
    
    Console.WriteLine("1 : Code Üret");
    Console.WriteLine("2 : Code Doğrula");
    Console.WriteLine("3 : Uygulamayı Kapat");

    var inputData = Console.ReadLine();

    if(inputData == "1")
    {
        var code = CodeHelper.GenerateCode();
        Console.WriteLine("Ürettiğiniz code :"+code);
    }

    else if(inputData == "2")
    {
        Console.Write("Doğrulamak istediğiniz kodu giriniz :");
        var validatedCode = Console.ReadLine();

        if (string.IsNullOrEmpty(validatedCode))
        {
            Console.WriteLine("Geçersiz giriş");
        }
        else
        {
            if (CodeHelper.ValidateCode(validatedCode))
            {
                Console.WriteLine("Validasyon başarılı");
            }
            else
            {
                Console.WriteLine("Validasyon başarısız");
            }
        }
       
    }
    else if(inputData == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Tanımsız işlem, lütfen 1 2 yada 3 işlemlerinden birini seçin");
    }
  
}


