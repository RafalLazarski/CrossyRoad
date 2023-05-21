using System;
using System.Xml.Schema;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CR.Gameplay
{
    public class BaseCar : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private Rigidbody carRb;

        [SerializeField]
        private float minSpeed = 10;

        [SerializeField]
        private float maxSpeed = 20;

        private Action<BaseCar> onDespawn;

        public void StartMovement()
        {
            carRb.AddForce(this.transform.forward * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Despawn"))
            {
                onDespawn?.Invoke(this);
            }
        }

        public void AddListener(Action<BaseCar> callback)
        {
            onDespawn += callback;
        }


        public void PrepareForActivate()
        {
        }

        public void PrepareForDeactivate()
        {
            onDespawn = null;
        }
    }
}
