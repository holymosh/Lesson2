using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class CarService
    {
       private Car [] cars;
        private Rent[] rent;
        public CarService(Car[] cars, Rent[] rent)
        {
            this.cars = cars;
            this.rent = rent;
        }
        public Car[] getAvailableCars(DateTime fromDatetime,DateTime toDateTime)
       {
            Car[] AvailableCars = new Car[cars.Length];
            bool flag = true;
            int count_of_available_cars = 0;
            for(int i = 0; i < cars.Length; i++)
            {
                for(int j = 0; j < rent.Length; j++)
                {
                    if (cars[i].name == rent[j].nameCar)
                    {
                        if ((rent[j].begindate < toDateTime && rent[j].begindate > fromDatetime) || (rent[j].enddate < toDateTime && rent[j].enddate > fromDatetime)) flag = false;
                    }
                }
                if(flag==true)
                {
                    AvailableCars[count_of_available_cars] = cars[i];
                    count_of_available_cars++;
                }
            }
            return AvailableCars;

        }
        
    }
}
