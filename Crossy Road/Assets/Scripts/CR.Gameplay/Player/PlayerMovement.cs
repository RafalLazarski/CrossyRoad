using UnityEngine;
using DG.Tweening;
using System;

namespace CR.Gameplay
{
	public class PlayerMovement : MonoBehaviour
	{
        [SerializeField]
        private Collider collider;

        private bool canMove = true;
        private float highestZ;

        public Action OnLose;

        public void UpdateMovement(Vector2 input, PointsSystem pointsSystem)
        {
            if (input.x > 0)
                MoveRight();
            else if (input.x < 0)
                MoveLeft();
            else if (input.y > 0)
                MoveForward(pointsSystem);
            else if (input.y < 0)
                MoveBack();
        }

        private void MoveForward(PointsSystem pointsSystem)
        {
            if (!canMove)
                return;

            canMove = false;

            transform.DORotate(new Vector3(0, 0, 0), .2f);
            var endValue = transform.position + Vector3.forward * 5f;

            if(endValue.z > highestZ)
            {
                this.highestZ = endValue.z;
                pointsSystem.AddPoint();
            }

            transform.DOJump(endValue, 1f, 1, .2f).OnComplete(EnableMovement);
        }

        private void MoveBack()
        {
            if (!canMove)
                return;

            canMove = false;

            transform.DORotate(new Vector3(0, -180, 0), .2f);
            var endValue = transform.position + Vector3.back * 5f;

            transform.DOJump(endValue, 1f, 1, .2f).OnComplete(EnableMovement);
        }

        private void MoveLeft()
        {
            if (!canMove)
                return;

            canMove = false;

            transform.DORotate(new Vector3(0, -90, 0), .2f);
            var endValue = transform.position + Vector3.left * 5f;

            transform.DOJump(endValue, 1f, 1, .2f).OnComplete(EnableMovement);
        }

        private void MoveRight()
        {
            if (!canMove)
                return;

            canMove = false;

            transform.DORotate(new Vector3(0, 90, 0), .2f);
            var endValue = transform.position + Vector3.right * 5f;

            transform.DOJump(endValue, 1f, 1, .2f).OnComplete(EnableMovement);
        }

        private void EnableMovement()
        {
            canMove = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car") || other.CompareTag("Despawn"))
            {
                this.collider.enabled = false;
                OnLose.Invoke();
            }
        }
    }
}
