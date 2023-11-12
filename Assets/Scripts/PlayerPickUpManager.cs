using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerPickUpManager : MonoBehaviour, IPickupItems
    {
        [SerializeField] int itemsCountPlayerCanPickup = 2;

        public Queue<IFoodItem> pickUpItems { get; private set; } = new Queue<IFoodItem>();

        public EventHandler<IFoodItem> ItemHasPickuped;
        
        private void OnEnable()
        {
            ItemHasPickuped += OnItemHasPickuped;    
        }

        private void OnDisable()
        {
            ItemHasPickuped -= OnItemHasPickuped;    
        }

        private void OnItemHasPickuped(object sender, IFoodItem e)
        {
            if (pickUpItems.Count<itemsCountPlayerCanPickup)
            {
                Debug.Log($"item pickuped {e.ItemFood}");
                pickUpItems.Enqueue(e);
            }
            else
            {
                Debug.LogError($"Your are tring to pickup more then your pickup item count! \n your pickup count is {itemsCountPlayerCanPickup}");
            }

        }
    }
}
