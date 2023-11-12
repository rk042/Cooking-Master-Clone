using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerPickUp : MonoBehaviour
    {
        PlayerPickUpManager manager;

        private void Start()
        {
            manager = GetComponentInParent<PlayerPickUpManager>();      
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IFoodItem>(out var foodItem))
            {
               manager.ItemHasPickuped?.Invoke(this, foodItem);
            }
        }
    }
}
