using UnityEngine;

public class EnemyPatrolBehavior : MonoBehaviour
{

	[SerializeField, Tooltip("How fast the enemy should move between each point.")]
	private float _speed;

	[SerializeField, Tooltip("A collection of patrol points. The enemy will travel in the order of patrol points from top to bottom.")]
	private Transform[] _patrolPoints;

	[SerializeField, Tooltip("The amount of time in seconds to wait before moving on to the next patrol point.")]
	private float _waitTime;
	private float _timeWaited;

	private int _currentPoint = 0;

	private Vector3 _target;

	void Start()
	{
		for (int i = 0; i < _patrolPoints.Length; i++)
			_patrolPoints[i].SetParent(null);

		transform.position = _patrolPoints[0].position;
		_target = _patrolPoints[1].position;
	}

	void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

		// check the distance to see if its close enough to move to the next point
		if (Vector3.Distance(transform.position, _target) < 0.05f)
		{
			_timeWaited += Time.deltaTime;
			if (_timeWaited > _waitTime)
			{
				_currentPoint = (_currentPoint >= _patrolPoints.Length - 1) ? 0 : _currentPoint + 1;
				_target = _patrolPoints[_currentPoint].position;
				_timeWaited = 0;
			}
		}   
	}
}
