using System;
using UnityEngine;

namespace Infrastructure.ObjectsPool
{
	public class ObjectDisableListener : MonoBehaviour
	{
		public event Action<ObjectDisableListener> Disabled;
		
		private void OnDisable()
		{
			Disabled?.Invoke(this);
		}
	}
}