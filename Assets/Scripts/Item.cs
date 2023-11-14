using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class Item : MonoBehaviour, IFoodItem
    {
        [field: SerializeField] public FoodItemName ItemFood { get ; private set; }
        [field: SerializeField] public float Weight { get; private set ; }
        [field: SerializeField] public float ChoopingSpeed { get ; private set ; }
        [field:SerializeField] public int Money { get; private set; }
        public bool IsChooped { get; set; }
        [field:SerializeField] public Sprite sprite { get;  set; }

        public IEnumerator StartProcess()
        {
            Debug.Log($"{ItemFood} is starting");
            yield return new WaitForSecondsRealtime(ChoopingSpeed);
            Debug.Log($"{ItemFood} is done");
        }

        public Item(Item a)
        {
            ItemFood = a.ItemFood;
            Weight = a.Weight;
            ChoopingSpeed = a.ChoopingSpeed;
            Money = a.Money;
            IsChooped = a.IsChooped;
            this.sprite = a.sprite;
        }

        public Item()
        {
            
        }
    }
}
