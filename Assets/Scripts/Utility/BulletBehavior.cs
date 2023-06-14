using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

namespace Utility.Projectiles
{
	public class BulletBehavior : MonoBehaviour
	{
		[SerializeField]
		private float _knockbackForce;
		[SerializeField]
		private float _knockbackAngle;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				DamageBehavior damageBehavior = other.GetComponent<DamageBehavior>();
				if (!damageBehavior) return;

				float angleRadians = _knockbackAngle * Mathf.Deg2Rad;

				Vector3 knockbackDirection = new Vector3(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0);
		
				damageBehavior.ApplyDamage(knockbackDirection, _knockbackForce);		
			}

			if (!other.CompareTag("Enemy") && !other.CompareTag("Bullet") && !other.CompareTag("NoHit"))
			{	
				ObjectPoolBehavior.Instance.ReturnObject(gameObject);
			}
				
		}
	}
}
