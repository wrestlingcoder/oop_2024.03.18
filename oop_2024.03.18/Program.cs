using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oop_2024._03._18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> users = new List<Person>(); // создаем список users из элементов класса Person
            while (true)
            {
                int i = 5;
                string s = i.ToString();
                int j = 999;
                int v = j.GetHashCode();

                int p = int.Parse("99");

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
                    string nameAndSurname = userArray[0];
                    newUser = new Person(nameAndSurname, userAge, userArray[2]); //конструктор
                   
                        
                }

                
                users.Add(newUser); // добавляем нового пользователя в список элементов класса Person
            }

            Console.WriteLine("Список добавленных пользователей:");
            foreach (Person user in users)
            {
                Console.WriteLine(user.GetInfo(true));
            }
            Console.ReadKey();
        }
    }

    class Person
    {
        public bool IsValid = false;  // переменная некорректного элемента, если класс создан некорректно IsValid = false
        public string Name = "Unknown";
        public string Surname;
        int _age; //private int _age; внутренняя переменная внутри класса Person

        
        public int Age  //свойство класса
        {
            get //возможность получить значение
            {

                if (_age < 0) return 0;
                return _age;
            }
            set //возможность з значение
            {
                if (value > 0) _age = value; // value - виртуальная конструкция
                else _age = 0;
            }
        }
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
            Name = name.Replace(" ", "");
            Surname = surname.Replace(" ", "");
            if (age < 0)
            {
                _age = 0;
            }
            else
            {
                _age = age;
            }

            Company = company.Replace(" ", "");
        }

        /// <summary>
        /// /1231234
        /// </summary>
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
        public Person(string nameAndSurname, int age, string company) // вводим конструктор Person
        {
            string[] array = nameAndSurname.Split(' ');
            if (array.Length == 2)
            {
                Name = array[0];
                Surname = array[1];
                IsValid = true;
            }
            else 
            {
                Name = array[0];
                Surname = "Бесфамильный";
                IsValid = false;
            }
            _age = age;
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
