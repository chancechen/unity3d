using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class PropertyExample
    {

        private string name = "N/A";
        private int age = 0;


        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name= {0},Age={1}", name, age);
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }

        private static PropertyExample instance;

        public static PropertyExample  GetInstance()
        {
            if (instance == null)
            {
                instance = new PropertyExample();
            }
            return instance;
        }
    }
}
