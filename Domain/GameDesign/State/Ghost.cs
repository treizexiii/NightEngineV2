namespace Domain.GameDesign.State
{
    public class Ghost : MobileElement
    {
        public int Color { get; set; }

        public GhostStatus Status { get; set; }
    }
}
