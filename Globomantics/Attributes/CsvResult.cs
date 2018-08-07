using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Attributes
{
    public class CsvResult : IActionResult
    {
        private IEnumerable _data;
        private string _fileName;

        public CsvResult(IEnumerable data, string fileName)
        {
            _data = data;
            _fileName = fileName + "csv";
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var item in _data)
            {
                var properties = item.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(item, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            var result = new FileContentResult(Encoding.ASCII.GetBytes(stringWriter.ToString()), "text/csv") { FileDownloadName = _fileName };

            await result.ExecuteResultAsync(context);
        }

        public static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }
    }
}
