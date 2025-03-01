using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public abstract class Animal
    {



		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _age;

        public Animal(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public int Age
		{
			get { return _age; }
			set { _age = value; }
		}

		public abstract void SesCikar();



	}
}
