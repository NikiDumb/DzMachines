
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

        public override bool Equals(object? obj)
        {
            return obj is Orange orange &&
                   DaysAlive == orange.DaysAlive;
        }
    }
}
