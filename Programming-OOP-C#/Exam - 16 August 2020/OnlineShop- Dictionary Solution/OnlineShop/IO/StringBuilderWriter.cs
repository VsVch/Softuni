
using OnlineShop.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.IO
{
    public class StringBuilderWriter : IWriter
    {
        private StringBuilder sb;

        public StringBuilderWriter()
        {
            sb = new StringBuilder();
        }

        public void CustomWriteLine(string text)
        {
            this.sb.AppendLine(text);
        }

        public void CustomWrite(string text)
        {
            this.sb.Append(text);
        }

        public override string ToString()
        {
            return sb.ToString();
        }

    }
}