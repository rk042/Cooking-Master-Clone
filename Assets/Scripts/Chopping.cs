using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CookingMaster
{
    public class Chopping : MonoBehaviour
    {        
        [SerializeField] SpriteRenderer spriteRenderer;

        IPickupItems pickupItems;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickupItems items))
            {
                if (items.manager.pickUpItems.Any())
                {
                    pickupItems = items;

                    pickupItems.player.StopPlayerMovement();
                    pickupItems.manager.HideShow_PickupedItemsFromHands(false);

                    StartCoroutine(COR_StartChooping());
                }
                else
                {
                    Debug.LogError("Nothing to choop!");
                }
            }
        }

        private IEnumerator COR_StartChooping()
        {
            foreach (var item in pickupItems.manager.pickUpItems) 
            {
                if (item.IsChooped)
                {
                    Debug.Log($"item is ===>>> {item.IsChooped}");
                    continue;
                }

                spriteRenderer.sprite = item.sprite;
                yield return StartCoroutine(item.StartProcess());
                item.IsChooped = true;
            }

            Debug.Log("chooping done");
            spriteRenderer.sprite = null;   
            pickupItems.manager.HideShow_PickupedItemsFromHands(true);
            pickupItems.player.StartPlayerMoveMent();
            pickupItems.manager.isChoopingDone = true;
        }
    }
}
