using UnityEngine;

public interface ISpawnable
{
	Vector3 GetSpawnPoint();
	Quaternion GetSpawnRotation();

	Vector2 GetTimeFrame();
}
