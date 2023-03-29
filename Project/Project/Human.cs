// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Project
{
    public abstract class Human
    {
        private static int _nextId;
        private string _surname;
        private string _name;
        private string _patronymic;
        private DateOnly _birthday;

        public int Id { get; }
        
        public Human()
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("---Вызван конструктор без параметров класса Human---");
        }
    
        public Human(string surname, string name, string patronymic, DateOnly birthday)
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("---Вызван конструктор с параметрами класса Human---");
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _birthday = birthday;
        }
    
        public Human(Human human)
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("---Вызван конструктор копированя класса Human---");
            _surname = human._surname;
            _name = human._name;
            _patronymic = human._patronymic;
            _birthday = human._birthday;
        }

        public void EditName()
        {
            while (true)
            {
                Console.Write("Имя - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _surname = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditSurname()
        {
            while (true)
            {
                Console.Write("Фамилия - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _surname = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }
        
        public void EditBirthday()
        {
            while (true)
            {
                Console.Write("Дата рождения - ");
                var value = Console.ReadLine();
                
                if (DateOnly.TryParse(value, out var date))
                {
                    _birthday = date;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести дату в формате гггг/мм/дд. Попробуйте ещё раз!");
            }
        }
        
        public void EditPatronymic()
        {
            while (true)
            {
                Console.Write("Отчество - ");
                var value = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out _))
                {
                    _surname = value;
                    return;
                }
                    
                Console.WriteLine("Необходимо ввести строку. Попробуйте ещё раз!");
            }
        }

        public int FullYears()
        {
            return DateTime.Now.Year - _birthday.Year;
        }
    
        public string ToString()
        {
            return "\nId - " + Id + "\nSurname - " + _surname + "\nName - " + _name + "\nPatronymic - " + _patronymic + "\nBirthday - " + _birthday;
        }
    
        public void RequestInfo()
        {
            EditSurname();
            EditName();
            EditPatronymic();
            EditBirthday();
        }
    
        ~Human()
        {
            Console.WriteLine("---Вызван деструктор класса Human---");
        }
    }
}