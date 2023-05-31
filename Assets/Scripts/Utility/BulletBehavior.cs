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

		private bool _isFire;

		[Tooltip("Determines if the bullet is fire. If so, it will kill the player.")]
		public bool IsFire
		{
			get { return _isFire; }
			private set { _isFire = value; }
		}

		private void Update()
		{
			_elapsedTime += Time.deltaTime;

			if (_elapsedTime >= _lifetime)
			{
				_elapsedTime = 0;
				ObjectPoolBehavior.Instance.ReturnObject(gameObject);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				DamageBehavior damageBehavior = other.GetComponent<DamageBehavior>();
				if (!damageBehavior) return;
				if (!_isFire)
					damageBehavior.ApplyDamage(transform.forward);
				else
					damageBehavior.Kill();

				ObjectPoolBehavior.Instance.ReturnObject(gameObject);


			}
		}
	}
}
