using System;
using UnityEngine;

namespace CR.Gameplay
{
    public class TrackLane : BaseLane, ISpawnable
    {
        public Vector3 GetSpawnPoint()
        {
            return GetSpawnPointPosition();
        }

        public Quaternion GetSpawnRotation()
        {
            return GetSpawnPointRotation();
        }
    }
}
