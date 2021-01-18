using System.Collections.Generic;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {
        public string PizzaType {get; set;}
        public PizzaCrust PizzaCrust {get; set;}
        public PizzaSize PizzaSize {get; set;}
        public List<PizzaTopping> PizzaToppings {get; set;}
        public decimal Price {get; set;}

        protected APizzaModel()
        {
            PizzaToppings = new List<PizzaTopping>();
            AddPizzaType();
            AddCrust();
            AddSize();
            AddToppings();
            CalculatePrice();
        }
        protected virtual void AddPizzaType() {}
        protected virtual void AddCrust() {}
        protected virtual void AddSize() {}
        protected virtual void AddToppings() {}
        protected virtual void CalculatePrice() {}
    }
}
