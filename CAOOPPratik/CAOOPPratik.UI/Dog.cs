using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age)
        { }
        public override void SesCikar()
        {
            Console.WriteLine("The dog is barking.");
        }

    }
}
