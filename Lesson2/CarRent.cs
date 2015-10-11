using System;
using System.Windows.Forms;

namespace Lesson2
{
	public partial class CarRent : Form
	{
		public CarRent()
		{
			InitializeComponent();
		}

        private void CarDescription_TextChanged(object sender, System.EventArgs e)
        {
           
        }

        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedCar = CarList.SelectedItem as Car;
            CarDescription.Text = selectedCar.description;
        }

        private void CarRent_Load(object sender, System.EventArgs e)
        {

            FileDatabase car_base = new FileDatabase(@"C:\holymosh\DBase");
            var all_cars = car_base.GetFromDatabase<Car>();
            
          //  DateTime date;
           // date = System.DateTime.Now;
           // Rent[] rent = new Rent[] ;
            
            FileDatabase rent_base = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = rent_base.GetFromDatabase<Rent>();
            CarService service = new CarService(all_cars, rent_dates);
            Car[] available_cars = service.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);
            CarList.Items.AddRange(available_cars);

        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
            FileDatabase car_base = new FileDatabase(@"C:\holymosh\DBase");
            var all_cars = car_base.GetFromDatabase<Car>();
            FileDatabase rent_base = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = rent_base.GetFromDatabase<Rent>();
            CarService service = new CarService(all_cars, rent_dates);
            Car[] available_cars = service.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);
            CarList.Items.Clear();
            if(available_cars!=null)
            CarList.Items.AddRange(available_cars);
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
            FileDatabase fbase = new FileDatabase(@"C:\holymosh\DBase");
            var all_cars = fbase.GetFromDatabase<Car>();
            FileDatabase dbase = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = dbase.GetFromDatabase<Rent>();
            CarService service = new CarService(all_cars, rent_dates);
            Car[] available_cars = service.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);
            CarList.Items.Clear();
            if (available_cars != null)
                CarList.Items.AddRange(available_cars);
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
