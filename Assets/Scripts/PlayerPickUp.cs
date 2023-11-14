using CookingMaster;
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
            if (collision.gameObject.TryGetComponent<Item>(out var foodItem))
            {
                Item item= new(foodItem);
                manager.ItemHasPickuped?.Invoke(this, item);   
            }
        }
    }
}

