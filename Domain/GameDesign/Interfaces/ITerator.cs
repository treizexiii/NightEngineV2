namespace Domain.Interfaces
{
    public interface ITerator<T> where T : class
    {
        bool HasNext();
        T Next();
        void Remove();
    }
}
