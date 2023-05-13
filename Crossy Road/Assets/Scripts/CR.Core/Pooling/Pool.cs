using System.Collections.Generic;
using UnityEngine;

namespace CR.Pooling
{
	public class Pool<TItem> : MonoBehaviour
where TItem : MonoBehaviour, IPoolable
	{
		private int size;
		public int Count => storedItems.Count;

		private Stack<TItem> storedItems;

		[SerializeField]
		private TItem originalPrefab;

		public void Init(int size)
		{
			storedItems = new Stack<TItem>(size);
			for (var i = 0; i < size; i++)
			{
				var obj = SpawnNewObject();
				storedItems.Push(obj);
			}
		}

		private TItem SpawnNewObject()
		{
			var newObj = Instantiate(originalPrefab, Vector3.zero, Quaternion.identity, this.transform);
			newObj.gameObject.SetActive(false);
			return newObj;
		}

		public TItem GetFromPool(Vector3 position)
		{
			TItem toReturn =
				storedItems.Count == 0 ?
					SpawnNewObject() :
					storedItems.Pop();

			toReturn.transform.position = position;
			toReturn.transform.rotation = originalPrefab.transform.rotation;

			toReturn.transform.SetParent(null);
			toReturn.PrepareForActivate();
			toReturn.gameObject.SetActive(true);

			return toReturn;
		}

		public void ReturnToPool(TItem item)
		{
			if (storedItems.Count < size)
			{
				item.PrepareForDeactivate();
				item.gameObject.SetActive(false);
				item.transform.SetParent(this.transform);
				storedItems.Push(item);
			}
			else
			{
				Destroy(item.gameObject);
			}
		}


	} 
}
