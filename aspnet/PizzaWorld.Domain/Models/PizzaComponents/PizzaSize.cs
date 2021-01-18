using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaSize : AEntity
    {
        public string Size {get; set;}

        public PizzaSize(){}
        public PizzaSize(string size)
        {
            Size = size;
        }
        public void SelectSize()
        {
            Console.WriteLine("Select Size");
            Console.WriteLine(""
            + "1. Small\n"
            + "2. Medium\n"
            + "3. Large\n"
            + "4. Extra Large");
            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Size = "Small";
                    break;
                case 2:
                    Size = "Medium";
                    break;
                case 3:
                    Size = "Large";
                    break;
                case 4:
                    Size = "Extra Large";
                    break;
                default:
                    Console.WriteLine($"Unknown input auto selected: Medium");
                    Size = "Medium";
                    break;
            }
        }
    }
}
