using System.Collections.Generic;

namespace StaticData.BallsStaticData
{
	public interface IBallsStaticData
	{
		IReadOnlyList<IReadOnlyBallData> Balls { get; }
	}
}