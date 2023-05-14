using System;
using UnityEngine;

namespace CR.Gameplay
{
    public class TrackLane : BaseLane, ISpawnable
    {
        public Vector3 GetSpawnPoint()
        {
            throw new NotImplementedException();
        }

        public Quaternion GetSpawnRotation()
        {
            throw new NotImplementedException();
        }
    }
}
