using System;
using System.Collections.Generic;

namespace Homework_number_36
{
    class Program
    {
        static void Main(string[] args)
        {
            const string СommandAddUser = "Add";
            const string CommandPrint = "Print";
            const string CommandDelete = "Delete";
            const string CommandExit = "Exit";

            List<string> fullNames = new List<string>();
            List<string> positions = new List<string>();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine("Меню\n" +
                            "\nДоступные команды\n\n" +
                            $"1) Добавить досье для использования команды ведите {СommandAddUser}\n\n" +
                            $"2) Вывод досье для использования команды ведите {CommandPrint}\n\n" +
                            $"3) Удалить досье для использования команды ведите {CommandDelete}\n\n" +
                            $"5) Выход для использования команды ведите {CommandExit}\n\n" +
                            $"Укажите команду: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case СommandAddUser:
                        AddDossier(fullNames, positions);
                        break;

                    case CommandPrint:
                        PrintDossiers(fullNames, positions);
                        break;

                    case CommandDelete:
                        DeleteFromDatabase(fullNames, positions);
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }
            }
        }

        private static void AddDossier(List<string> fullNames, List<string> positions)
        {
            Console.WriteLine("Укажите Ф.И.О для добавления в базу даных: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Укажите должность для добавления в базу даных: ");
            string position = Console.ReadLine();

            fullNames.Add(fullName);
            positions.Add(position);

            Console.WriteLine("Данные пользователя успешно добавлены!");
        }

        private static void PrintDossiers(List<string> fullNames, List<string> positions)
        {
            if (fullNames.Count > 0)
            {
                for (int i = 0; i < fullNames.Count; i++)
                {
                    Console.WriteLine($"№{i}) {fullNames[i]} - {positions[i]}");
                }
            }
            else
            {
                Console.WriteLine("К сожалению ни одного элемента в базе нет ");
            }
        }

        private static void DeleteFromDatabase(List<string> fullNames, List<string> positions)
        {
            Console.WriteLine("Укажите индекс досье для удаления из базы данных: ");
            string input = Console.ReadLine();
            int indexDossier;

            if (int.TryParse(input, out indexDossier))
            {
                if (indexDossier < fullNames.Count && indexDossier < positions.Count)
                {
                    fullNames.RemoveAt(indexDossier);
                    positions.RemoveAt(indexDossier);

                    Console.WriteLine("Пользователь успешно удалён!");
                }
                else
                {
                    Console.WriteLine("Пользователя под таким индексом нет");
                }
            }
            else
            {
                Console.WriteLine("К сожалению ведённая вами строка не является числом.");
            }
        }
    }
}