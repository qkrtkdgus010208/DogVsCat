using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] RectTransform front;
    [SerializeField] GameObject hungryCat;
    [SerializeField] GameObject fullCat;

    private float full = 5.0f;
    private float energy = 0.0f;

    private void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;

        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * 0.05f;
        }
        else
        {
            transform.position += transform.position.x > 0 ? Vector3.right * 0.05f : Vector3.left * 0.05f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);

                if (energy == full)
                {
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                }
            }
        }
    }
}
