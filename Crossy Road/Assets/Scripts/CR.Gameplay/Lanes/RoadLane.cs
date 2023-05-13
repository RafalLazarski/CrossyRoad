using UnityEngine;

namespace CR.Gameplay
{
	public class RoadLane : BaseLane, ISpawnable
	{
        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private GameObject whiteLines;

        public Vector3 GetSpawnPoint()
        {
            return spawnPoint.position;
        }

        public override void PrepareForActivate()
        {
            base.PrepareForActivate();
        }

        public override void PrepareForDeactivate()
        {
            base.PrepareForDeactivate();
        }

        public void DisableRectangles()
        {
            whiteLines.SetActive(false);
        }
    } 
}
