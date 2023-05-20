using CR.Core;
using CR.Gameplay;
using CR.Pooling;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
	[SerializeField]
	private CarSpawner carSpawner; 

	[SerializeField]
	private LanesBundle[] bundles;
    [SerializeField]
    private LanePool greenLanePool;
    [SerializeField]
    private LanePool roadLanePool;
    [SerializeField]
    private LanePool trackLanePool;

    private int greenCounter;

    private LanesBundle currentBundle;
    private int lastBundleLaneIndex;


    public void Init(int startBundles)
	{
        greenLanePool.Init(20);
        roadLanePool.Init(20);
        trackLanePool.Init(20);

        for (var i = 0; i < startBundles; ++i)
            SpawnLaneBundle();
    }

    private void SetNewBundle()
    {
        lastBundleLaneIndex = 0;
        currentBundle = bundles[Random.Range(0, bundles.Length)];
    }

    private LanePool GetPool(LaneType laneType)
    {
        switch (laneType)
        {
            case LaneType.Green:
                return greenLanePool;
            case LaneType.Road:
                return roadLanePool;
            case LaneType.Track:
                return trackLanePool;
        }
        return null;
    }


    private void ReturnLane(BaseLane lane, LaneType type)
    {
        var pool = GetPool(type);
        pool.ReturnToPool(lane);

        if (lane is ISpawnable spawnable)
        {
            carSpawner.Unsubscribe(spawnable);
        }
    }


    private void SpawnLaneBundle()
    {
        SetNewBundle();
        foreach (var item in currentBundle.lanes)
        {
            var pool = GetPool(item.Type);

            var obj = pool.GetFromPool(this.transform.position);
            this.transform.position += Vector3.forward * 5;
            obj.SetDirection(item.Direction);
            obj.AddListener((lane) => ReturnLane(lane, item.Type));
            obj.SetAdditionalObjectsState(item.enableAdditionalObjects);
            obj.RefreshObjectState();

            if(item.Type == LaneType.Green)
            {
                greenCounter++;
                obj.SetColor(greenCounter);
            }

            if(obj is ISpawnable spawnable)
            {
                carSpawner.Subscribe(spawnable);
            }
        }
    }

}
