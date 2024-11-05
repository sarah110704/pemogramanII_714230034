using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_714230034
{
    public class DVD_714230034 : Product_714230034
    {
        protected string duration;

        public DVD_714230034(string title, string duration)
        {
            MyType = "DVD";
            MyTitle = title;
            this.duration = duration;
            Console.WriteLine("ini dari class DVD");
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("product is a {0} called \"{ 1}\" and has {2} minutes duration", MyType, MyTitle, Duration);
        }
    }
}
    
