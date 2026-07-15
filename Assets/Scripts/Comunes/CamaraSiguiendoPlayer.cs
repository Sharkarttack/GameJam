using UnityEngine;

public class CamaraSiguiendoPlayer : MonoBehaviour
{
    public Transform target;          // Personaje
    public float smoothTime = 0.2f;   // Cuanto mayor, más retraso
    public Vector3 offset = new Vector3(0, 0, -10);

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}
