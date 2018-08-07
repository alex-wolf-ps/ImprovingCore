using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.ActionResults
{
    public class CsvResult : IActionResult
    {
        private IEnumerable sourceData;
        private string name;

        public CsvResult(IEnumerable data, string fileName)
        {
            this.sourceData = data;
            this.name = fileName;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var builder = new StringBuilder();
            var writer = new StringWriter(builder);

            foreach (var rate in sourceData)
            {
                var properties = rate.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    writer.Write(FindPropertyValue(rate, prop.Name));
                    writer.Write(", ");
                }
                writer.WriteLine();
            }

            var csvBytes = Encoding.ASCII.GetBytes(writer.ToString());

            context.HttpContext.Response.Headers["content-disposition"]
            = "attachment; filename=" + name + ".csv";
            return context.HttpContext.Response.Body.WriteAsync(csvBytes, 0, csvBytes.Length);
        }

        private string FindPropertyValue(object item, string prop)
        {
            return item.GetType().GetProperty(prop).GetValue(item, null).ToString() ?? "";
        }
    }
}
