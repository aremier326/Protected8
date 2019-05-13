using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Protected8
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
            //ThirdTask();
            //FourthTask();
            FifthTask();

            Console.ReadLine();
        }

        //1
        private static void FirstTask()
        {
            using (StreamReader file = new StreamReader("for1task.txt", Encoding.UTF8))
            {
                string text = file.ReadToEnd();

                int count = text.Count(p => p == '(' || p == ')');
                Console.WriteLine($"There is {count} brackets");

                Regex regex = new Regex(@"\(.*?\)");
                MatchCollection matches = regex.Matches(text);

                foreach (var item in matches)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //2
        private static void SecondTask()
        {
            using (StreamReader file = new StreamReader("for2task.txt", Encoding.UTF8))
            {
                // Создаем очередь типа People
                Queue<Person> people = new Queue<Person>();
                while (!file.EndOfStream)
                {
                    string temp = file.ReadLine();
                    var templist = temp.Split(' ');
                    people.Enqueue(new Person
                    {
                        Name = templist[0],
                        Surname = templist[1],
                        FathersName = templist[2],
                        Age = int.Parse(templist[3]),
                        Weight = int.Parse(templist[4])
                    });
                }

                // Создаем подсписок людей, возраст которых меньше 40 лет.
                var youngPeople = from p in people where p.Age < 30 select p;

                var youngPeopleAreFirst = (from b in youngPeople select b).Concat(from c in people select c).Distinct();

                foreach (var person in youngPeopleAreFirst)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        //3
        private static void ThirdTask()
        {
            using (StreamReader file = new StreamReader("for3task.txt", Encoding.UTF8))
            {
                // Создаем очередь типа People
                List<Person> people = new List<Person>();
                while (!file.EndOfStream)
                {
                    string temp = file.ReadLine();
                    var templist = temp.Split(' ');
                    people.Add(new Person
                    {
                        Name = templist[0],
                        Surname = templist[1],
                        FathersName = templist[2],
                        Age = int.Parse(templist[3]),
                        Weight = int.Parse(templist[4])
                    });
                }

                var newListOfPeoples = from person in people orderby person.Age select person;

                foreach (var person in newListOfPeoples)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        //4
        private static void FourthTask()
        {
            using (StreamReader file = new StreamReader("for4task.txt", Encoding.UTF8))
            {
                Stack<int> myInts = new Stack<int>();
                while (!file.EndOfStream)
                {
                    myInts.Push(int.Parse(file.ReadLine()));
                }

                using (StreamWriter newFile = new StreamWriter("outputfor4task.txt"))
                {
                    foreach (var i in myInts)
                    {
                        Console.Write(i + " ");
                        newFile.Write(i + " ");
                    }
                }
            }
        }

        //5
        private static void FifthTask()
        {
            Random rand = new Random();

            // Коллекция типа int.
            List<int> myRandomInts = new List<int>();

            // Цикл для заполнения рандомными числами.

            for (int i = 0; i < 2190; i++)
            {
                myRandomInts.Add(rand.Next(500, 800));
            }

            // Сортировка по возростанию.
            myRandomInts.Sort();

            // Вывод элементов на экран циклом foreach.
            foreach (var item in myRandomInts)
            {
                Console.WriteLine(item);
            }

            // Вставка элемента 9 на 9 позицию.
            myRandomInts.Insert(8, 9);

            // Генерация рандомного числа и проверка, есть ли оно в коллекции(если да то выводим индекс).
            int someRandInt = rand.Next(0, 9) + 500;
            Console.WriteLine($"Here is our rand int: {someRandInt}");

            if (myRandomInts.Contains(someRandInt))
                Console.WriteLine($"Here is index in collection: {myRandomInts.IndexOf(someRandInt)}");
            else
                Console.WriteLine($"\nThere is no such number as {someRandInt} in collection!\n");

            // Удаление рандомного элемента.
            myRandomInts.RemoveAt(rand.Next(0, myRandomInts.Count - 1));

            // Удаление коллекции.
            myRandomInts.Clear();
        }
    }
}
