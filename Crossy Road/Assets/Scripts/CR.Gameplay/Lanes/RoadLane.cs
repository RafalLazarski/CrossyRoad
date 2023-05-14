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
            throw new NotImplementedException();
        }

        public Quaternion GetSpawnRotation()
        {
            throw new NotImplementedException();
        }

        public override void PrepareForActivate()
        {
            foreach (var rect in whiteRectangles)
                rect.SetActive(enableAdditionalObjects);
        }
    }
}
