using UnityEngine;

namespace CR.Gameplay
{
	public class PlayerMovement : MonoBehaviour
	{
        public void UpdateMovement(Vector2 input)
        {
            if (input.x > 0)
                MoveRight();
            else if (input.x < 0)
                MoveLeft();
            else if (input.y > 0)
                MoveForward();
            else if (input.y < 0)
                MoveBack();
        }

        private void MoveForward()
        {
            transform.position += Vector3.forward * 5f;
        }

        private void MoveBack()
        {
            transform.position -= Vector3.forward * 5f;
        }

        private void MoveLeft()
        {
            transform.position -= Vector3.right * 5f;
        }

        private void MoveRight()
        {
            transform.position += Vector3.right * 5f;
        }

    }
}
