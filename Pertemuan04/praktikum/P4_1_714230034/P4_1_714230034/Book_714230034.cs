using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_714230034
{
    public class Book_714230034 : Product_714230034
    {
        protected string pageCount;
        public Book_714230034(string type, string title, string pageCount) : base(type, title) 
        {
            this.pageCount = pageCount;
        }

        public string Pagecount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Product is a {0} called \"{1}\" and has {2} pages", MyType, MyTitle, Pagecount);
        }
    }
   
    }

