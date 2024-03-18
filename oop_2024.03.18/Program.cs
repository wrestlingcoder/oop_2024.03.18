using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_2024._03._18
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Person> users = new List<Person>(); // создаем список users из элементов класса Person
            while (true)
            {

                Console.WriteLine("Введите данные нового пользователя, или Выход для выхода:");
                string userString = Console.ReadLine();
                if (userString == "Выход")
                {
                    break;
                }

                //Саша, Зуев, 30, ПИК

                string[] userArray = userString.Split(',');
                Person newUser;  // объявляю переменную

                if (userArray.Length == 4)
                {
                   int userAge = Convert.ToInt32(userArray[2]);
                   newUser = new Person(userArray[0], userArray[1], userAge, userArray[3]);
                }
                else
                {
                    int userAge = Convert.ToInt32(userArray[1]);
                    newUser = new Person(userArray[0], userAge, userArray[2]);
                }
                users.Add(newUser); // добавляем нового пользователя в список элементов класса Person
            }

            Console.WriteLine("Список добавленных пользователей:");
            foreach(Person user in users)
            {
                Console.WriteLine(user.GetInfo(true));
            }
            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name = "Unknown";
        public string Surname;
        public int Age;
        public string Company = "Пик-Проект";

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="age">Возраст, лет</param>
        /// <param name="company">Место работы</param>
        public Person(string name, string surname, int age, string company) //вводим конструктор Person 

        {
            Name = name.Replace(" ","");
            Surname = surname.Replace(" ", "");
            Age = age;
            Company = company.Replace(" ", "");
        }


        public void ShowInfo()  //вводим Метод ShowInfo 

        {
            Console.WriteLine("Новый пользователь: " + Surname + " " + Name + ", " + Age.ToString());
        }
        

        /// <summary>
        /// Указать информацию, когда имя и фамилия в одной строке
        /// </summary>
        /// <param name="nameAndSurname">Имя и фамилия, разделенные пробелом</param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="company"></param>
        public Person(string nameAndSurname, int age, string company)
        {
            Name = nameAndSurname.Split(' ')[0];
            Surname = nameAndSurname.Split(' ')[1];
            Age = age;
            Company = company;
        }

        public string GetInfo(bool GetExtendedInfo) // вводим метод и указываем тип возвращаемого значения и нужно вернуть значение
        { 
            if (GetExtendedInfo) 
            {
                string info = Surname + " " + Name + ", " + Age.ToString() + ", " + Company;
                return info;
            }
            else
            {
                string info = Surname + " " + Name + ", " + Age.ToString();
                return info;
            }
        
        }
    }
}
