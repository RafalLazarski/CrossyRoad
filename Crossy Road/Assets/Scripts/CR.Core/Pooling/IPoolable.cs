using UnityEngine;

public interface IPoolable
{
	void PrepareForActivate();
	void PrepareForDeactivate();
}
