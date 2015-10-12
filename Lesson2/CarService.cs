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
        public Car[] available_cars=new Car[0];
        private int count_of_available_cars;
        public int getCountOfCars
        {
            get { return count_of_available_cars; }
            set { count_of_available_cars = value; }
        }
        public CarService(Car[] all_cars, Rent[] rent_records)
        {
            this.all_cars = all_cars;
            this.rent_records = rent_records;
            count_of_available_cars = 0;
            
        }
        public void getAvailableCars(DateTime fromDatetime,DateTime toDateTime)
       {
            
            bool available_status ;
            
            for(int i = 0; i < all_cars.Length; i++)
            {
                available_status = true;
                for(int j = 0; j < rent_records.Length; j++)
                {
                    if (all_cars[i].name == rent_records[j].nameCar)
                    {
                        if ((rent_records[j].begindate <= toDateTime && rent_records[j].begindate >= fromDatetime) || (rent_records[j].enddate <= toDateTime && rent_records[j].enddate >= fromDatetime)||(toDateTime > rent_records[j].begindate && toDateTime < rent_records[j].enddate) || (fromDatetime > rent_records[j].begindate && fromDatetime < rent_records[j].enddate)) available_status = false;

                    }
                }
                if(available_status==true)
                {
                    Array.Resize(ref available_cars, available_cars.Length + 1);
                    available_cars[count_of_available_cars] = all_cars[i];
                    count_of_available_cars++;
                   
                }
            }
           
            

        }
        
    }
}
