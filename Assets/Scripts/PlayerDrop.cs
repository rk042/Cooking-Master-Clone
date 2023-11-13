using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class PlayerDrop : MonoBehaviour,IPickupItems
    {
        public PlayerPickUpManager manager { get; set ; }
        public Player player { get ; set ; }

        private void Start()
        {
            manager = GetComponentInParent<PlayerPickUpManager>();
            player = GetComponentInParent<Player>();
        }
    }
}
