using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerDrop : MonoBehaviour,IPickupItems
    {
        PlayerPickUpManager manager;
        public Queue<IFoodItem> pickUpItems => manager.pickUpItems;

        private void Start()
        {
            manager = GetComponentInParent<PlayerPickUpManager>();
        }
    }
}
