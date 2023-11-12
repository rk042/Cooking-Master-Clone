using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CookingMaster
{
    public class Chopping : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickupItems items))
            {
                if (items.pickUpItems.Any())
                {
                    foreach (var item in items.pickUpItems)
                    {
                        Debug.Log(item.ItemFood);
                    }

                    items.pickUpItems.Clear();
                }
                else
                {
                    Debug.LogError("Nothing to choop!");
                }
            }
        }
    }
}
