using System;
using System.Collections.Generic;
using System.Linq;
    //Компютърна компания е назначила нови служители.Напишете компютърна
    //програма, която да извършва следните действия.
    //1. За всеки служител се въвеждат данни в следния вид:
    // име (знаков низ, не по-дълъг от 50 знака);
    // ЕГН(ЛНЧ) (низ с дължина до 15 знака)
    // име с латински букви(знаков низ, не по-дълъг от 50 знака);
    // местоживеене: държава, пощенски код, град (низове до 30 знака).
    //Броят на новоназначените служители е по-малък от 50.
    //2. Извежда на екрана данни за служителите, сортирани по държава, а тези които
    //са от една и съща държава – сортирани по азбучен ред на името.На всеки отделен ред
    //се извеждат: име, ЕГН, име с латински букви и местоживеене. Данните да бъдат
    //разделени със запетая и интервал. Например:
    //Иван Петров Иванов, 234567890, Ivan Ivanov, България, , Пловдив
    //3. Приемаме, че някои полета са задължителни, т.е.в тях не трябва да има празни
    //низове. Задължителните полета са: име, ЕГН, име на английски и държава.Да се изведе
    //списък със служителите, за които не са въведени задължителните полета.Списъкът да е
    //сортиран по ЕГН.
    //4. За всеки един от служителите трябва да се генерира име на служебна поща по
    //следния начин (данните извличаме от името с латински букви, ако не е празно):
    //‹Фамилия›_‹Име›_‹Първата буква от бащиното име›@nncomputers.com.
    //Ако в името на английски липсват бащино, или първо и бащино име, те се пропускат
    //при генерирането на пощата.Да се изведе списък с имената на новите служители и
    //пощата, за които името на пощата е генерирано успешно.За примера в точка две
    //резултатът ще бъде:
    //Иван Петров Иванов, email: Ivanov_Ivan @nncomputers.com
namespace Exam2017_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n;

                var employees = new List<Employee>();
                
                Console.WriteLine("Please, enter the number of emlpoyees.");
                Console.WriteLine("NOTE: The number of employees cannot be higher than 50");
                n = Convert.ToInt32(Console.ReadLine());

                if (n > 50)
                {
                    throw new IndexOutOfRangeException("The number needs to be lower than 50.");
                }

                for (int i = 0; i < n; i++)
                {
                    var input = Console.ReadLine().Split();
                    var name = string.Join(" ", input[0], input[1]);
                    var egn = input[2];
                    var latinName = string.Join(" ", input[3], input[4]);
                    var country = input[5];
                    var employee = new Employee(name, egn, latinName, country);
                    if (input.Length > 7)
                    {
                        employee.SetPostal(input[6]);
                        employee.SetCity(input[7]); 
                    }
                    employees.Add(employee);
                    
                }

                Console.WriteLine("------------------------------------------------------------");

                var sortedList = employees.OrderBy(e => e.Name).ToList();
                foreach (var employee in sortedList)
                {
                    Console.WriteLine($"{employee.Name}, {employee.EGN}, " +
                                      $"{employee.LatinName}, {employee.Country}, " +
                                      $"{employee.Postal}, {employee.City}");
                }

                var missingInfo = employees.Where(e => e.Postal == null || e.City == null)
                    .OrderBy(e => e.Name)
                    .ToList();
                Console.WriteLine("------------------------------------------------------------");
                foreach (var employee in missingInfo)
                {
                    Console.WriteLine($"{employee.Name}, {employee.EGN}, {employee.LatinName}, {employee.Country}");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine();

                foreach (var employee in employees)
                {
                    if (employee.LatinName != null)
                    {
                        var splitName = employee.LatinName.Split();
                        Console.WriteLine($"{employee.Name}, email: {string.Join("_", splitName)}@hotmail.com");
                    }
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("In order for the program to run, you need to <<ADD EXPLANATION>>");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

        }
        }
    }

