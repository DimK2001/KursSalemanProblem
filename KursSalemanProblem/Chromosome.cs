namespace Genetic
{
    public class Chromosome
    {
        public List<Gen> Gens = new List<Gen>();
        public Chromosome(List<Gen>? gens = null)
        {
            Gens = gens ?? new List<Gen>();
        }
        public List<int> GetExons()
        {
            List<int> exons = new List<int>();
            foreach (var gene in Gens)
            {
                exons.AddRange(gene.Exons);
            }
            return exons;
        }
    }
}
