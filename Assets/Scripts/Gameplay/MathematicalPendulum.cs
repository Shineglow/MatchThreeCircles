using UnityEngine;

namespace Gameplay
{
	public class MathematicalPendulum : MonoBehaviour
	{
		[SerializeField] private Transform loadAnchor;
		[SerializeField] private Transform rotationPoint;
		[SerializeField] private float thetaMaxDeg;

		private float _g;
		private float _l;
		private float _t;
		private float _previousAngle;
		private float _thetaMax;
		
		private void Start()
		{
			_g = Physics2D.gravity.magnitude;
			_l = (loadAnchor.position - transform.position).magnitude;
			_thetaMax = thetaMaxDeg * Mathf.Deg2Rad;
			_previousAngle = _thetaMax;
			transform.rotation = Quaternion.Euler(0, 0, _thetaMax);
		}

		private void Update()
		{
			float omega = Mathf.Sqrt(_g / _l);
			_t += Time.deltaTime;

			float newAngle = _thetaMax * Mathf.Sin(omega * _t);
			float deltaAngle = newAngle - _previousAngle;

			transform.Rotate(Vector3.forward, deltaAngle * Mathf.Rad2Deg);

			_previousAngle = newAngle;
		}
	}
}