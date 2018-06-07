using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Common.Exceptions
{
    public class ServiceSOAPLayerExceptions : Exception
    {
        public ServiceSOAPLayerExceptions()
        {

        }

        public ServiceSOAPLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public ServiceSOAPLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public ServiceSOAPLayerExceptions(string name) : base(name)
        {

        }
    }
}