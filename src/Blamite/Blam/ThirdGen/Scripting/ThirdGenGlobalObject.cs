﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blamite.Blam.Scripting;
using Blamite.Flexibility;

namespace Blamite.Blam.ThirdGen.Scripting
{
    public class ThirdGenGlobalObject : IGlobalObject
    {
        public ThirdGenGlobalObject(StructureValueCollection values, StringIDSource stringIDs)
        {
            Name = values.HasInteger("name index") ? stringIDs.GetString(new StringID(values.GetInteger("name index"))) : values.GetString("name");
            Class = (short)values.GetInteger("type");
            PlacementIndex = (short)values.GetInteger("placement index");
        }

        public string Name { get; private set; }
        public short Class { get; private set; }
        public short PlacementIndex { get; private set; }
    }
}
