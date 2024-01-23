namespace MyMathLibrary // BL - SRP
{
    public class MathLibrary // BL - SRP
    {
        public int FindMax(int a, int b) // BL -  SRP
        {
            int max;
            if (a > b)
                max = a;
            else
                max = b;

            return max;
        }
    }
}