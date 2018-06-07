using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Common.Exceptions
{
    public class ServiceRESTLayerExceptions : Exception
    {
        public ServiceRESTLayerExceptions()
        {

        }

        public ServiceRESTLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public ServiceRESTLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public ServiceRESTLayerExceptions(string name) : base(name)
        {

        }
    }
}