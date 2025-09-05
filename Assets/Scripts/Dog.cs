using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject food;

    private void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // x 값을 -8.5 ~ 8.5로 제한
        float clampedX = Mathf.Clamp(mousePos.x, -8.5f, 8.5f);

        // 제한된 x 값을 사용해 위치 설정
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    private void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
