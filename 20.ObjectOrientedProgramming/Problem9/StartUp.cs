using Problem9.Models;
using System;

namespace Problem9
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Implementation of AbstractFactory pattern!\n");
            ProductTypeChecker checker = new ProductTypeChecker(MANUFACTURERS.ManufacturerOne);
            checker.CheckProducts();

            checker = new ProductTypeChecker(MANUFACTURERS.ManufacturerTwo);
            checker.CheckProducts();

            checker = new ProductTypeChecker(MANUFACTURERS.ManufacturerThree);
            checker.CheckProducts();
        }
    }

    public enum MANUFACTURERS
    {
        ManufacturerOne,
        ManufacturerTwo,
        ManufacturerThree
    }
}
