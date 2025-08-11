using UnityEngine;

namespace StaticData.Levels
{
	public interface IReadOnlyLevelInfo
	{
		string Name { get; }
		IReadOnlyLevelRules LevelRules { get; }
		Vector3 PendulumPosition { get; }
	}
}