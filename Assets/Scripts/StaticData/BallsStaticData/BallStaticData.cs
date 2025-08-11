using System.Collections.Generic;
using UnityEngine;

namespace StaticData.BallsStaticData
{
	[CreateAssetMenu(menuName = "StaticData/Create BallStaticData", fileName = "BallStaticData", order = 0)]
	public class BallStaticData : ScriptableObject, IBallsStaticData
	{
		public List<BallData> BallsStaticData;
		public IReadOnlyList<IReadOnlyBallData> Balls => BallsStaticData;
	}
}