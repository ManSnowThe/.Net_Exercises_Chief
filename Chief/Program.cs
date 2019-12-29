using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chief
{
    /// <summary>
    /// Класс Program. Основной класс приложения.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод Main. Главный метод программы.
        /// </summary>
        /// <param name="args">Его аргументы</param>
        static void Main(string[] args)
        {
            Olivie Oliv = new Olivie("Olivie");

            Console.WriteLine("Салат: " + Oliv.GetName());
            Oliv.ShowVegetables();

            Console.WriteLine();

            Oliv.SortVegetablesByCalories();
            Oliv.ShowVegetables();

            Console.WriteLine();

            Console.WriteLine("Всего калорий: " + Oliv.SumCalories());

            Console.WriteLine();

            Oliv.AddVegetable(new Vegetable("Garlic", "Type", 200));
            Oliv.ShowVegetables();
        }
    }

    /// <summary>
    /// Интерфейс IVegetable. Используется для класса Vegetable.
    /// </summary>
    public interface IVegetable
    {
        /// <summary>
        /// Свойство Name. Задает имя овощу.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство Type. Задает тип овощу.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Свойство Calory. Задает количество калорий овощу.
        /// </summary>
        double Calory { get; set; }

        /// <summary>
        /// Метод GetName(). Получает имя овоща.
        /// </summary>
        /// <returns>Имя овоща</returns>
        string GetName();

        /// <summary>
        /// Метод GetType(). Получает тип овоща.
        /// </summary>
        /// <returns>Имя типа овоща</returns>
        string GetType();

        /// <summary>
        /// Метод GetCalory. Получает количество калорий.
        /// </summary>
        /// <returns>Калории</returns>
        double GetCalory();
    }

    /// <summary>
    /// Класс Vegetable. Используется для создания новый овощей, реализует интерфейс IVegetable.
    /// </summary>
    class Vegetable : IVegetable
    {
        private string name;
        private string type;
        private double calory;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public double Calory
        {
            get
            {
                return calory;
            }
            set
            {
                calory = value;
            }
        }

        /// <summary>
        /// Конструктор Vegetable. При создании нового овоща нужно ввести его имя, тип и количество калорий.
        /// </summary>
        /// <param name="name">Имя овоща</param>
        /// <param name="type">Тип овоща</param>
        /// <param name="calory">Количество калорий</param>
        public Vegetable(string name, string type, double calory)
        {
            Name = name;
            Type = type;
            Calory = calory;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetType()
        {
            return Type;
        }

        public double GetCalory()
        {
            return Calory;
        }
    }

    /// <summary>
    /// Интерфейс ISalad. Используется для класса Salad.
    /// </summary>
    interface ISalad
    {
        /// <summary>
        /// Свойство Name. Задаем имя салату или возвращает его.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Метод GetName(). Получает имя салата.
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Метод SetName(). Задает имя салату.
        /// </summary>
        /// <param name="name">Имя салата</param>
        void SetName(string name);

        /// <summary>
        /// Метод AddVegetable(). Позволяет добавлять новый овощ в салат.
        /// </summary>
        /// <param name="vegetable">Объект Vegetable</param>
        void AddVegetable(Vegetable vegetable);

        /// <summary>
        /// Метод ShowVegetables(). Показывает все необходимые овощи для приготовления салата.
        /// </summary>
        void ShowVegetables();

        //void SortVegetablesByName();
        //void SortVegetablesByType();


        /// <summary>
        /// Метод SumCalories(). Подсчитывает общее количество калорий в салате.
        /// </summary>
        /// <returns>Сумму всех калорий</returns>
        double SumCalories();

        /// <summary>
        /// Метод SortVegetablesByCalories(). Сортирует все овощи по количеству калорий.
        /// </summary>
        void SortVegetablesByCalories();
    }

    /// <summary>
    /// Класс Salad. Используется для создания новых салатов, реализует интерфейс ISalad.
    /// </summary>
    abstract class Salad : ISalad
    {
        private string name;
        private List<Vegetable> Vegetables = new List<Vegetable>();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Конструктор Salad. При создании нового салата вводим его имя.
        /// </summary>
        /// <param name="name">Имя салата</param>
        public Salad(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddVegetable(Vegetable vegetable)
        {
            Vegetables.Add(vegetable);
        }

        public void ShowVegetables()
        {
            foreach(var veg in Vegetables)
            {
                Console.WriteLine("Name: " + veg.GetName() + "    Calories: " + veg.GetCalory());
            }
        }

        public double SumCalories()
        {
            double temp = 0;
            foreach(var cal in Vegetables)
            {
                temp += cal.Calory;
            }
            return temp;
        }

        public void SortVegetablesByCalories()
        {
            Vegetables.Sort(new VegetablesSort());
        }
    }

    /// <summary>
    /// Класс Olivie. Наследует от класса Salad.
    /// </summary>
    class Olivie : Salad
    {
        public Olivie(string name) : base(name)
        {
            SetName(name);
            AddVegetable(new Vegetable("Potato", "Type", 120));
            AddVegetable(new Vegetable("Cucumber", "Type", 60));
            AddVegetable(new Vegetable("Onion", "Type", 70));
            AddVegetable(new Vegetable("Peas", "Type", 40));
        }
    }



    /// <summary>
    /// Класс VegetablesSort(). Для сортировки овощей по калориям, реализует интерфейс IComparer.
    /// </summary>
    class VegetablesSort : IComparer<Vegetable>
    {
        public int Compare(Vegetable veg1, Vegetable veg2)
        {
            return (int)(veg1.GetCalory() - veg2.GetCalory());
        }
    }
}
