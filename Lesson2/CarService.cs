using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class CarService
    {
       private Car [] all_cars;
        private Rent[] rent_records;
        public CarService(Car[] all_cars, Rent[] rent_records)
        {
            this.all_cars = all_cars;
            this.rent_records = rent_records;
        }
        public Car[] getAvailableCars(DateTime fromDatetime,DateTime toDateTime)
       {
            Car[] AvailableCars = new Car[all_cars.Length];
            bool available_status = true;
            int count_of_available_cars = 0;
            for(int i = 0; i < all_cars.Length; i++)
            {
                for(int j = 0; j < rent_records.Length; j++)
                {
                    if (all_cars[i].name == rent_records[j].nameCar)
                    {
                        if ((rent_records[j].begindate < toDateTime && rent_records[j].begindate > fromDatetime) || (rent_records[j].enddate < toDateTime && rent_records[j].enddate > fromDatetime)) available_status = false;
                    }
                }
                if(available_status==true)
                {
                    AvailableCars[count_of_available_cars] = all_cars[i];
                    count_of_available_cars++;
                }
            }
            return AvailableCars;

        }
        
    }
}
