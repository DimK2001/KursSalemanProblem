using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic
{
    public class Population
    {
        public List<Individual> individuals = new List<Individual>();
        public void NewIndovidual(List<int> exons)
        {
            Individual individual = new Individual(exons);
            individuals.Add(individual);
        }
        public List<Individual> Crossingover(List<Individual> parents, int pointsAmount)
        {
            List<int> p1exons = parents[0].Chromosome.GetExons();
            List<int> p2exons = parents[1].Chromosome.GetExons();
            Random random = new Random();
            List<int> possible = Enumerable.Range(1, p1exons.Count - 1).ToList();
            List<int> points = new List<int>();
            for (int i = 0; i < pointsAmount; i++)
            {
                int index = random.Next(0, possible.Count);
                points.Add(possible[index]);
                possible.RemoveAt(index);
            }
            points.Sort();
            List<List<int>> exons = crossingover(p1exons, p2exons, points);
            List<int> ex1 = new List<int>();
            List<int> ex2 = new List<int>();
            for (int i = 0; i < exons[0].Count; ++i)
            {
                if (ex1.Contains(exons[0][i]))
                {
                    for (int j = 1; j < exons[0].Count; ++j)
                    {
                        if (!ex1.Contains(j))
                        {
                            ex1.Add(j);
                            break;
                        }
                    }
                }
                else
                {
                    ex1.Add(exons[0][i]);
                }

                if (ex2.Contains(exons[1][i]))
                {
                    for (int j = 1; j < exons[1].Count; ++j)
                    {
                        if (!ex2.Contains(j))
                        {
                            ex2.Add(j);
                            break;
                        }
                    }
                }
                else
                {
                    ex2.Add(exons[1][i]);
                }
            }
            return new List<Individual>() { new Individual(ex1), new Individual(ex2) };
        }
        public void Clean()
        {
            individuals.Clear();
        }
        public List<List<int>> crossingover(List<int> p1exons, List<int> p2exons, List<int> points)
        {
            int numP = 0;
            List<int> exons1 = new List<int>();
            List<int> exons2 = new List<int>();
            bool parentChoose = false;
            exons1.Add(p1exons[0]);
            exons2.Add(p2exons[0]);
            for (int i = 1; i < p1exons.Count; ++i)
            {
                if (numP < points.Count)
                {
                    if (i == points[numP])
                    {
                        numP++;
                        parentChoose = !parentChoose;
                    }
                }
                if (!parentChoose)
                {
                    exons1.Add(p1exons[i]);
                    exons2.Add(p2exons[i]);
                }
                else
                {
                    exons1.Add(p2exons[i]);
                    exons2.Add(p1exons[i]);
                }
            }
            return new List<List<int>>() { exons1, exons2 };
        }
    }
}


