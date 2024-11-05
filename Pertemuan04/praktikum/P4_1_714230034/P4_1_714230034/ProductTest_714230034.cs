using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_714230034
{
    class ProductTest_714230034
    {
        static void Main(string[] args)
        {
            Book_714230034 product1 = new Book_714230034("Book", "c#object oriented solution", "300");
            DVD_714230034 product2 = new DVD_714230034("Erthenal Sunshine of Th Spotless Mind", "145");

            product1.DisplayInfo();
            product2.DisplayInfo(); 

        }
    }
}
