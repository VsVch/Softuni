using System;
using System.Collections.Generic;
using System.Text;

namespace InternalModifierDemo
{
   internal class InternalClass
    {
        public int PublicProperty { get; set; }

        internal int InternalProperty { get; set; }

        private int PrivateProperty { get; set; }
    }
}
