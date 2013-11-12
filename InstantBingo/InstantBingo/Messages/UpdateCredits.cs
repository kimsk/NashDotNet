namespace InstantBingo.Messages
{
    public class UpdateCredits
    {
        public UpdateCredits(int credits)
        {
            Credits = credits;
        }

        public int Credits { get; set; }
    }
}