// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Project
{
    public class Program
    {
        public static void Main()
        {
            var humans = new List<Human>();

            while (true)
            {
                PrintMenu();
                var choice = DoChoice(0, 5);

                switch (choice)
                {
                    case 1:
                        PrintNewHumanMenu();
                        var newHumanCoice = DoChoice(1, 3);

                        switch (newHumanCoice)
                        {
                            case 1:
                                var student = new Student();
                                student.RequestInfo();
                                humans.Add(student);
                                break;
                            case 2:
                                var employee = new Employee();
                                employee.RequestInfo();
                                humans.Add(employee);
                                break;
                            case 3:
                                var driver = new Driver();
                                driver.RequestInfo();
                                humans.Add(driver);
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("\tВведите id человека: ");
                        var idRequestInfo = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                            if (idRequestInfo == human.Id)
                                human.RequestInfo();
                            else
                                Console.WriteLine("Человек не найден");
                        
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("\tВведите id человека: ");
                        var idRemoveHuman = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                            if (idRemoveHuman == human.Id)
                                humans.Remove(human);
                            else
                                Console.WriteLine("Человек не найден");
                        
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("\tВведите id человека: ");
                        var idPrintInfo = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                            if (idPrintInfo == human.Id)
                                Console.WriteLine(human.ToString());
                            else
                                Console.WriteLine("Человек не найден");
                        
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Список всех людей: ");
                        
                        foreach (var human in humans)
                            Console.WriteLine(human.ToString());

                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Добавить информацию о новом человека\n" +
                              "2 - Редактировать информацию о человеке\n" +
                              "3 - Удалить информацию о человеке\n" +
                              "4 - Вывести информацию о человеке\n" +
                              "5 - Вывести информацию о всех людях\n" +
                              "0 - Завершить программу");
        }

        public static void PrintNewHumanMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Добавить студента\n" +
                              "2 - Добавить рабочего\n" +
                              "3 - Добавить водителя");
        }

        public static int DoChoice(int from, int to)
        {
            while (true)
            {
                Console.Write("\tВыберите действие: ");

                if (int.TryParse(Console.ReadLine(), out var choice) && choice >= from && choice <= to)
                {
                    Console.Clear();
                    return choice;
                }

                Console.WriteLine($"Необходимо ввести число от {from} до {to}");
            }
        }
    }
}