namespace Domain.GameDesign.State
{
    public abstract class StaticElement : Interfaces.IElement
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
