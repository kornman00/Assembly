﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blamite.Blam.Scripting
{
    public interface IGlobal
    {
        string Name { get; }
        short Type { get; }
        IExpression Value { get; }
    }
}
