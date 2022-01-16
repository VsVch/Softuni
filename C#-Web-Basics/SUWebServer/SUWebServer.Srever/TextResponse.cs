using SUWebServer.Srever.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUWebServer.Srever
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> PreRenderAction = null)
            : base(text, ContentType.PlainText, PreRenderAction)
        {
        }
    }
}
