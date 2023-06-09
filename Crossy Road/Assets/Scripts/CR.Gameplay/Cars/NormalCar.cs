using UnityEngine;

namespace CR.Gameplay
{
    public class NormalCar : BaseCar
    {
        [SerializeField]
        private Rigidbody carRb;

        [SerializeField]
        private float speed;

        public void StartMovement()
        {
            carRb.AddForce(this.transform.forward * speed, ForceMode.Impulse);
        }

        public override void PrepareForActivate()
        {
            base.PrepareForActivate();
            carRb.velocity = Vector3.zero;
        }

    }
}
