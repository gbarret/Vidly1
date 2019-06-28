using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.RepositoryGbs
{
    class Calculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }
        
    }
}