using System.Xml.Schema;
using UnityEngine;

namespace CR.Gameplay
{
    public class BaseCar : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private Rigidbody carRb;

        [SerializeField]
        private float speed = 10;

        public void StartMovement()
        {
            carRb.AddForce(this.transform.forward * speed, ForceMode.Impulse);
        }


        public void PrepareForActivate()
        {
        }

        public void PrepareForDeactivate()
        {
        }
    }
}
