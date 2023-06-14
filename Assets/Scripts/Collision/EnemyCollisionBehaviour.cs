using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
	[SerializeField, Tooltip("The amount of force to apply to the player when they are hit.")]
	private float _knockbackForce;

	[SerializeField, Tooltip("The angle (in degrees) at which the player should be knocked back.")]
	private float _knockbackAngle;

	private void OnTriggerEnter(Collider other)
	{
		// Make sure the colliding object has a DamageBehavior and that it isn't invincible.
		DamageBehavior damageBehavior = other.GetComponent<DamageBehavior>();
		if (!damageBehavior || damageBehavior.IsInvincible) return;

		float angleRadians = _knockbackAngle * Mathf.Deg2Rad;

		Vector3 knockbackDirection = new Vector3(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0);

		damageBehavior.ApplyDamage(knockbackDirection, _knockbackForce);
	}
}