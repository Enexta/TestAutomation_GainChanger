using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    public class test
    {
        public void newtest()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Console.WriteLine(dir);
        }
            
    }
}
