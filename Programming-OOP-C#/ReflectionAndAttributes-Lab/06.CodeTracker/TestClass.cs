using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [Author("Viktor")]
    class TestClass
    {
        [Author("Gogicha")]
        [Obsolete]
        public void GofiMethod() 
        { 

        }

        [Author("Dimitrichko")]
        public void AlotOfWork() 
        { 
        }
    }
}
