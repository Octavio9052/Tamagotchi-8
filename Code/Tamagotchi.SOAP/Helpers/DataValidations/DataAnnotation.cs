using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tamagotchi.Common.Models;

namespace Tamagotchi.SOAP.Helpers.DataValidations
{
    public class DataAnnotation
    {
        public static EntityValidationResult ValidateEntity<T>(T entity) where T : BaseModel
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }
}a