using UnityEngine;

namespace CR.Gameplay
{
	public class CameraMovementController : MonoBehaviour
	{
		[SerializeField]
		private float speed;

        [SerializeField]
        private float maxSpeed;

        private bool isMoving = true;

        [SerializeField]
        private float distance;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private Transform detector;

        public void UpdateCameraPosition()
        {
            if (!isMoving)
                return;

            var diff = detector.transform.position.z - player.position.z;
            var diffNormalized = diff / distance;
            var finalSpeed = Mathf.Lerp(maxSpeed, speed, diffNormalized);

            transform.position += Vector3.forward * (finalSpeed * Time.deltaTime);
        }

    }
}
