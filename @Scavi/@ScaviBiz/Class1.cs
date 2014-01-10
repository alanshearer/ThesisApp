using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ScaviBiz
{
    class Class1
    {
        public static void Main(String[] args)
        {
            PointOfInterestBiz biz = new PointOfInterestBiz();

            String georss = biz.GetPointsOfInterest();
            biz.SetFeedback(1, 2, "disdios");
            Console.ReadKey();
        }
    }
}
