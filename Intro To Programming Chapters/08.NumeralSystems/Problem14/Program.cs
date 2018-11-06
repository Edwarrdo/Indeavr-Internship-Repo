using System;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            float sumF = 0f;
            double sumD = 0d;
            decimal sumM = 0m;
            for (int i = 0; i < 50000000; i++)
            {
                sumF += 0.000001f;
                sumD += 0.000001d;
                sumM += 0.000001m;
            }
            Console.WriteLine(sumF);
            Console.WriteLine(sumD);
            Console.WriteLine(sumM);

            //In most systems, a number like 0.0000001 cannot be accurately represented using binary. There will be some form of arithmetic precision error when using a number such as this. Generally, said arithmetic precision error is not noticeable when doing mathematical operations, but the more operations you perform, the more noticeable the error is. Thats why we notice it here, when we perform so many calculations.
            //double and float use base-2 math, while decimal uses base-10 math
            //what double and float are concerned with is performance, while what decimal is concerned with is precision. When using double, you are accepting a known trade-off: you won't be super precise in your calculations, but you will get an acceptable answer quickly. Whereas with decimal, precision is built into its type: it's meant to be used for money calculations
        }
    }
}
