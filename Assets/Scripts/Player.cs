using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public int PlayerId { get; private set; }

        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] float moveSpeed;
        
        private bool isPlayerMove = true;
        public int Score { get; set; }

        private void Update()
        {
            if (isPlayerMove) 
            { 
                playerMovement.MovePlayerUpdate(transform,moveSpeed);
            }
        }
        public void StopPlayerMovement()
        {
           isPlayerMove = false;
        }
        public void StartPlayerMoveMent()
        {
            isPlayerMove = true;
        }
    }
}
