using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

namespace Utility.Projectiles
{
	public class BulletBehavior : MonoBehaviour
	{
		[SerializeField, Tooltip("The time in seconds before the bullet automatically despawns.")]
		private float _lifetime;

		private float _elapsedTime = 0;

		private void Update()
		{
			_elapsedTime += Time.deltaTime;

			if (_elapsedTime >= _lifetime)
			{
				_elapsedTime = 0;
				ObjectPoolBehavior.Instance.ReturnObject(gameObject);
			}
		}
	}
}
