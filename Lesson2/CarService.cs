using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class CarService
    {
        FileDatabase DBase;
        Rent[] rent;
        public CarService()
        {
         DBase = new FileDatabase(@"C:\holymosh\DBase.txt");
            rent = DBase.GetFromDatabase<Rent>();




        }
        public void getAvailableCars()
        {
            for(int i = 0; i < rent.Length; i++)
            {
                if()
            }

        }
        
    }
}
