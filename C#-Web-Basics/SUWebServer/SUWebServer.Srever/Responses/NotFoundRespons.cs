using SUWebServer.Srever.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUWebServer.Srever.Responses
{
    class NotFoundRespons : Response
    {
        public NotFoundRespons()
            : base(StatusCode.NotFound)
        {
        }
    }
}
