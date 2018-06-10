namespace Tamagotchi.Core
{
    public interface IBaseGameRules
    {
        GameStatus Eat();
        GameStatus Sleep();
        GameStatus Play();
    }
}
