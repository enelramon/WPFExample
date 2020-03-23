using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace WpfExample.Validaciones
{
    public class TelefonoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Teléfono");

                cadena = cadena.Replace("-","");

                foreach (var caracter in cadena)
                {
                    if (!char.IsDigit(caracter))
                        return new ValidationResult(false, "El teléfono solo puede tener numeros");
                }

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un teléfono");
        }
    }
}
