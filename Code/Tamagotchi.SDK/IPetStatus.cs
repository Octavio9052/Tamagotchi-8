namespace Tamagotchi.SDK
{
    public interface IPetStatus
    {
        int PlayPoints { get; set; }
        int EatPoints { get; set; }
        int SleepPoints { get; set; }
        int IdlePoints { get; set; }
    }
}