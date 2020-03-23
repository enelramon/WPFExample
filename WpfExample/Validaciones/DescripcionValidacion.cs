using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace WpfExample.Validaciones
{
    public class DescripcionValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {

                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner una descripción");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner una descripción");
        }
    }
}
