using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service.Exceptions
{
    public class ModelValidationException : Exception
    {
        public List<ModelValidationError> Errors { get; }
        public ModelValidationException(List<ModelValidationError> errors) : base("One or more properties have failed the validation.")
        {
            Errors = errors;
        }

        public ModelValidationException(ModelValidationError errors) : base("One or more properties have failed the validation.")
        {
            Errors = new List<ModelValidationError> { errors };
        }

        public void MapToModelState(ModelStateDictionary ModelState)
        {
            this.Errors.ForEach(x => ModelState.AddModelError(x.key, x.errorMessage));
        }

    }

    public class ModelValidationError
    {
        public string key { get; set; }
        public string errorMessage { get; set; }
    }
}
