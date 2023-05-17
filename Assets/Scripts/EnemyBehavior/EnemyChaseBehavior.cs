using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyBehavior
{
	public class EnemyChaseBehavior : MonoBehaviour
	{
		[SerializeField, Tooltip("How fast the enemy should move towards the player.")]
		private float _speed;
		
		[SerializeField, Tooltip("How close the enemy should be to the player before it starts chasing.")]
		private float _range;

		
		void FixedUpdate()
		{
			if (!GameManager.Instance.Player.gameObject)
				return;
				
			if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < _range)
				transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, 
					_speed * Time.deltaTime);
		}
	}
}

