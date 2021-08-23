using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Layout
{
    public class JsonLayout : ILayout
    {
        public string Template 
        {
            get 
            {
                return
                    @"""Log"": {{ 
  ""data"": ""{0}"",
  ""level"": ""{1}"",
  ""message"": ""{2}""
                  }},";         
             
            }
        }
    }
}
