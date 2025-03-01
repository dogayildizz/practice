using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        { }
        public override void SesCikar()
        {
            Console.WriteLine("The cat is meowing.");
        }

        public void Tirmala()
        {
            Console.WriteLine("The cat is scratching.");
        }
    }
}
