using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
   
    public interface IFoodItem 
    {
        public FoodItemName ItemFood { get;}
        public float Weight { get; }
        public float ChoopingSpeed { get; }
        public int Money { get; }
        public bool IsChooped { get; }

    }
}
