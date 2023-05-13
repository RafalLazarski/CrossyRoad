using CR.Core;
using CR.Gameplay;
using CR.Pooling;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
	[SerializeField]
	private CarSpawner carSpawner; 

	[SerializeField]
	private LanesBundle[] lanesBundles;
	[SerializeField]
	private GreenLanePool greenLanePool;
	[SerializeField]
	private RoadLanePool roadLanePool;
	[SerializeField]
	private TrackLanePool trackLanePool;

	public void Init(int startLanes)
	{
		for(var i = 0; i < startLanes; i++)
		{
			greenLanePool.Init(2);
			roadLanePool.Init(2);
			trackLanePool.Init(2);
			SpawnBundle();
		}
	}

	private void SpawnBundle()
	{
		var bundle = lanesBundles[Random.Range(0, lanesBundles.Length)];

		foreach(var item in bundle.lanes)
		{
			if(item.Type == LaneType.Green)
			{
				for(int i = 0; i < item.Count; i++)
				{
                    var obj = greenLanePool.GetFromPool(this.transform.position);
					obj.SetColor(i);

                    this.transform.position += Vector3.forward * 5;

                    if (obj is ISpawnable spawnable)
					{
						carSpawner.Subscribe(spawnable);
					}
                }                
            }
			else if(item.Type == LaneType.Road)
			{
				for (int i = 0; i < item.Count; i++)
				{
					var obj = roadLanePool.GetFromPool(this.transform.position);

					obj.SetDirection(item.Direction);

                    if (i == item.Count - 1)
                    {
                        obj.DisableRectangles();
                    }

                    this.transform.position += Vector3.forward * 5;

                    if (obj is ISpawnable spawnable)
                    {
                        carSpawner.Subscribe(spawnable);
                    }
                }
            }
			else if(item.Type == LaneType.Track)
			{
				for (int i = 0; i < item.Count; i++)
				{
					var obj = trackLanePool.GetFromPool(this.transform.position);

                    obj.SetDirection(item.Direction);

                    this.transform.position += Vector3.forward * 5;

                    if (obj is ISpawnable spawnable)
                    {
                        carSpawner.Subscribe(spawnable);
                    }
                }
            }
            
        }
	}

}
