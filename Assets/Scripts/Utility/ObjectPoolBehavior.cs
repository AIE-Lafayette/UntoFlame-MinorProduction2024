using System.Collections.Generic;
using UnityEngine;

namespace Utility.ObjectPool
{
	public class ObjectPoolBehavior : MonoBehaviour
	{
		private List<Pool> _objectPools;
		private static ObjectPoolBehavior _instance;
		public static ObjectPoolBehavior Instance
		{
			get
			{
				if (!_instance)
					_instance = FindObjectOfType<ObjectPoolBehavior>();

				if (!_instance)
				{
					Debug.Log("No Object Pool found in scene. Creating one.");
					_instance = new GameObject("Object Pool").AddComponent<ObjectPoolBehavior>();
				}

				return _instance;
			}
		}

		public Pool GetPool(GameObject gameObject)
		{
			foreach (Pool pool in _objectPools)
			{
				if (pool.Name == gameObject.name)
					return pool;
			}

			return null;
		}
		
		public GameObject GetObject(GameObject gameObject)
		{
			Pool objectPool = GetPool(gameObject);

			if (objectPool != null && objectPool.Count > 0)
			{
				GameObject pooledObject = objectPool.GetObject();
				pooledObject.SetActive(true);
				return pooledObject;
			}

			return null;
		}
	}	
}

