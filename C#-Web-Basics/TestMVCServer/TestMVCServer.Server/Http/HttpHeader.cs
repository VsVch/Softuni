using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCServer.Server.Http
{
    public class HttpHeader
    {
        //public HttpHeader(string name, string value)
        //{
        //    this.Name = name;
        //    this.Value = value;
        //}

        public string Name { get; init; }

        public string Value { get; init; }
    }
}
