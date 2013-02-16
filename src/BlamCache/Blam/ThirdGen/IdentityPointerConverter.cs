﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtryzeDLL.IO;

namespace ExtryzeDLL.Blam.ThirdGen
{
    public class IdentityPointerConverter : IPointerConverter
    {
        public int PointerToOffset(uint pointer)
        {
            return (int)pointer;
        }

        public uint OffsetToPointer(int offset)
        {
            return (uint)offset;
        }
    }
}