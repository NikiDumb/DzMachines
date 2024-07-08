using DzCoffee.Drinks;

namespace DzCoffee.Machines
{
    internal class JuiceMachine
    {
        public List<Orange> Oranges { get; set; }

        public JuiceMachine(List<Orange> oranges)
        {
            Oranges = oranges;
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

        public void SqueezeJuice()
        {
            if (Oranges.Count < 2)
            {
                throw new Exception("Апельсинов нет((");
            }

            Oranges.RemoveRange(0, 2);

            Console.WriteLine("Ваш сок!!!");
        }

    }
}
