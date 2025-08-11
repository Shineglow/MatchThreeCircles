using Infrastructure.Factories.BallsFactory;
using UnityEngine.AddressableAssets;

namespace StaticData.BallsStaticData
{
	public interface IReadOnlyBallData
	{
		EBallId BallId { get; }
		AssetReference Sprite { get; }
	}
}