using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPi
{
    class Program
    {
         

        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(GetPiDigit(i));
            }


            Console.ReadKey();

        }


        private static double GetPiDigit(int n)
        {
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };


            // Based on the algorithm linked from http://bellard.org/pi/
            // for computing the nth digit of Pi in any base.

            // n === digit number to calculate
            // B === the base to use (10 in our case)
            // nu(x,y), where x is prime === multiplicity of x in y 
            //          (number of times x appears when y is broken down into prime factors)

            // 1. Let N = floor((n + eps) log2(B)) where eps is a small integer to ensure we have the
            //    precision needed; Let sum = 0.
            int eps = 20;
                    // B = 10 in our case, so log2(B) = log2(10)
                    // log2(10) = log10(10) / log10(2) = 1 / log10(2)
                    // We're working with positive numbers here, so casting to int
                    // automatically rounds down, acting as a floor function.
            int N = (int) ((n + eps) / Math.Log10(2));
            double sum = 0.0;

            // 2. For each prime number a with 2 < a < 2N, do:
            foreach (int a in primes)
            {
                // The algorithm description gives 2 < a < 2N, but the
                // example C implementation has 2 < a <= 2N
                if (a <= 2) continue;
                if (a > 2 * N) break;

                //    A. Let numax = floor(log(2N) / log(a)) ; Let m = a ^ numax

                        // nuMax corresponds to vmax in the example C implementation
                        // m corresonds to av in the example C implementation

                int nuMax = (int)(Math.Log(2 * N) / Math.Log(a));
                int m = (int)Math.Pow(a, nuMax);

                //    B. Let alpha = 0 ; Let nu = 0 ; Let b = 1 ; Let A = 1.
                        // I think alpha should correspond to t in the example C implementation,
                        // but I'm not sure about everything it is doing
                int alpha = 0;
                int nu = 0;
                int b = 1;
                int A = 1;

                int num = 1;
                int den = 1;

                //    C. for k in 1..2N do:
                        // The algorithm description says for k in 1..2N, but the example
                        // C implementation has k <= N.
                for (int k = 1; k <= N; k++)
                {
                    //        i.  Let b = (k / a ^ (nu(a,k))) * b mod m; 
                    //            Let A = ((2*k - 1) / (a ^ nu(a, 2*k-1))) * A mod m; 
                    //            Let nu = nu - nu(a,k) + nu(a,2*k-1)
                    //        ii. if nu > 0 do: Let alpha = alpha + k * b * (A ^ -1) * (a ^ (numax - nu)) mod m

                            // I'm really not sure how some of this corresponds to
                            // the algorithm description. When I implemented it on
                            // my own, I got bad results, so this is basically copied
                            // from the example C implementation.

                    alpha = k;
                    if (b >= a)
                    {
                        do
                        {
                            alpha = alpha / a;
                            nu--;
                        } while (alpha % a == 0);
                        A = 0;
                    }
                    A++;
                    num = (num * alpha) % m;

                    alpha = 2 * k - 1;
                    if (A >= a)
                    {
                        if (A == a)
                        {
                            do
                            {
                                alpha /= a;
                                nu++;
                            } while (alpha % a == 0);
                        }
                        A -= a;
                    }
                    den = (den * alpha) % m;
                    A += 2;

                    if (nu > 0)
                    {

                    }

                    int nuOfAAndK = GetMultiplicity(a, k);
                    int nuOfAAnd2KMinus1 = GetMultiplicity(a, 2 * k - 1);
                    b = (k / Math.Pow(a, nuOfAAndK) * b) % m;
                    A = ((2 * k - 1) / Math.Pow(a, nuOfAAnd2KMinus1) * A) % m;
                    nu += nuOfAAnd2KMinus1 - nuOfAAndK; 

                    if (nu > 0)
                    {
                        alpha = (alpha + k * b / A * Math.Pow(a, nuMax - nu)) % m;
                    }

                }

                //    D. Let alpha = alpha * (B ^ (n - 1)) mod m; Let sum = sum + (alpha / m) mod 1
                alpha = (alpha * Math.Pow(10, n - 1)) % m;
                sum += (alpha / m) % 1;

            }
            //
            // 4. The nth digit of pi (with the 1's digit being d0, tenths digit being d1, etc.) is
            //    the first digit in sum AFTER the decimal.
            return sum;
            

        }

        private static int GetMultiplicity(int factor, int p)
        {
            int remainder = p;
            int result = 0;
            while (remainder % factor == 0)
            {
                result++;
                remainder /= factor;
            }

            return result;
        }

    }
}
