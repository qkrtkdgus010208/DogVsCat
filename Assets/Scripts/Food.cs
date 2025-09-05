using UnityEngine;

public class Food : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.up * 0.5f;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
