// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Project
{
    public class Employee : Human
    {
        private string _organization;
        private decimal _salary;
        private int _experience;

        public Employee()
        {
            Console.WriteLine("---Вызван конструктор без параметров класса Employee---");
        }

        public Employee(string surname, string name, string patronymic, DateOnly birthday,
            string organization, decimal salary, int experience) : base(surname, name, patronymic, birthday)
        {
            Console.WriteLine("---Вызван конструктор с параметрами класса Employee---");
            _organization = organization;
            _salary = salary;
            _experience = experience;
        }

        public Employee(Employee employee) : base(employee)
        {
            Console.WriteLine("---Вызван конструктор копирования класса Employee---");
            _organization = employee._organization;
            _salary = employee._salary;
            _experience = employee._experience;
        }

        public void EditOrganization()
        {
            while (true)
            {
                Console.Write("Организация - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _organization = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditExperience()
        {
            while (true)
            {
                Console.Write("Опыт работы - ");
                var value = Console.ReadLine();
                
                if (int.TryParse(value, out var experience) && experience >= 0 && experience <= 55)
                {
                    _experience = experience;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести число от 0 до 55. Попробуйте ещё раз!");
            }
        }
        
        public void EditSalary()
        {
            while (true)
            {
                Console.Write("Зар. плата - ");
                var value = Console.ReadLine();
                
                if (decimal.TryParse(value, out var salary) && salary >= 0)
                {
                    _salary = salary;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести число от 0. Попробуйте ещё раз!");
            }
        }
        
        public void RequestInfo()
        {
            base.RequestInfo();
            EditOrganization();
            EditSalary();
            EditExperience();
        }

        public string ToString()
        {
            return base.ToString() + "\nOrganization - " + _organization + "\nSalary - " + _salary + "\nExperience - " + 
                   _experience;
        }

        ~Employee()
        {
            Console.WriteLine("---Вызван деструктор класса Employee---");
        }
    }
}