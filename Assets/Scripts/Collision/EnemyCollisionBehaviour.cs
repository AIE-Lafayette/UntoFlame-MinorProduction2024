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
		if (!other.CompareTag("Player")) return;

		float angleRadians = _knockbackAngle * Mathf.Deg2Rad;

		Vector3 knockbackDirection = new Vector3(-Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0);

		GameManager.Instance.Player.GetComponent<Rigidbody>().AddForce(knockbackDirection * _knockbackForce);
	}
}