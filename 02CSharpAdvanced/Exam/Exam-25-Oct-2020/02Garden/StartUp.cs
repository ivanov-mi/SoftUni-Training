using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class StartUp
    {
        static void Main()
        {
            var gardenDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var garden = new int[gardenDimensions[0], gardenDimensions[1]];
            var flowers = new List<Flower>();

            var inputCommands = string.Empty;

            while ((inputCommands = Console.ReadLine())?.ToLower() != "bloom bloom plow")
            {
                var flowerCoordinates = inputCommands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var flowerRow = flowerCoordinates[0];
                var flowerCol = flowerCoordinates[1];

                if (flowerRow >= garden.GetLength(0) || flowerCol >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                else
                {
                    var newFlower = new Flower(flowerRow, flowerCol);
                    flowers.Add(newFlower);
                }
            }

            BloomFlowers(garden, flowers);

            PrintGarden(garden);
        }

        private static void BloomFlowers(int[,] garden, List<Flower> flowers)
        {
            for (int i = 0; i < flowers.Count; i++)
            {
                var bloomingFlower = flowers[i];

                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[bloomingFlower.Row, j]++;
                }

                for (int j = 0; j < garden.GetLength(0); j++)
                {
                    garden[j, bloomingFlower.Col]++;
                }

                garden[bloomingFlower.Row, bloomingFlower.Col]--;
            }
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Flower
    {
        public Flower(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public int Row { get; private set; }
        public int Col { get; private set; }
    }
    }
