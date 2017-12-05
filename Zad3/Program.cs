using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            foreach (string arg in args)
            {
                path += " " + arg;
            }
            StringBuilder stringBuilder = new StringBuilder();
            XDocument xDocument = XDocument.Load(path);

            var root = xDocument.Elements("sheet").ToList();
            var rows = root.Elements("row");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Console.WriteLine("Insert coordinates");
                var coordinates = Console.ReadLine();
                int[] coordinateArray = coordinates.Split(' ').Select(x => int.Parse(x)).ToArray();
                if (coordinateArray[0] == -1 && coordinateArray[1] == -1)
                {
                    break;
                }
                GetCells(coordinateArray, rows);
            }
        }

        static void GetCells(int[] coordinates, IEnumerable<XElement> Rows)
        {
            if (Rows.ToList().Count <= coordinates[0])
            {
                Console.WriteLine("Out of bounds, select new coordinates - Empty");
                return;
            }
            var Cells = Rows.ElementAt(coordinates[0]).Elements("cell");
            if (Cells.ToList().Count <= coordinates[1])
            {
                Console.WriteLine("Out of bounds, select new coordinates - Empty");
                return;
            }
            var cellValue = Cells.ElementAt(coordinates[1]).Value;
            Console.WriteLine(cellValue);
        }
    }
}
