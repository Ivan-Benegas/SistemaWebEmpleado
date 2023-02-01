using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class FechaDeNacimientoAño2000EnAdelante : ValidationAttribute
    {

        public FechaDeNacimientoAño2000EnAdelante()
        {
            ErrorMessage = "El año debe ser mayor a 2000";
        }

        public override bool IsValid(object value)
        {
            DateTime fecha = Convert.ToDateTime(value);

            if (fecha.Year <= 2000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
