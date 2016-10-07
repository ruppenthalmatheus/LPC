using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListPeople.Models
{
    public class CarRepository
    {

        public static List<Car> _cars = new List<Car>();

        public Car getById(int id)
        {
            return _cars.Find(a => a.id == id);
        }

        public void create(Car car)
        {
            _cars.Add(car);
        }

        public void edit(Car car)
        {
            delete(car.id);
            _cars.Add(car);
        }

        public void delete(int id)
        {
            _cars.Remove(getById(id));
        }

    }
}