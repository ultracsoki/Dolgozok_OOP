using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozok_OOP
{
    internal class Dolgozo
    {
        private int id;
        private string name;
        private string gender;
        private int age;
        private int salary;

        public Dolgozo(int id, string name, string gender, int age, int salary)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.salary = salary;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public int Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return $"{this.id};{this.name};{this.gender};{this.age};{this.salary}";
        }
    }
}
