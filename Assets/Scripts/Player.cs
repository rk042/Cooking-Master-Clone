using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] float moveSpeed;

        private void Start()
        {
            playerMovement = new PlayerMovement();
        }

        private void Update()
        {
            playerMovement.MovePlayerUpdate(transform,moveSpeed);
        }
    }
}
