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
            CarDescription.Text = selectedCar.getDescription();
        }

        private void CarRent_Load(object sender, System.EventArgs e)
        {
            var cars = new Car[]
            {
                new Car("БМВ", "Классная машина"),
                new Car("Мерседес", "Классная машина"),
                new Car("Жигули", "машина"),
                new Car("Мазератти", "Классная машина")
            };
            CarList.Items.AddRange(cars);
        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
