using UnityEngine;

namespace CR.Gameplay
{
	public class RoadLane : BaseLane, ISpawnable
	{
        [SerializeField]
        private Transform[] spawnPoint;

        [SerializeField]
        private GameObject whiteLines;

        private LaneDirection direction;

        public Vector3 GetSpawnPoint()
        {
            return spawnPoint[(int)direction].position;
        }

        public Quaternion GetSpawnRotation()
        {
            return spawnPoint[(int)direction].rotation;
        }

        public void SetDirection(LaneDirection direction)
        {
            this.direction = direction;
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
