using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_1_714230034
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Console.Write("Masukan Angka Pertama : ");
            double input = Convert.ToDouble(Console.ReadLine());

            Console.Write("Masukan Angka Kedua : ");
            double input2 = Convert.ToDouble(Console.ReadLine());

            double hasil = input + input2;
            double hasil2 = input - input2;
            double hasil3 = input * input2;
            double hasil4 = input / input2;
            Console.WriteLine("{0} + {1} = {2} ", input, input2, hasil);
            Console.WriteLine("{0} - {1} = {2} ", input, input2, hasil2);
            Console.WriteLine("{0} * {1} = {2} ", input, input2, hasil3);
            Console.WriteLine("{0} / {1} = {2} ", input, input2, hasil4);





        }
    }
}
