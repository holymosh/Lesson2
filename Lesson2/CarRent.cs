using System;
using System.Windows.Forms;

namespace Lesson2
{
	public partial class CarRent : Form
	{
        DateTime minDate = System.DateTime.Now;
        private string name_selected_car;
		public CarRent()
		{
			InitializeComponent();
		}
        private void reloadCar()
        {
            FileDatabase fbase = new FileDatabase(@"C:\holymosh\DBase");
            var all_cars = fbase.GetFromDatabase<Car>();
            FileDatabase rent_base = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = rent_base.GetFromDatabase<Rent>();
            CarService service = new CarService(all_cars, rent_dates);
            service.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);
            Car[] available_cars = new Car[service.getCountOfCars];
            available_cars = service.available_cars;
            CarList.Items.Clear();
            CarList.Items.AddRange(available_cars);
        }
        private void CarDescription_TextChanged(object sender, System.EventArgs e)
        {
           
        }

        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedCar = CarList.SelectedItem as Car;
            CarDescription.Text = selectedCar.description;
            name_selected_car = selectedCar.name;

        }

        private void CarRent_Load(object sender, System.EventArgs e)
        {

            FileDatabase car_base = new FileDatabase(@"C:\holymosh\DBase");
            var all_cars = car_base.GetFromDatabase<Car>();
            
          
            
            FileDatabase rent_base = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = rent_base.GetFromDatabase<Rent>();
            CarService service = new CarService(all_cars, rent_dates);
            service.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value);
            Car[] available_cars = new Car[service.getCountOfCars];
            available_cars = service.available_cars;
            CarList.Items.AddRange(available_cars);

        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker1.Value < minDate) dateTimePicker1.Value = minDate;
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
           
            reloadCar();
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
            reloadCar();
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {
            FileDatabase rent_base = new FileDatabase(@"C:\holymosh\DBase");
            var rent_dates = rent_base.GetFromDatabase<Rent>();
            Array.Resize(ref rent_dates, rent_dates.Length + 1);
            rent_dates[rent_dates.Length-1]= new Rent(dateTimePicker1.Value, dateTimePicker2.Value, name_selected_car);
            rent_base.SaveToDatabase<Rent>(rent_dates);
            reloadCar();
        }
    }
}
