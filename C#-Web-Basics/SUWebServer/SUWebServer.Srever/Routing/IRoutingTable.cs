using SUWebServer.Srever.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUWebServer.Srever
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Response response);

        IRoutingTable MapGet(string url, Response responsec);

        IRoutingTable MapPost(string url, Response response);
    }
}
