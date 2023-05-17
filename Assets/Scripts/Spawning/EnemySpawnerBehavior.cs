using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;
namespace EnemyBehavior
{
	public class EnemySpawnerBehavior : MonoBehaviour
	{
		[SerializeField, Tooltip("The enemies that will be spawned in the level.")]
		private GameObject[] _enemies;
		void Start()
		{
			int _randomNumber = Random.Range(0, _enemies.Length-1);
			ObjectPoolBehavior.Instance.GetObject(_enemies[_randomNumber], transform.position, Quaternion.identity);
		}
	}
}
