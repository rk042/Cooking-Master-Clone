using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CookingMaster
{
    public class Customer : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickupItems items))
            {
                if (items.manager.pickUpItems.Any())
                {
                    if (items.manager.isChoopingDone)
                    {
                        Debug.Log("food delivered");
                        items.manager.isChoopingDone = false;
                        items.manager.pickUpItems.Clear();
                        items.manager.ClearPlayerHands();
                    }
                    else
                    {
                        foreach (var item in items.manager.pickUpItems)
                        {
                            if (!item.IsChooped)
                            {
                                Debug.LogError($"{item.ItemFood} is not cooked.");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("there is not food to deliver");
                }
            }
        }
    }
}
