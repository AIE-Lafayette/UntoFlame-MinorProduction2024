//using UnityEngine;

//public class TempMovementBehavior : MonoBehaviour
//{
//	[SerializeField, Tooltip("How fast the character should move.")]
//	private float _speed;

//	// Update is called once per frame
//	void Update()
//	{
//		if (Input.GetKey("a") || Input.GetKey("d"))
//		{
//			transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * _speed * Time.deltaTime * GameManager.GameSpeedMultiplier;
//		}

//		if (Input.GetKey("w") || Input.GetKey("s"))
//		{
//			transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime * GameManager.GameSpeedMultiplier;
//		}

//	}
//}
