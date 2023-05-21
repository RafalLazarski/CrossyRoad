using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CR.Gameplay
{
	public class GreenLane : BaseLane
	{
		[SerializeField]
		private GameObject[] spots;

        [SerializeField]
        private GameObject[] obstacles;

        private List<GameObject> spawnObjs = new List<GameObject>();

        public override void PrepareForDeactivate()
        {
            foreach (var val in spawnObjs)
            {
                Destroy(val.gameObject);
            }

            spawnObjs.Clear();

        }

        public override void RefreshObjectState()
        {
            if (!enableAdditionalObjects)
                return;

            var usedSpots = new List<int>();

            for (int i = 0; i < obstaclesLimit; ++i)
            {
                int spotIdx = -1;
                do
                {
                    spotIdx = Random.Range(0, spots.Length);
                } while (usedSpots.Contains(spotIdx));
                usedSpots.Add(spotIdx);
                var obstacleObj = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spots[spotIdx].transform.position, Quaternion.identity);

                spawnObjs.Add(obstacleObj);
            }
        }
    } 
}
