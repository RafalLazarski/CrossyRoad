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

	[Serializable]
	public class LaneData
	{
		public LaneType Type;
		[Min(1)]
		public int Count;
	}

	[CreateAssetMenu(menuName = "Bundle/new bundle")]
	public class LanesBundle : ScriptableObject
	{
		public LaneData[] lanes;
	} 
}
