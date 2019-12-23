using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    /*Создать класс "Произведение искусства". 
     * Поля: Художник (скульптор, живописец, etc),
     * Название произведения искусства, 
     * Год создания. 
Создать массив объектов-произведений искусства (данные можно прочитать из файла).
Отсортировать массив по художникам, по дате создания. 
Вывести отсортированный массив на консоль, для вывода использовать foreach.
Создать список художник-количество произведений, созданных данным художником. Вывести список на консоль.*/


    

    class Program
    {
        static void Main(string[] args)
        {
            artWorck[] arr = new artWorck[]
            {
                new artWorck{ Creator="Ахудожник", Name="Мишки в лесу", Date= new DateTime(1950,12,12)},
                new artWorck{ Creator="Гхудожник", Name="Мишки в поле", Date= new DateTime(1960,12,12)},
                new artWorck{ Creator="Вхудожник", Name="Мишки в степи", Date= new DateTime(1970,1,12)},
                new artWorck{ Creator="Бскульптор", Name="Мишки на коне", Date= new DateTime(1980,9,12)},
                new artWorck{ Creator="Бхудожник", Name="Мишки в прыжке", Date= new DateTime(1990,11,12)},
                new artWorck{ Creator="Аскульптор", Name="Мишки в горах", Date= new DateTime(1910,10,12)}
            };
            museum museum1 = new museum(arr);
            museum1.Show();
            Console.WriteLine("========================");
            museum1.saveToFile("bears.txt");
            museum1.readFile("bears.txt");
            Console.WriteLine("========================");
            museum1.Show();
            Console.WriteLine("=====by=Creator=========");
            museum1.Sort(1);
            museum1.Show();
            Console.WriteLine("=====by=Name============");
            museum1.Sort(2);
            museum1.Show();
            Console.WriteLine("======by=Date===========");
            museum1.Sort(3);
            museum1.Show();
            Console.WriteLine("=======Total==Counts====");
            museum1.countWorksByCreators();

            Console.ReadKey();
        }
    }
}
