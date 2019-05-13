using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected8
{
    class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format($"Surname = {Surname}, Name = {Name}, FathersName = {FathersName},\nAge = {Age}, Weight = {Weight}\n");
        }
    }
}
