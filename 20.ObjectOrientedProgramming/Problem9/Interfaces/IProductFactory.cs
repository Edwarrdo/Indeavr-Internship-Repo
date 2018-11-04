namespace Problem9.Interfaces
{
    public interface IProductFactory
    {
        IFirst GetFirst();
        ILeast GetLeast();
    }
}
