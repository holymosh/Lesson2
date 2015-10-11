
namespace Lesson2
{
   public class Car
    {
        private string _name;
        private string _description;

        public string name
        {
            get { return _name; }
        }
        public string description
        {
            get { return _description; }
        }
        public Car(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        
        public override string ToString()
        {
            return name;
        }
    }
}
