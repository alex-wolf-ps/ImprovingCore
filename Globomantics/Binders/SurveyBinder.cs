using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Binders
{
    public class SurveyBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var questions = bindingContext.ValueProvider.GetValue("q");
            var submissions = new List<Submission>();

            foreach (var question in questions)
            {
                var answers = question.Split(",");
                submissions.Add(new Submission()
                {
                    Id = int.Parse(answers[0]),
                    Rating = int.Parse(answers[1]),
                    Comment = answers[2]
                });
            }

            bindingContext.Result = ModelBindingResult.Success(submissions);
            return Task.CompletedTask;
        }
    }
}
