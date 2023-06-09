using System;
using System.Xml.Schema;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CR.Gameplay
{
    public class BaseCar : MonoBehaviour, IPoolable
    {
        private Action<BaseCar> onDespawn;

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


        public virtual void PrepareForActivate()
        {
        }

        public virtual void PrepareForDeactivate()
        {
            onDespawn = null;
        }
    }
}
