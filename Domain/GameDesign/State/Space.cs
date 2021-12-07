namespace Domain.GameDesign.State
{
    public class Space : StaticElement
    {
        public SpaceTypeId SpaceTypeId { get; set; }

        public Space(SpaceTypeId spaceTypeId)
        {
            SpaceTypeId = spaceTypeId;
        }
    }
}
