using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
