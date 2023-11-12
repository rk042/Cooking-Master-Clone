using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IFoodItem>(out var foodItem))
            {
                Debug.Log(foodItem.ItemFood);
            }
        }
    }
}
