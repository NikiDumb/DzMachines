using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    public class JuiceMachine : Machine
    {
        public List<Orange> Oranges { get; set; }

        public JuiceMachine(string name,string address)
            :base(name,address)
        {
            Oranges = new List<Orange>();
            AddOranges(6);
        }
        public override void GetDrink()
        {
            if (Oranges.Count < 2)
            {
                throw new Exception("Апельсинов нет((");
            }
            else
            {
                if (Oranges[0].DaysAlive > 0 || Oranges[1].DaysAlive > 0)
                {
                    Oranges.RemoveRange(0, 2);

                    Console.WriteLine("Ваш сок!!!");
                }
                else
                {
                    isBroken = true;

                    Console.WriteLine("Не будет вашего соку");
                    throw new Exception($"Автомат апельсинов {Name} {Address}. Беда: Сгнили апельсины");
                }
            }

            PassDay();//Я не знаю как реализовать смену дней(((
        }

        public override void ReloadMachineStocks()
        {
            RemoveBadOranges();

            AddOranges(5);
        }

        public void PassDay()
        {
            for (int i = 0; i < Oranges.Count; i++)
            {
                Oranges[i].GoBad();
            }
        }

        public void AddOranges(int countOranges)
        {
            while (countOranges > 0)
            {
                Orange orange = new Orange();

                Oranges.Add(orange);

                countOranges--;
            }
        }

        public void RemoveBadOranges()
        {
            int i = 0;
            while (i < Oranges.Count && Oranges[i].DaysAlive < 1)
            {
                Oranges.RemoveAt(i);
            }
        }
    }
}
