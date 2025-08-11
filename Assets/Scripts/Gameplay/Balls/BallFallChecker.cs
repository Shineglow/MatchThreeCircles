using com.shineglow.di.Runtime;
using StaticData.Levels;
using UnityEngine;

namespace Gameplay.Balls
{
	public class BallFallChecker : MonoBehaviour
	{
		[SerializeField] private LevelInfo levelInfo;
		[SerializeField] private Rigidbody2D rb;

		private IReadOnlyLevelInfo _levelInfo;
		private float _idleTimer;
		private bool _hasDropped;

		private void Awake()
		{
			Construct(levelInfo);
		}

		[Inject]
		private void Construct(IReadOnlyLevelInfo levelInfo)
		{
			_levelInfo = levelInfo;
		}

		public void SetDropped()
		{
			_hasDropped = true;
		}

		private void Update()
		{
			if (!_hasDropped) return;

			if (rb.velocity.magnitude < _levelInfo.LevelRules.IdleThreshold)
			{
				_idleTimer += Time.deltaTime;
				if (_idleTimer >= _levelInfo.LevelRules.IdleTimeToSettle)
				{
					CheckLoseCondition();
				}
			}
			else
			{
				_idleTimer = 0f;
			}
		}

		private void CheckLoseCondition()
		{
			if (transform.position.y >= _levelInfo.LevelRules.LoseLineY)
			{
				enabled = false;
				Debug.Log("Поражение!");
			}
			else
			{
				enabled = false;
				Debug.Log("Лёг нормально!");
			}
		}
	}
}