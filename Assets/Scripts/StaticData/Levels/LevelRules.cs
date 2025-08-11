using System;
using UnityEngine;

namespace StaticData.Levels
{
	[Serializable]
	public class LevelRules : IReadOnlyLevelRules
	{
		[field: SerializeField] public float IdleThreshold { get; set; } = 0.05f;
		[field: SerializeField] public float IdleTimeToSettle { get; set; } = 0.8f;
		[field: SerializeField] public float LoseLineY { get; set; } = 5f;
	}
}