using UnityEngine;
using mathF = UnityEngine.Mathf;

namespace CookingMaster
{

    [System.Serializable]
    public class PlayerMovement
    {
        private const float minLeftMovement = -6.5f;
        private const float maxRightMovement = 6.5f;
        private const float minUpMovement = -2f;
        private const float maxDownMovement = 2.5f;

        [SerializeField] private KeyCode keycodeMoveUP = KeyCode.W;
        [SerializeField] private KeyCode keycodeMoveDown = KeyCode.S;
        [SerializeField] private KeyCode keycodeMoveLeft = KeyCode.A;
        [SerializeField] private KeyCode keycodeMoveRight = KeyCode.D;

        Vector2 movement = Vector2.zero;

        // Update is called once per frame
        public void MovePlayerUpdate(Transform transform, float moveSpeed)
        {
            movement = transform.position;

            if (Input.GetKey(keycodeMoveUP))
            {
                movement += Vector2.up;
            }
            else if (Input.GetKey(keycodeMoveDown))
            {
                movement += Vector2.down;
            }
            else if (Input.GetKey(keycodeMoveLeft))
            {
                movement += Vector2.left;
            }
            else if (Input.GetKey(keycodeMoveRight))
            {
                movement += Vector2.right;
            }

            movement.x = mathF.Clamp(movement.x, minLeftMovement, maxRightMovement);
            movement.y = mathF.Clamp(movement.y, minUpMovement, maxDownMovement);

            transform.position = Vector2.MoveTowards(transform.position, movement, moveSpeed * Time.deltaTime);
        }
    }
}
