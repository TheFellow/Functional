using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo
{
    public class DemoHost
    {
        private int _count = 0;
        private Dictionary<int, Demo> Demos { get; } = new Dictionary<int, Demo>();

        public DemoHost AddDemo(Demo demo)
        {
            Demos[++_count] = demo;
            return this;
        }

        public bool ShowMenu()
        {
            Console.WriteLine("== Menu ==");

            foreach (var kvp in Demos)
                Console.WriteLine($"{kvp.Value.Type} {kvp.Key,2}: {kvp.Value.Title}");

            Console.Write("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.ToLower() == "a")
            {
                foreach (var key in Demos.Keys)
                    DoDemo(key.ToString());
            }
            else
            {
                DoDemo(input);
            }

            return true;
        }

        private void DoDemo(string input)
        {
            if (int.TryParse(input, out int demoNumber) && Demos.ContainsKey(demoNumber))
            {
                Demos[demoNumber].Run();
            }
            else
            {
                Console.WriteLine($"Invalid selection ({input})");
            }
        }
    }
}
