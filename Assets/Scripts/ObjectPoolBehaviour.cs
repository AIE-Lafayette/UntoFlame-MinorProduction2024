using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPoolBehaviour : MonoBehaviour
    {
        private List<Pool> _objectPools = new List<Pool>();
        private static ObjectPoolBehaviour _instance;

        public static ObjectPoolBehaviour Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ObjectPoolBehaviour>();
                }

                if (_instance == null)
                {
                    GameObject objectPool = new GameObject("Object Pool");
                    _instance = objectPool.AddComponent<ObjectPoolBehaviour>();
                }

                return _instance;
            }
        }

        public Pool GetPool(GameObject gameObject)
        {
            foreach (Pool pool in _objectPools)
            {
                if (pool.Name == gameObject.name)
                {
                    return pool;
                }

            }
            return null;
        }

        public GameObject GetObject(GameObject objectReference)
        {
            Pool objectPool = GetPool(objectReference);

            if (objectPool != null && objectPool.Count > 0)
            {
                GameObject objectInstance = objectPool.GetObject();
                objectInstance.SetActive(true);
                return objectInstance;
            }

            else
            {
                return CreateNewObject(objectReference);
            }
        }

        public GameObject GetObject(GameObject objectReference, Vector3 position, Quaternion rotation)
        {
            Pool objectPool = GetPool(objectReference);

            if (objectPool != null && objectPool.Count > 0)
            {
                GameObject objectInstance = objectPool.GetObject();
                objectInstance.SetActive(true);

                objectInstance.transform.position = position;
                objectInstance.transform.rotation = rotation;

                return objectInstance;
            }

            else
            {
                return CreateNewObject(objectReference, position, rotation);
            }
        }

        /// <summary>
        /// Makes the game object inactive in the scene and adds it back to the pool.
        /// </summary>
        /// <param name="objectInstance">The instance of the game object to return to the pool.</param>
        public void ReturnObject(GameObject objectInstance)
        {
            if (!objectInstance)
            {
                return;
            }

            Pool objectPool = GetPool(objectInstance);

            //If pool for this object type doesn't exist...
            if (objectPool == null)
            {
                //...create new pool for the object.
                objectPool = new Pool(objectInstance);
                _objectPools.Add(objectPool);
                objectInstance.SetActive(false);
            }

            //If a pool exists that contains an object of this name...
            else if (!objectPool.Contains(objectInstance))
            {
                //...add the object back to its pool.
                objectPool.ReturnObject(objectInstance);
                objectInstance.SetActive(false);
            }

        }

        /// <summary>
        /// Gets the first instance of the object found in the pool.
        /// </summary>
        /// <param name="objectReference">A reference to the prefab to instantiate.</param>
        private GameObject CreateNewObject(GameObject objectReference)
        {
            GameObject newObject = Instantiate(objectReference);
            newObject.name = objectReference.name;
            return newObject;
        }

        /// <summary>
        /// Gets the first instance of the object found in the pool.
        /// </summary>
        /// <param name="objectReference">A reference to the prefab to instantiate.</param>
        /// <param name="position">The new position of the object.</param>
        /// <param name="rotation">The new rotation of the object.</param>
        /// <returns> The new instance of the object reference.</returns>
        private GameObject CreateNewObject(GameObject objectReference, Vector3 position, Quaternion rotation)
        {
            GameObject newObject = Instantiate(objectReference, position, rotation);
            newObject.name = objectReference.name;
            return newObject;
        }
    }
}

