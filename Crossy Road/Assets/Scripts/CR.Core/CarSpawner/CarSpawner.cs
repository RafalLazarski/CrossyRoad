using CR.Gameplay;
using CR.Pooling;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace CR.Core
{
	public class CarSpawner : MonoBehaviour
	{
        [SerializeField]
        private NormalCarPool normalCarPool;

		private List<ISpawnable> lanesInGame = new List<ISpawnable>();

        public void InitSpawner()
        {
            normalCarPool.Init(10);
        }

        public void SpawnCars()
        {
            foreach (var lane in lanesInGame)
            {
                StartCoroutine(SpawnCarsLoop(lane));
            }
        }

        public IEnumerator SpawnCarsLoop(ISpawnable lane)
        {    
            while (true)
            {
                var car = normalCarPool.GetFromPool(lane.GetSpawnPoint());

                car.AddListener(DespawnCar);

                car.transform.rotation = lane.GetSpawnRotation();

                car.StartMovement();

                var timeFrame = lane.GetTimeFrame();

                var timeToNextSpawn = Random.Range(timeFrame.x, timeFrame.y);

                yield return new WaitForSeconds(timeToNextSpawn);
            }
        }

        private void DespawnCar(BaseCar car)
        {
            normalCarPool.ReturnToPool(car as NormalCar);
        }

        public void Subscribe(ISpawnable item)
        {
            if (!lanesInGame.Contains(item))
            {
                lanesInGame.Add(item);
            }
        }

        public void Unsubscribe(ISpawnable item)
        {
            if (lanesInGame.Contains(item))
            {
                lanesInGame.Remove(item);
            }
        }
    } 
}
