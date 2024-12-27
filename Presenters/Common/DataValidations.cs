using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoViaje.Presenters.Common
{
    public static class DataValidations
    {

        public static string ValidationModel(object model) 
        {
            string msg = "";
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool validate=Validator.TryValidateObject(model, context, results, true);
            if (!validate) 
            {
                foreach (var res in results)
                    msg += $"*{res.ErrorMessage}\n";
            }
            return msg;
        }


    }
}
