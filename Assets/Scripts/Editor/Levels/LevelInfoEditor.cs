using StaticData.Levels;
using StaticData.Levels.Utils.Markers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor.Levels
{
	[CustomEditor(typeof(LevelInfo))]
	public class LevelInfoEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			
			LevelInfo levelInfo = (LevelInfo)target;

			if (GUILayout.Button("Extract level info"))
			{
				levelInfo.LevelRulesSetter ??= new LevelRules();
				
				levelInfo.PendulumPosition = FindObjectOfType<PendulumMarker>().transform.position;
				var deadZone = GameObject.FindWithTag("DeadZone");
				var transform = deadZone.transform;
				levelInfo.LevelRulesSetter.LoseLineY = transform.position.y;
			}
		}
	}
}