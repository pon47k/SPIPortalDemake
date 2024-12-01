using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePicker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool isHeld = false;  // Флаг, показывающий, захвачен ли куб
    [SerializeField] private Transform player;  // Ссылка на игрока
    public float holdDistance = 1.0f;  // Расстояние, на котором куб должен быть относительно игрока при захвате
    public float throwForce = 10.0f;


    void Update()
    {
        if (isHeld)
        {
            // Куб следит за игроком на заданном расстоянии
            Vector2 targetPosition = (Vector2)player.position + (Vector2.up) * holdDistance;
            rb.position = Vector2.Lerp(rb.position, targetPosition, Time.deltaTime * 10f);
            rb.velocity = Vector2.zero;  // Останавливаем движение куба, когда он захвачен
        }

        if (Input.GetKeyDown(KeyCode.E))  // Кнопка для захвата / отпускания
        {
            if (isHeld)
            {
                ReleaseCube();
            }
            else
            {
                TryPickUpCube();
            }
        }
    }

    void TryPickUpCube()
    {
        // Проверка на близость игрока к кубу
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= holdDistance)
        {
            isHeld = true;
            rb.isKinematic = true;  
            GetComponent<Collider2D>().enabled = false;// Делаем куб кинематическим, чтобы он не реагировал на физику
        }
    }

    void ReleaseCube()
    {
        isHeld = false;
        rb.isKinematic = false;  // Включаем физику обратно
        rb.velocity = player.GetComponent<Rigidbody2D>().velocity;  // Можно добавить начальную скорость, если нужно
        GetComponent<Collider2D>().enabled = true;// Делаем куб кинематическим, чтобы он не реагировал на физику
    }

    public void ThrowCube(Vector2 direction)
    {
        if (isHeld)
        {
            ReleaseCube();
            rb.AddForce(direction * throwForce, ForceMode2D.Impulse);
        }
    }
}
