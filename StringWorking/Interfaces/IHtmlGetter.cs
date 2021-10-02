using System.Collections.Generic;
using System.Text;

namespace StringWorking
{
    public interface IHtmlGetter
    {
        IEnumerable<string> GetHtml();
    }
}