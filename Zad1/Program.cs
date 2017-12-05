using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad1
{
    class Program
    {
        public static int MaxDepth { get; set; }
        public static int CurrentDepth { get; set; }

        static void Main(string[] args)
        {
            Dictionary<int, string> TreeDict = new Dictionary<int, string>();
            for (int i = 0; i < args.Length; i++)
            {
                TreeDict.Add(i, args[i]);
            }
            var TreeValues = TreeDict.Select(x => int.Parse(x.Value));
            var LeafNodes = TreeDict.Keys.Where(key => !(TreeValues.Contains(key)));
            GetMaxDepth(TreeDict);
            Console.WriteLine("Max Tree depth is: " + MaxDepth);
            Console.WriteLine("Number of leaves in the tree is :" + LeafNodes.Count());
        }

        public static void GetMaxDepth(Dictionary<int, string> TreeDict)
        {
            foreach (var i in TreeDict.Keys)
            {
                GetParent(i, TreeDict);
            }
        }

        public static void GetParent(int child, Dictionary<int, string> TreeDict)
        {
            TreeDict.TryGetValue(child, out string parent);
            if (int.Parse(parent) > -1)
            {
                CurrentDepth++;
                GetParent(int.Parse(parent), TreeDict);
            }
            else
            {
                MaxDepth = MaxDepth < CurrentDepth ? CurrentDepth : MaxDepth;
                CurrentDepth = 0;
            }
        }

    }
}
