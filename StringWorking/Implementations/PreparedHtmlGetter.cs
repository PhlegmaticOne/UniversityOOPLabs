using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWorking
{
    public class PreparedHtmlGetter : IHtmlGetter
    {
        private readonly IEnumerable<string> _html = new List<string>()
        {
            "<!DOCTYPE HTML>",
                "<html>",
                    "<head>",
                        "<meta charset=\"utf-8\">",
                        "<title>Тег FORM</title>",
                    "</head>",
                "<body>",
                    "<h1 style=\"text-align:center\">Заголовок</h1>",
                    "<form action=\"handler.php\">",
                         "<p><b>Как по вашему мнению расшифровывается аббревиатура &quot; ОС&quot;?</b></p>",
                         "<p><input type = \"radio\" name=\"answer\" value=\"a1\">Офицерский состав<Br>",
                         "<input type = \"radio\" name= \"answer\" value= \"a2\" > Операционная система<Br>",
                         "<input type = \"radio\" name= \"answer\" value= \"a3\" > Большой полосатый мух</p>",
                         "<p><input type = \"submit\" ></ p >",
                     "</form >",
                "</body >",
            "</html >",
        };

        public IEnumerable<string> GetHtml() => _html;
    }
}
