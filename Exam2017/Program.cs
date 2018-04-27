using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Exam2017
{

    //Да се състави компютърна програма за обслужване на промоции под формата на
    //карти за отстъпки в магазин за парфюмерия.Броят на клиентите, които могат да се
    //възползват от промоцията е ограничен до 500. Всеки клиент има право на една карта за
    //отстъпки.
    //1. Да се въведе и контролира цяло число N(в диапазона [1;500]), определящо броя
    //на клиентите, имащи право на карта за отстъпки.За всеки от тези N клиенти да се въведе
    //следната информация:
    // име и фамилия(знаков низ, не по дълъг от 30 знака);
    // град на местожителство(знаков низ, не по-дълъг от 10 знака);
    // 10 цифрен код(знаков низ). Първата цифра от него е код за категория стоки(1
    //– козметика, 2 – парфюми, 3 – аксесоари, 4 – услуги). Втората цифра е код за
    //натрупване на промоции, т.е.прилагане на отстъпката върху вече намалена
    //стока(0 – без натрупване, 1 – с натрупване). Втората двойка цифри е процент на
    //отстъпката(05, 10, 20 или 30). Третата двойка цифри от кода обозначават деня,
    //четвъртата – месеца, а петата – годината на датата на издаване на картата.
    //Например код 2020140517 означава, че картата за отстъпки важи за козметика, без
    //натрупване на промоции, процент на отстъпки: 20%, дата на издаване на картата
    //14 май 2017 г.
    //2. Да се изведе списък на всички клиенти, подредени по име в азбучен ред, като за
    //всеки клиент се извежда: име и фамилия, град, категория стоки, натрупване на промоции,
    //процент на отстъпката, дата на издаване на картата.Полетата да бъдат разделени със
    //запетая и един интервал. Например:
    //Петър Иванов, Пазарджик, парфюми, без натрупване, 20, 06.06.17
    //3. Да се изведе списък на клиентите от Пловдив с карта за отстъпки на козметика.
    //Изведената информация за клиент да бъде във формата от условие 2. Списъкът да се
    //подреди в нарастващ ред по процентна отстъпка, а при еднаква стойност клиентите да
    //бъдат подредени по име в азбучен ред.
    //4. Да се въведе категория на стока (например 2). Да се намери и изведе
    //максималният процент на отстъпка за въведената категория.

    class Program
    {
        static void Main(string[] args)
        {
            int n, i;
            List<Client> Clients = new List<Client>();
            Console.WriteLine("Please, enter the number of clients: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || n > 500)
            {
                throw new ArgumentException();
            }

            for (i = 0; i < n; i++)
            {
                var inputCheck = Console.ReadLine();
                if (string.IsNullOrEmpty(inputCheck))
                {
                    throw new ArgumentException();
                }
                var input = inputCheck.Split();
                var client = new Client();
                client.SetName(input[0], input[1]);
                client.SetCity(input[2]);
                client.SetCode(input[3]);
                Clients.Add(client);
            }


            Clients.OrderBy(c => c.Name)
                .ThenBy(c => c.City);
            Console.WriteLine("Sort 1: ");
            foreach (var client in Clients)
            {
                Console.Write(client.Name + " " + client.City);
                var stock = client.Code.Substring(0, 1);
                var discount = client.Code.Substring(1, 1);
                var percent = client.Code.Substring(2, 1) + client.Code.Substring(3, 1);
                var day = client.Code.Substring(5, 1);
                var month = client.Code.Substring(7, 1);
                var year = client.Code.Substring(8, 2);

                
                switch (stock)
                {
                    case "1":
                        Console.Write(" " + "Cosmetics");
                        break;
                    case "2":
                        Console.Write(" " + "Perfumes");
                        break;
                    case "3":
                        Console.Write(" " + "Accessories");
                        break;
                    case "4":
                        Console.Write(" " + "Services");
                        break;
                }
                if (discount == "1")
                {
                    Console.Write(" " + "Discount");
                }
                else
                {
                    Console.Write(" " + "No Discount");
                }
                Console.Write(" " + $"{percent}");

                Console.Write(" " + $"{day}" + "." + $"{month}" + "." + $"{year}");


            }
           
            Console.WriteLine();
            Console.WriteLine("Sort 2: ");
           var sort2 = Clients.Where(c => c.City == "Plovdiv")
                .OrderByDescending(c => c.Code.Substring(2, 1) + c.Code.Substring(3, 1))
                .ThenBy(c => c.Name)
                .ToList();
           
        }

        
    }
}

