using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Layout
{
    public class XmlLayout : ILayout
    {
        public string Template
        {
            get 
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<Log>");
                sb.AppendLine("<data>{0}</data>");
                sb.AppendLine("<level>{1}</level>");
                sb.AppendLine("<message>{2}</message>");
                sb.AppendLine("<Log>");

                return sb.ToString().TrimEnd(); 
            }
        }
    }
}
