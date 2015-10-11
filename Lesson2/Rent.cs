using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
   public class Rent 
    {
        private string carName;
        private DateTime Begindate;
        private DateTime EndDate;
        public string nameCar
        {
            get { return carName; }
            set { carName = "bmw"; }
        }
         public DateTime begindate
        {
            get { return Begindate; }
            set { Begindate = value; }
        }
        public DateTime enddate
        {
            get { return EndDate; }
            set { EndDate = value; }
        }
        public Rent(DateTime begindate, DateTime enddate, string nameCar )
        {
            carName = nameCar;
            Begindate = begindate;
            EndDate = enddate;
        }
    }
}
