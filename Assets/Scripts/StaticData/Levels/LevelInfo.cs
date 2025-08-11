using UnityEngine;

namespace StaticData.Levels
{
	[CreateAssetMenu(menuName = "StaticData/Create LevelInfo", fileName = "LevelInfo")]
	public class LevelInfo : ScriptableObject, IReadOnlyLevelInfo
	{
		[field: SerializeField] public string Name { get; set; }
		public LevelRules LevelRulesSetter;
		public IReadOnlyLevelRules LevelRules => LevelRulesSetter;
		[field: SerializeField] public Vector3 PendulumPosition { get; set; }
	}
}