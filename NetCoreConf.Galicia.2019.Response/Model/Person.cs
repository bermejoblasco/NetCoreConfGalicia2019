using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreConf.Galicia._2019.Response.Model
{
    public enum TypePerson
    {
        Speaker,
        Staff,
        Attendant
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypePerson Type { get; set; }

        public int RankingValue { get; set; }

        public Person(int id, string name, TypePerson type = TypePerson.Speaker)
        {
            Id = id;
            Name = name;
            RankingValue = new Random().Next(0, 100);
        }
    }
}
