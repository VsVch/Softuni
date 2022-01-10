using SUS.HTTP;
using System;

namespace SUS.mvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get;}
    }
}
