﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }
    }
}
