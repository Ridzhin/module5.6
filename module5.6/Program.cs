using System;
using System.Xml.XPath;

class MainClass
{
    public static void Main(string[] args)
    {
        (string Name, string Surname, int Age, bool HasPet, string[] PetNames, string[] FavColors) = UserInfoInput();

        UserInfoOutput(Name, Surname, Age, PetNames, FavColors);

        Console.ReadKey();


        static (string Name, string Surname, int Age, bool HasPet, string[] PetNames, string[] FavColors) UserInfoInput()
        {
            (string Name, string Surname, int Age, bool HasPet, string[] PetNames, string[] FavColors) UserInfo;

            Console.WriteLine("Введите имя:");
            UserInfo.Name = Console.ReadLine();

            Console.WriteLine("Введите вид фамилию:");
            UserInfo.Surname = Console.ReadLine();

            string ageinput;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами:");
                ageinput = Console.ReadLine();
            } while (CheckNum(ageinput, out intage));

            UserInfo.Age = intage;

            Console.WriteLine("Есть ли у вас животные? Да или Нет");
            var petinput = Console.ReadLine();
            if (petinput == "Да" || petinput == "да")
            {
                UserInfo.HasPet = true;
            }
            else
            {
                UserInfo.HasPet = false;
            }
            string petnum;
            int petint;
            if (UserInfo.HasPet == true)
            {
                do
                {
                    Console.WriteLine("Напишите количество питомцев цифрами:");
                    petnum = Console.ReadLine();
                } while (CheckNum(petnum, out petint));
                int num = petint;
                UserInfo.PetNames = new string[num];
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("Введите имя питомца {0}", i + 1);
                    UserInfo.PetNames[i] = Console.ReadLine();
                }
            }
            else
            {
                UserInfo.PetNames = new string[] { "У ", "пользователя ", "нет ", "питомцев" };
            }
            string colorsnum;
            int intcolors;
            do
            {
                Console.WriteLine("Напишите количество любимыж цветов цифрами:");
                colorsnum = Console.ReadLine();
            } while (CheckNum(colorsnum, out intcolors));
            UserInfo.FavColors = new string[intcolors];
            for (int j = 0; j < intcolors; j++)
            {
                Console.WriteLine("Введите цвет {0}", j + 1);
                UserInfo.FavColors[j] = Console.ReadLine();
            }
            return UserInfo;
        }

        static void UserInfoOutput(string Name, string Surname, int Age, string[] PetNames, string[] FavColors)
        {
            Console.WriteLine("Имя {0}", Name);
            Console.WriteLine("Фамилия {0}", Surname);
            Console.WriteLine("Возраст {0}", Age);
            for (int i = 0; i < PetNames.Length; i++)
            {
                Console.WriteLine("Имя питамца {0}: {1}", i + 1, PetNames[i]);
            }
            for (int i = 0; i < PetNames.Length; i++)
            {
                Console.WriteLine("Любимый цвет {0}: {1}", i + 1, FavColors[i]);
            }
        }

        static bool CheckNum(string input, out int intresult)
        {
            if (int.TryParse(input, out int intnum))
            {
                if (intnum > 0)
                {
                    intresult = intnum;
                    return false;
                }
            }
            {
                intresult = 0;
                return true;
            }
        }


    }
}