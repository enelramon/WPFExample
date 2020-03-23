using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace WpfExample.Validaciones
{
    public class CostoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                decimal precio = 0;
                try
                {
                    precio = Convert.ToDecimal(value);
                }
                catch
                {
                    return new ValidationResult(false, "El costo debe ser un numero");
                }

                if (precio >= 1)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El costo debe mayor o igual a uno");

            }
            return new ValidationResult(false, "Debes poner un costo");
        }
    }
}
