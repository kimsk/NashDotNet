namespace InstantBingo.Messages
{
    public class PlaySound
    {
        public PlaySound(SoundType name, bool isPlay)
        {
            IsPlay = isPlay;
            Type = name;
        }

        public bool IsPlay { get; set; }
        public SoundType Type { get; set; }
    }

    public enum SoundType
    {
        WinningSound,
        ButtonSound,        
    }
}
