using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.mvcFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string tamplateCode, object viewModel);
    }
}
