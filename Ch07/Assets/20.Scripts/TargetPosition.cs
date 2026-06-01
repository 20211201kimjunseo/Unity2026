using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public float size = 1f;
    public Color color = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);
    }
}
