using System;

namespace Demo
{
    public abstract class Demo
    {
        public abstract string Type { get; }
        public abstract string Title { get; }
        public void Run()
        {
            Console.WriteLine($"{Environment.NewLine}== {Type} Demo: {Title} =={Environment.NewLine}");
            DoDemo();
            Console.WriteLine();
        }
        protected abstract void DoDemo();

        protected void Write(string line) => Console.WriteLine(line);
        protected void Write(object obj) => this.Write(obj.ToString()!);
    }
}
