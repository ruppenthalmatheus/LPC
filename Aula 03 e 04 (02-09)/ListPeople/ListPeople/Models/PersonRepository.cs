using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListPeople.Models
{
    public class PersonRepository
    {

        public static List<Person> _people = new List<Person>();

        public Person getById(int id)
        {
            return _people.Find(a => a.id == id);
        }

        public void create(Person person)
        {
            _people.Add(person);
        }

        public void edit(Person person)
        {
            delete(person.id);
            _people.Add(person);
        }

        public void delete(int id)
        {
            _people.Remove(getById(id));
        }

    }
}