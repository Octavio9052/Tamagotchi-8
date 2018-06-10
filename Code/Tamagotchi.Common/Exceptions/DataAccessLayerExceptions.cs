using System;

namespace Tamagotchi.Common.Exceptions
{
    public class DataAccessLayerExceptions : Exception
    {
        public DataAccessLayerExceptions()
        {

        }

        public DataAccessLayerExceptions(Exception innerException) : base("An error has occurred", innerException)
        {

        }

        public DataAccessLayerExceptions(string name, Exception e) : base(name, e)
        {

        }
    }
}
