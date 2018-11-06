using Problem9.Interfaces;
using System;

namespace Problem9.Models
{
    public class ProductTypeChecker
    {
        IProductFactory factory;
        MANUFACTURERS manu;

        public ProductTypeChecker(MANUFACTURERS m)
        {
            manu = m;
        }

        public void CheckProducts()
        {
            switch (manu)
            {
                case MANUFACTURERS.ManufacturerOne:
                    factory = new ManufacturerOneFactory();
                    break;
                case MANUFACTURERS.ManufacturerTwo:
                    factory = new ManufacturerTwoFactory();
                    break;
                case MANUFACTURERS.ManufacturerThree:
                    factory = new ManufacturerThreeFactory();
                    break;
            }


            Console.WriteLine(manu.ToString() + ":\nFirst Product: " +
                              factory.GetFirst().Name() + "\nLeast Product: " +
                              factory.GetLeast().Name()
                              );
        }

    }
}
