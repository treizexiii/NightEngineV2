namespace Domain.GameDesign.State
{
    public class Wall : StaticElement
    {
        public WallTypeId WallTypeId { get; set; }

        public Wall(WallTypeId wallTypeId)
        {
            WallTypeId = wallTypeId;
        }
    }
}
