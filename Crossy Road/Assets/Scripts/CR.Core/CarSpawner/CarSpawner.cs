using CR.Gameplay;
using CR.Pooling;
using System.Collections.Generic;
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
                var car = normalCarPool.GetFromPool(lane.GetSpawnPoint());
            }

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