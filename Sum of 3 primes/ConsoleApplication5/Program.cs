    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                int input;
                int hit = 0;
                int firstNum = 0;
                int secondNum = 0;
                int thirdNum = 0;
                bool secondFound = false;
                List<int> primesWZeros = new List<int>();
                List<int> primes = new List<int>();

                input = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i < input; i++)
                {
                     primesWZeros.Add(isPrime(i)); // calling the function to store all the primes into a list and the non primes as 0s
                }

                for (int i = 0; i < primesWZeros.Count(); i++)
                {
                    if (primesWZeros[i] != 0 && primesWZeros[i] != 1)
                    {
                        primes.Add(primesWZeros[i]); // removing the 0s and the 1 from the first list
                    }
                }

                for (int i = primes.Count - 1; i >= 0; i--) // finding all possible sums of 3 nummers
                {
                    secondFound = false;
                    firstNum = primes[i];
                    for (int k = i; k >= 0; k--)
                    {
                        if (firstNum + primes[k] < input && secondFound == false)
                        {
                            hit = k;
                            secondNum = primes[k];
                            secondFound = true;
                        }

                        if (firstNum + secondNum + primes[k] == input && secondFound == true)
                        {
                            thirdNum = primes[k];
                            Console.WriteLine("{0} + {1} + {2} = {3}", firstNum, secondNum, thirdNum, input);                       
                        }    

                        else if (k == 0)
                            {
                            secondFound = false;
                            secondNum = 0;
                            k = hit;                      
                        }
                    }
                }
                Console.ReadLine();
            }

            public static int isPrime(int x)   // function that returnes all the prime numbers smaller than the paramater and 0 for the non primes
            {
                int l = 0;
                for (int i = 1; i <= x; i++)
                {
                    if (x % i == 0)
                    {
                        l++;
                    }
                }
                if (l < 3)
                {
                    return x;
                }
                else { return 0; }                      
            }
        }
    }
