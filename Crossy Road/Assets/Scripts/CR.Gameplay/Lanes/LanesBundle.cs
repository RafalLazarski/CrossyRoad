using System;
using UnityEngine;

namespace CR.Gameplay
{
	public enum LaneType
	{
		Green,
		Road,
		Track
	}

	public enum LaneDirection
	{
		Right,
		Left
	}

	[Serializable]
	public class LaneData
	{
		public LaneType Type;
		public LaneDirection Direction;
        public bool enableAdditionalObjects;
    }

    [CreateAssetMenu(menuName = "Bundle/new bundle")]
	public class LanesBundle : ScriptableObject
	{
		public LaneData[] lanes;
	}
}
