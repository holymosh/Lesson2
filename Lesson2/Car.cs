
namespace Lesson2
{
   public class Car
    {
        public string _name
        {
            get { return _name; }
            set { _name = value; }
            
        }
        public string _description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Car(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        
        public override string ToString()
        {
            return _name;
        }
    }
}
