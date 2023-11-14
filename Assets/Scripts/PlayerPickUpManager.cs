using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerPickUpManager : MonoBehaviour, IPickupItems
    {
        [SerializeField] int itemsCountPlayerCanPickup = 2;
        [SerializeField] SpriteRenderer[] pickupItem;

        public Queue<Item> pickUpItems { get; private set; } = new Queue<Item>();
        public Player player { get ; set ; }

        public PlayerPickUpManager manager { get; private set; }

        public EventHandler<Item> ItemHasPickuped;
        public bool isChoopingDone = false;

        private void Start()
        {
            manager = this;
            player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            ItemHasPickuped += OnItemHasPickuped;    
        }

        private void OnDisable()
        {
            ItemHasPickuped -= OnItemHasPickuped;    
        }

        private void OnItemHasPickuped(object sender, Item e)
        {
            if (pickUpItems.Count<itemsCountPlayerCanPickup)
            {
                Debug.Log($"item pickuped {e.ItemFood} {pickUpItems.Count}");
                pickupItem[pickUpItems.Count].sprite = e.sprite;
                pickUpItems.Enqueue(e);
                isChoopingDone = false;
            }
            else
            {
                Debug.LogError($"Your are tring to pickup more then your pickup item count! \n your pickup count is {itemsCountPlayerCanPickup}");
            }
        }

        public void HideShow_PickupedItemsFromHands(bool isShow)
        {
            foreach (var item in pickupItem)
            {
                item.gameObject.SetActive(isShow);
            }
        }

        public void ClearPlayerHands()
        {
            foreach (var item in pickupItem)
            {
                item.sprite = null;
            }
        }
    }
}
