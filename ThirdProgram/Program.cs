﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProgram
{
    public class ThirdProgram
    {
        int[] caloriesArray, pro, car, fa, minIndexArray, maxIndexArray;
        int mincount = 0, maxcount=0;
        string indexArr = null;

        public int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            pro = protein;
            car = carbs;
            fa = fat;

            caloriesArray = new int[protein.Length];

            for(int i=0; i< caloriesArray.Length; i++)
            {
                caloriesArray[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            }



            UniqueMinCalorieSize();

            

            //Console.WriteLine("min count is " + mincount);
            //Console.WriteLine("min count is " + maxcount);



            /*for(int i=0; i<caloriesArray.Length; i++)
            {
                Console.WriteLine(caloriesArray[i]);
            }*/

            int size = dietPlans.Length;
            int[] result = new int[size];


           for(int i=0; i< dietPlans.Length; i++)
            {
                int stringlength = dietPlans[i].Length;
                //Console.WriteLine("String Length" + stringlength);
                if(stringlength == 1)
                {
                    char c = char.Parse(dietPlans[i]);

                    result[i] = findIndex(c, protein, carbs, fat);
                    //Console.WriteLine("the result index is " + result[i]);
                }
                else
                {
                    //Console.WriteLine("Two Strings");
                    char[] ch = dietPlans[i].ToCharArray();

                    for(int j=0; j< ch.Length; j++)
                    {
                       if(ch[j].Equals('t'))
                        {
                            

                            if(mincount == 1)
                            {
                                result[i] = findIndex(ch[j], protein, carbs, fat);
                                break;
                                //Console.WriteLine("min count is 0 " + mincount);
                            }
                            else
                            {

                               

                                if (ch[j+1] .Equals('F'))
                                {
                                 
                                 result[i] = findIndexArray(indexArr, fat, ch[j + 1]);
                                        break;
                                }
                                else if(ch[j+1].Equals('f'))
                                {
                                    result[i] = findIndexArray(indexArr, fat, ch[j + 1]);
                                    break;
                                }
                                else if(ch[j + 1].Equals('P'))
                                {
                                    result[i] = findIndexArray(indexArr, protein, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('p'))
                                {
                                    result[i] = findIndexArray(indexArr, protein, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('C'))
                                {
                                    result[i] = findIndexArray(indexArr, carbs, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('c'))
                                {
                                    result[i] = findIndexArray(indexArr, carbs, ch[j + 1]);
                                    break;
                                }





                                //continue;
                            }

                            break;
                        }
                       else if(ch[j].Equals('T'))
                        {
                            if (maxcount == 1)
                            {
                                result[i] = findIndex(ch[j], protein, carbs, fat);
                                break;
                            }
                            else
                            {

                                if (ch[j + 1].Equals('F'))
                                {

                                    result[i] = findIndexArray(indexArr, fat, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('f'))
                                {
                                    result[i] = findIndexArray(indexArr, fat, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('P'))
                                {
                                    result[i] = findIndexArray(indexArr, protein, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('p'))
                                {
                                    result[i] = findIndexArray(indexArr, protein, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('C'))
                                {
                                    result[i] = findIndexArray(indexArr, carbs, ch[j + 1]);
                                    break;
                                }
                                else if (ch[j + 1].Equals('c'))
                                {
                                    result[i] = findIndexArray(indexArr, carbs, ch[j + 1]);
                                    break;
                                }
                                //continue;
                            }
                            break;
                        }
                       else
                        {
                            result[i] = findIndex(ch[j], protein, carbs, fat);
                            break;
                        }
                    }
                }
            }





            return result;
        }

        public int findIndex(char ch, int[] p, int[] c, int[] f)
        {
            int index=-1;
            

            switch(ch)
            {
                case 'P':
                    index = FindMaximumArray(p);
                   // Console.WriteLine("the index " + index);
                    break;
                case 'p':
                    index = FindMinimumArray(p);
                   // Console.WriteLine("the index" + index);
                    break;
                case 'C':
                    index = FindMaximumArray(c);
                    break;
                case 'c':
                    index = FindMinimumArray(c);
                    break;
                case 'F':
                    index = FindMaximumArray(f);
                    break;
                case 'f':
                    index = FindMinimumArray(f);
                    break;
                case 'T':
                    index = MaximumCalorie();
                    break;
                case 't':
                    index = MinimumCalorie();
                    break;
            }


            return index;
        }

        public int FindMaximumArray(int[] array)
        {
            int max = array[0];
            int maxIndex = 0;

            for(int i=0; i<array.Length; i++)
            {
                if(max<array[i])
                {
                    max = array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int FindMinimumArray(int[] array)
        {
            int MinIndex = 0;
            int min = array[0];

            for(int i=0; i<array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                    MinIndex = i;
                }
            }
            return MinIndex;
        }

        public int MaximumCalorie()
        {
            int mca = caloriesArray[0], i;

            int mc = 0;
            for (i = 0; i < caloriesArray.Length; i++)
            {

                if (mca <= caloriesArray[i])
                {
                    mca = caloriesArray[i];
                    mc = i;
                }
            }

            return mc;
        }

        public int MinimumCalorie()
        {
            int mca = caloriesArray[0], i;
            

            int mc = 0;
            for (i = 0; i < caloriesArray.Length; i++)
            {
                if (mca >= caloriesArray[i])
                {
                    mca = caloriesArray[i];
                    mc = i;
                }
            }

            return mc;
        }

        public void UniqueMinCalorieSize()
        {
            int min, max;

            

            min = caloriesArray[MinimumCalorie()];
            for (int i = 0; i < caloriesArray.Length; i++)
            {

                if (min == caloriesArray[i])
                {
                    //maxIndexArray[mincount]= i;

                    mincount = mincount + 1;

                    indexArr = indexArr + i;
                    

                }


            }


            max = caloriesArray[MaximumCalorie()];

            
            for (int i = 0; i < caloriesArray.Length; i++)
            {

                if (max == caloriesArray[i])
                {
                    //maxIndexArray[maxcount] = i;

                    maxcount = maxcount + 1;

                }


            }

          
        }

        public int findIndexArray(string cr, int[] arr, char l)
        {

            char[] ch = cr.ToCharArray();
            int res = -1;

            int[] Arrint = Array.ConvertAll(ch, c => (int)Char.GetNumericValue(c));

           for(int i=0; i<Arrint.Length-1; i++)
            {
                if (l.Equals('F') || l.Equals('C') || l.Equals('P'))
                {
                    if (arr[Arrint[i]] > arr[Arrint[i+1]])
                    {
                        res = Arrint[i];
                    }
                    else if(arr[Arrint[i]] == arr[Arrint[i + 1]])
                    {
                        res = Arrint[i+1];
                    }

                }
                else if (l.Equals('f') || l.Equals('c') || l.Equals('p'))
                {
                    if (arr[Arrint[i]] > arr[Arrint[i+1]])
                    {
                        res = Arrint[i+1];
                    }
                    else if (arr[Arrint[i]] == arr[Arrint[i + 1]])
                    {
                        res = Arrint[i];
                    }
                }

            }

            //Console.WriteLine(Arrint[i]);

            return res;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the size of the array plan");
            int sizePlan = int.Parse(Console.ReadLine());

            int[] protien = new int[size];
            int[] carps = new int[size];
            int[] fats = new int[size];
            string[] dietPlans = new string[sizePlan];

            Console.WriteLine("Enter the protein");

            for(int i=0; i<protien.Length; i++)
            {
                protien[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the carps");

            for (int i = 0; i < carps.Length; i++)
            {
                carps[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the fats");

            for (int i = 0; i < fats.Length; i++)
            {
                fats[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the dietplan");

            for (int i = 0; i < dietPlans.Length; i++)
            {
                dietPlans[i] = Console.ReadLine();
            }

            ThirdProgram tp = new ThirdProgram();

            int[] output = new int[dietPlans.Length];
            output = tp.SelectMeals(protien, carps, fats, dietPlans);
           for (int i=0; i<output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
