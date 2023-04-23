using UnityEngine;

namespace CR.Gameplay
{
	public class GreenLane : BaseLane
	{
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField]
        private Color lightGreen;

        [SerializeField]
        private Color darkGreen;

        public void SetColor(int count)
        {
            meshRenderer.material.color = count % 2 == 0 ? lightGreen : darkGreen;
        }

        public override void PrepareForActivate()
        {
            base.PrepareForActivate();
        }

        public override void PrepareForDeactivate()
        {
            base.PrepareForDeactivate();
        }
    } 
}
