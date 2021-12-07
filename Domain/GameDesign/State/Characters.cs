namespace Domain.GameDesign.State
{
    public class Characters : Interfaces.IElements
    {
        public List<MobileElement> Elements { get; set; }

        public Characters(List<MobileElement> elements)
        {
            Elements = elements;
        }

        public void Add(MobileElement element)
        {
            Elements.Add(element);
        }

        public MobileElement GetElement(int index)
        {
            return Elements[index];
        }

        public void Remove(int index)
        {
            Elements.RemoveAt(index);
        }

        public int Size()
        {
            return Elements.Count;
        }

        public List<MobileElement> GetElements(int x, int y)
        {
            List<MobileElement> list = new List<MobileElement>();
            foreach (MobileElement element in Elements)
            {
                if (element.X == x && element.Y == y)
                {
                    list.Add(element);
                }
            }
            return list;
        }
    }
}
