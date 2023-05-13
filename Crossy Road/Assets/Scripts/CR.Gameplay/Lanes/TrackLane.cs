using UnityEngine;

namespace CR.Gameplay
{
	public class TrackLane : BaseLane, ISpawnable
	{
        [SerializeField]
        private Transform spawnPoint;

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
    } 
}
