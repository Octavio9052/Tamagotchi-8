using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Core
{
    public interface IBaseGameRules
    {
        GameStatus Eat();
        GameStatus Sleep();
        GameStatus Play();
    }
}
