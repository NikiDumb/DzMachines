
namespace DzCoffee.Drinks
{
    internal class Orange
    {
        public int DaysAlive { get; private set; }

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
