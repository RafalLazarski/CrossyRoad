using System;
using UnityEngine;

namespace CR.Gameplay
{
	public class ObstaclesDespawner : MonoBehaviour
	{
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Despawn"))
                Destroy(gameObject);
        }
    }
}
