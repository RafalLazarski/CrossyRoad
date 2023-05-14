using UnityEngine;

namespace CR.Gameplay
{
	public class CameraMovementController : MonoBehaviour
	{
		[SerializeField]
		private float speed;

		public void MoveCamera()
		{
            transform.Translate(0, 0, 1 * speed * Time.deltaTime, Space.World);
        }
	} 
}
