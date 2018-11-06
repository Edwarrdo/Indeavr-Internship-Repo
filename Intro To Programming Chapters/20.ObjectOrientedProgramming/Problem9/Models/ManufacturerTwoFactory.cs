using Problem9.Interfaces;

namespace Problem9.Models
{
    public class ManufacturerTwoFactory : IProductFactory
    {
        public IFirst GetFirst()
        {
            return new ProductOne();
        }

        public ILeast GetLeast()
        {
            return new ProductTwo();
        }
    }
}
