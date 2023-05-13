using System.Collections.Generic;
using UnityEngine;

namespace CR.Core
{
	public class VehicleSpawner : MonoBehaviour
	{
		private List<ISpawnable> lanesInGame = new List<ISpawnable>();

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
