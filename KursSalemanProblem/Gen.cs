namespace Genetic
{
    public class Gen
    {
        public List<int> Exons = new List<int>();
        public Gen(List<int>? exons = null)
        {
            Exons = exons ?? new List<int>();
        }
        public void SetValue(List<int> exons)
        {
            Exons = exons;
        }
        public void Mutation()
        {
            Random rnd = new Random();
            int r1 = rnd.Next(1, Exons.Count);
            int r2 = rnd.Next(1, Exons.Count);
            if (r1 == r2)
            {
                r2 = rnd.Next(1, Exons.Count);
            }
            int tmp = Exons[r1];
            Exons[r1] = Exons[r2];
            Exons[r2] = tmp;
        }
    }
}
