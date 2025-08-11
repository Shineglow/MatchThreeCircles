namespace StaticData.Levels
{
	public interface IReadOnlyLevelRules
	{
		float IdleThreshold { get; }
		float IdleTimeToSettle { get; }
		float LoseLineY { get; }
	}
}