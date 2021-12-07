namespace Domain.Interfaces
{
    public interface ITerable<T> where T : class
    {
        ITerator<T> Iterator();
    }
}
