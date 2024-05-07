using Genetic;
// See https://aka.ms/new-console-template for more information
Console.Write("Введите количество городов: ");
int pointsAmount = Convert.ToInt32(Console.ReadLine()); 
Console.Write("Введите количество особей: ");
int individAmount = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество итераций: ");
int iterationAmount = Convert.ToInt32(Console.ReadLine());
EvolutionManager manager = new EvolutionManager();
manager.InitPipolation(individAmount, pointsAmount);
for (int i = 0; i < iterationAmount; i++)
{
    Console.Write("Длина пути: " + manager.GetNewGeneration());
    Console.Write(". Лучший путь: ");
    foreach (int city in manager.shortPath)
    {
        Console.Write(city + " ");
    }
    Console.WriteLine("его длина: " + manager.shortest);
}