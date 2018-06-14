using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Business.Interfaces
{
    public interface IGameBusiness
    {
        GameResult Play(GameMove move);
    }
}