using UnityEngine;

namespace Editor.ConfigurationSupport
{
    public class DeadZoneDrawer : MonoBehaviour
    {
        [SerializeField] private float lineWidth = 5f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Vector3 start = transform.position - new Vector3(lineWidth / 2, 0, 0);
            Vector3 end = transform.position + new Vector3(lineWidth / 2, 0, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}