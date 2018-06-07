using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Common.Exceptions
{
    public class BusinessLayerExceptions : Exception
    {
        public BusinessLayerExceptions()
        {

        }

        public BusinessLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public BusinessLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public BusinessLayerExceptions(string name) : base(name)
        {

        }
    }
}
