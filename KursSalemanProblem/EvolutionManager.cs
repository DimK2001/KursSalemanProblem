using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic
{
    internal class EvolutionManager
    {
        List<Population> populations = new List<Population>();
        Random rnd = new Random();
        public int[] shortPath;
        public double shortest = double.MaxValue;
        int pointCount = 3;
        int[][] coord;
        public void InitPipolation(int populationCount, int points)
        {
            pointCount = points;
            coord = new int[points][];
            Population population = new Population();
            for (int i = 0; i < populationCount; i++)
            {
                List<int> exons = new List<int>();
                for (int j = 0; j < pointCount; ++j)
                {
                    exons.Add(j);
                }
                int x = rnd.Next(1, pointCount - 1);
                int y = rnd.Next(1, pointCount - 1);
                int tmp = exons[x];
                exons[x] = exons[y];
                exons[y] = tmp;
                population.NewIndovidual(exons);
            }
            populations.Add(population);
            for (int i = 0; i < pointCount; i++)
            {
                coord[i] = new int[2];
            }
            for (int i = 0; i < pointCount; i++)
            {
                int tmp = rnd.Next(0, 1000);
                Console.Write(i + " X=" + tmp);
                coord[i][0] = tmp;
                tmp = rnd.Next(0, 1000);
                Console.WriteLine(" Y=" + tmp);
                coord[i][1] = tmp;
            }
        }
        public double GetNewGeneration()
        {
            double loss = double.MaxValue;
            Population currentPopulation = populations[populations.Count - 1];
            List<Individual> winners = new List<Individual>();
            Population newPopulation = new Population();
            for (int i = 0; i < currentPopulation.individuals.Count; i++)
            {
                int winner = 0;
                double winnerVal = double.MaxValue;
                for (int j = 0; j < 3; ++j)
                {
                    int spc = rnd.Next(currentPopulation.individuals.Count);
                    if (currentPopulation.individuals[spc].GetFitness(coord) < winnerVal)
                    {
                        winner = spc;
                        winnerVal = currentPopulation.individuals[spc].GetFitness(coord);
                        if (loss > winnerVal)
                        {
                            loss = winnerVal;
                        }
                    }
                }
                winners.Add(currentPopulation.individuals[winner]);
                if (shortest > currentPopulation.individuals[i].GetFitness(coord))
                {
                    shortest = currentPopulation.individuals[i].GetFitness(coord);
                    shortPath = currentPopulation.individuals[i].GetExons().ToArray();
                }
            }
            for (int i = 0; i < winners.Count / 2; ++i)
            {
                List<Individual> crossed = newPopulation.Crossingover(new List<Individual>
                { winners[i * 2], winners[i * 2 + 1] }, 3);
                newPopulation.NewIndovidual(crossed[0].Chromosome.GetExons());
                newPopulation.NewIndovidual(crossed[1].Chromosome.GetExons());
            }
            if (winners.Count % 2 > 0)
            {
                List<Individual> crossed = newPopulation.Crossingover(new List<Individual>
                { winners[winners.Count - 1], winners[winners.Count - 2] }, 3);
                newPopulation.NewIndovidual(crossed[0].Chromosome.GetExons());
                newPopulation.NewIndovidual(crossed[1].Chromosome.GetExons());
            }
            foreach (Individual individual in newPopulation.individuals)
            {
                individual.Mutation();
            }
            populations.Remove(currentPopulation); populations.Add(newPopulation);
            //Console.WriteLine(populations.Count - 1 + " Error: " + loss + " X=" + bestX + " Y=" + bestY);
            return loss;
        }
    }
}
