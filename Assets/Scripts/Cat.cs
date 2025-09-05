using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] GameObject hungryCat;
    [SerializeField] GameObject fullCat;
    [SerializeField] RectTransform front;
    [SerializeField] int type;

    private float full;
    private float energy;
    private bool isFull;
    private float speed;

    private void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;

        transform.position = new Vector2(x, y);

        if (type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
    }

    private void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * speed;

            if (transform.position.y < -16.0f)
                GameManager.Instance.GameOver();
        }
        else
        {
            transform.position += transform.position.x > 0 ? Vector3.right * speed : Vector3.left * speed;
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
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager.Instance.AddScore();
                    }
                }
            }
        }
    }
}
