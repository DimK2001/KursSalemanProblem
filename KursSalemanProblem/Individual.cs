namespace Genetic
{
    public class Individual
    {
        public Chromosome Chromosome;
        public Individual(List<int> exons)
        {
            SetChromosome(exons);
        }
        public void SetChromosome(List<int> exons)
        {
            Gen firstGene = new Gen(exons);
            List<Gen> genes = new List<Gen>() { firstGene };
            Chromosome = new Chromosome(genes);
        }
        public double Fitness(int[] points, int[][] coord)
        {
            double way = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                way += Math.Sqrt(Math.Pow(coord[points[i + 1]][0] - coord[points[i]][0], 2) + Math.Pow(coord[points[i + 1]][1] - coord[points[i]][1], 2));
            }
            way += Math.Sqrt(Math.Pow(coord[points[0]][0] - coord[points[points.Length - 1]][0], 2) + Math.Pow(coord[points[0]][1] - coord[points[points.Length - 1]][1], 2));
            return way;
        }
        public void Mutation()
        {
            foreach (var g in Chromosome.Gens)
            {
                Random random = new Random();
                float probability = 4;
                if (random.Next(0, 10) < probability)
                {
                    g.Mutation();
                }
            }
        }
        public List<int> GetExons()
        {
            return Chromosome.GetExons();
        }
        public double GetFitness(int[][] coord)
        {
            return Fitness(GetExons().ToArray(), coord);
        }
    }
}
