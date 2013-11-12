namespace InstantBingo.Messages
{
    public class UpdateBallCallNumber
    {
        public UpdateBallCallNumber(int ballCallNumber)
        {
            BallCallNumber = ballCallNumber;
        }

        public int BallCallNumber { get; set; }
    }
}
