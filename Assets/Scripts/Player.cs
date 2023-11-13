using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] float moveSpeed;
        
        private bool isPlayerMove = true;

        private void Start()
        {
            playerMovement = new PlayerMovement();
        }

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
