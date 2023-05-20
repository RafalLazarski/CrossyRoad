using System;
using UnityEngine;

namespace CR.Gameplay
{
	public class RoadLane : BaseLane, ISpawnable
	{
        [SerializeField]
        private GameObject[] whiteRectangles;

        public Vector3 GetSpawnPoint()
        {
            return GetSpawnPointPosition();
        }

        public Quaternion GetSpawnRotation()
        {
            return GetSpawnPointRotation();
        }

        public override void PrepareForActivate()
        {
            foreach (var rect in whiteRectangles)
                rect.SetActive(false);
        }

        public override void RefreshObjectState()
        {
            foreach (var rect in whiteRectangles)
                rect.SetActive(enableAdditionalObjects);
        }
    }
}
