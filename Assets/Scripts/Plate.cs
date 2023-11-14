using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] SpriteRenderer[] pickupSprite;
         
        Item[] pickupItem;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.gameObject.TryGetComponent<IPickupItems>(out var foodItem))
            //{
            //    int i = 0;
                
            //    foreach (var item in foodItem.manager.pickUpItems)
            //    {
            //        pickupItem[i] = new(item);
            //        i++;
            //    }

            //    foodItem.manager.HideShow_PickupedItemsFromHands(false);
            //    foodItem.manager.ClearPlayerHands();

            //    for (int j = 0; j < pickupItem.Length; j++)
            //    {
            //        pickupSprite[j].sprite = pickupItem[i].sprite;
            //    }
            //}
        }
    }
}
