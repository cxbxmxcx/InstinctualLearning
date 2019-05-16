using GeneticSharp.Domain;
using GeneticSharp.Domain.Populations;
using System;

namespace InstinctualLearning.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var selectedSampleName = "EvolutionLearningSample";

            var sampleController = new EvolutionaryLearningSample<GridWorldEnvironment>();

            // var sampleController = TypeHelper.CreateInstanceByName<ISampleController>(selectedSampleName);
            DrawSampleName(selectedSampleName);
            sampleController.Initialize();

            System.Console.WriteLine("Starting...");

            var selection = sampleController.CreateSelection();
            var crossover = sampleController.CreateCrossover();
            var mutation = sampleController.CreateMutation();
            var fitness = sampleController.CreateFitness();
            var population = new Population(100, 200, sampleController.CreateChromosome());
            population.GenerationStrategy = new PerformanceGenerationStrategy();

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = sampleController.CreateTermination();

            var terminationName = ga.Termination.GetType().Name;

            ga.GenerationRan += delegate
            {
                DrawSampleName(selectedSampleName);

                var bestChromosome = ga.Population.BestChromosome;
               System.Console.WriteLine("Termination: {0}", terminationName);
               System.Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
               System.Console.WriteLine("Fitness: {0,10}", bestChromosome.Fitness);
               System.Console.WriteLine("Time: {0}", ga.TimeEvolving);
               System.Console.WriteLine("Speed (gen/sec): {0:0.0000}", ga.Population.GenerationsNumber / ga.TimeEvolving.TotalSeconds);
                sampleController.Draw(bestChromosome);
            };

            try
            {
                sampleController.ConfigGA(ga);
                ga.Start();
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor =System.ConsoleColor.DarkRed;
               System.Console.WriteLine();
               System.Console.WriteLine("Error: {0}", ex.Message);
               System.Console.ResetColor();
               System.Console.ReadKey();
                return;
            }

           System.Console.ForegroundColor =System.ConsoleColor.DarkGreen;
           System.Console.WriteLine();
           System.Console.WriteLine("Evolved.");
           System.Console.ResetColor();
           System.Console.ReadKey();

        }

        private static void DrawSampleName(string selectedSampleName)
        {
           System.Console.Clear();

           System.Console.ForegroundColor =System.ConsoleColor.DarkGreen;
           System.Console.WriteLine("GeneticSharp -System.ConsoleApp");
           System.Console.WriteLine();
           System.Console.WriteLine(selectedSampleName);
           System.Console.ResetColor();
        }
    }
    
}
