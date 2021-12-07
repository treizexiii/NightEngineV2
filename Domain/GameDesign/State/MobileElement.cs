namespace Domain.GameDesign.State
{
    public abstract class MobileElement : Interfaces.IElement
    {
        public int Speed { get; set; }
        public int Position { get; set; }
        public int StatusTime { get; set; }
        public Direction Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
