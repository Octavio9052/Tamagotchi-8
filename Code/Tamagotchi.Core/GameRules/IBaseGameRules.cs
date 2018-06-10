using Tamagotchi.Core.PlayStatus;

namespace Tamagotchi.Core.GameRules
{
    public interface IBaseGameRules
    {
        GameStatus Eat();
        GameStatus Sleep();
        GameStatus Play();
    }
}
