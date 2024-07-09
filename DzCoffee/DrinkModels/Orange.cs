
namespace DzCoffee.Drinks
{
    public class Orange
    {
        public int DaysAlive { get; set; }

        public Orange()
        {
            DaysAlive = 2;
        }

        public void GoBad()
        {
            DaysAlive--;
        }
    }
}
