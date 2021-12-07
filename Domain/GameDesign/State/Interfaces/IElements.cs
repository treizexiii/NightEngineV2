namespace Domain.GameDesign.State.Interfaces
{
    public interface IElements
    {
        int Size();
        void Add(MobileElement element);
        MobileElement GetElement(int index);
        void Remove(int index);
    }
}
