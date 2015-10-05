
namespace Lesson2
{
   public class Car
    {
        private string _name;
        private string _description;
        public Car(string name, string description)
        {
            _name = name;
            _description = description;
        }
        public string getName()
        {
            return _name;
        }
        public string getDescription()
        {
            return _description;
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
