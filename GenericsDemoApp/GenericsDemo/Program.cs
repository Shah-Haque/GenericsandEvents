using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenericsDemo.Program;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //38:35
            //This is a list
            //List<string> stringlist = new List<string>();
            //List<int> intlist = new List<int>();

            //intlist.Add(1);

            //string result = FizzBuzz("tests");

            //Console.WriteLine($"Tests: {result}");

            //result = FizzBuzz(123);

            //Console.WriteLine($"123: {result}");

            //result = FizzBuzz(true);

            //Console.WriteLine($"true: {result}");

            //result = FizzBuzz(new PersonModel { FirstName = "Shah", LastName ="Haque"});

            //Console.WriteLine($"PersonModel: {result}");

            GenericHelper<PersonModel> peoplehelper = new GenericHelper<PersonModel>();

            peoplehelper.CheckItemAdd(new PersonModel { FirstName= "Shah", HasError = true });

            foreach (var item in peoplehelper.RejectedItems)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} was rejected ");
            }
 
            Console.ReadLine();
        }


        public class GenericHelper <T> where T : IErrorCheck
        {
            public List<T> Items { get; set; } = new List<T>();
            public List<T> RejectedItems { get; set; } = new List<T>();


            public void CheckItemAdd(T item) 
            {
                if (item.HasError == false)
                {
                    Items.Add(item);
                }
                else
                {
                    RejectedItems.Add(item); 
                }
               

            }

        }

        public interface IErrorCheck
        {
            bool HasError { get; set; }
        }





        //makes use of generic type of name T 
        private static string FizzBuzz<T>(T Item)
        {
            int itemLength = Item.ToString().Length;
            string output = "";
            if (itemLength % 3 == 0)
            {
                output += "Fizz";
            }

            if (itemLength % 5 == 0)
            {
                output += "Buzz";
            }

            return output;

        }

    }

    public class CarModel : IErrorCheck
    {
        public string Manufacturer { get; set; }

        public int YearManufactured { get; set; }

        public bool HasError { get; set; }
    }






    public class PersonModel :IErrorCheck
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool HasError { get; set; }
    }


}
