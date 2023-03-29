// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Project
{
    public sealed class Driver : Employee
    {
        private string _carBrand;
        private string _carModel;

        public Driver()
        {
            Console.WriteLine("---Вызван конструктор без параметров класса Driver---");
        }

        public Driver(string surname, string name, string patronymic, DateOnly birthday,
            string organization, decimal salary, int experience, string carBrand, string carModel)
            : base(surname, name, patronymic, birthday, organization, salary, experience)
        {
            Console.WriteLine("---Вызван конструктор с параметрами класса Driver---");
            _carBrand = carBrand;
            _carModel = carModel;
        }

        public Driver(Driver driver) : base(driver)
        {
            Console.WriteLine("---Вызван конструктор копирования класса Driver---");
            _carBrand = driver._carBrand;
            _carModel = driver._carModel;
        }

        public void EditCarBrand()
        {
            while (true)
            {
                Console.Write("Марка машины - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _carBrand = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditCarModel()
        {
            while (true)
            {
                Console.Write("Модель машины - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _carModel = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void RequestInfo()
        {
            base.RequestInfo();
            EditCarBrand();
            EditCarModel();
        }

        public string ToString()
        {
            return base.ToString() + "\nCar Brand - " + _carBrand + "\nCar model - " + _carModel;
        }

        ~Driver()
        {
            Console.WriteLine("---Вызван деструктор класса Driver---");
        }
    }
}