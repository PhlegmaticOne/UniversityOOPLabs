﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidation.Lab5
{
    public interface IClonable<T>
    {
        T Clone();
    }
}
