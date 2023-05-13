using System;
using UnityEngine;

namespace CR.Gameplay
{
    public enum CarType
    {
        Normal,
        Van,
        Police
    }

    [Serializable]
    public class CarData
    {
        public CarType Type;
        [Min(1)]
        public int Count;
    }

    [CreateAssetMenu(menuName = "Bundle/new car bundle")]
    public class CarBundles : ScriptableObject
	{
        public CarData[] cars;
	} 
}
