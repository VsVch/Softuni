using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCServer.Server.Identity
{
    public class UserIdentity
    {
        public string Id { get; set; }
              
        public bool IsAuthenticated => this.Id != null ;    
    }
}
