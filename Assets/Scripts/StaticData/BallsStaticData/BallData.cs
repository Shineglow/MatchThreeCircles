using System;
using Infrastructure.Factories.BallsFactory;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.BallsStaticData
{
	[Serializable]
	public class BallData : IReadOnlyBallData
	{
		[field: SerializeField] public EBallId BallId { get; set; }
		[field: SerializeField] public AssetReference Sprite { get; set; }
	}
}