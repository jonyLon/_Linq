namespace _Linq
{

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Salary: {Salary}";
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee(){ Name = "John", Age = 30, Salary = 10000},
                new Employee(){ Name = "Ben", Age = 31, Salary = 11000},
                new Employee(){ Name = "Lourens", Age = 38, Salary = 19000},
                new Employee(){ Name = "Romeo", Age = 30, Salary = 10000},
                new Employee(){ Name = "Jorge", Age = 29, Salary = 12000},
            };
            var res = from i in list select new {Name = i.Name, Salary = i.Salary};
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Name}  - {item.Salary}");
            }
            Console.WriteLine();
            var ages = from i in list where i.Age > 30 orderby i.Age descending select i;
            foreach (var item in ages)
            {
                Console.WriteLine(item);
            }
            var average = list.Select(i => i.Age).Average();
            Console.WriteLine("Average age: " + average);
            Console.WriteLine();
            list = new List<Employee>()
            {
                new Employee(){ Name = "John", Age = 30, Salary = 10000, Position = "Manager"},
                new Employee(){ Name = "Ben", Age = 31, Salary = 11000, Position = "Manager"},
                new Employee(){ Name = "Lourens", Age = 38, Salary = 19000, Position = "CEO" },
                new Employee(){ Name = "Romeo", Age = 30, Salary = 10000, Position = "Manager"},
                new Employee(){ Name = "Jorge", Age = 29, Salary = 12000, Position = "Seller"},
            };

            var groups = from i in list group i by i.Position into gr select gr;
            foreach (var g in groups)
            {
                Console.WriteLine("Group: " + g.Key);
                Console.Write("Values: ");
                foreach (var j in g)
                {
                    Console.Write("\n" + j);
                }
                Console.WriteLine();
            }
        }
    }
}