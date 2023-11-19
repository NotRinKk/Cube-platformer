using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5;
    public Rigidbody rb;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask groundMask;

    public TextMeshProUGUI gameOverText;//

    bool alive = true;

    private void FixedUpdate()
    {
        //Если игрок умер, завршить движение игрока
        if (!alive)
        {
            return;
        }

        Vector3 forwardXMovement = transform.forward * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardXMovement);//Текущее местоположение + следующее
    }

    private void Jump()
    {
        //Проверка нахождения на земле (исключение прыжков в воздухе)
        float hiegth = GetComponent<Collider>().bounds.size.y;
        bool grounded = Physics.Raycast(transform.position, Vector3.down, (hiegth / 2) + 0.1f, groundMask);

        //Выполнение прыжка, если игрок находиться на земле
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void Die()
    {
        alive = false;
        //Ожидание перед перезапуском (3 секунды)
        gameOverText.text = "Game Over!";//
        Invoke("Restart", 3);
    }
    private IEnumerator SomeMethodEnumerator()
    {
        //Вывод надписи Game Over
        yield return new WaitForSeconds(3f); // Ждем 3 секунды.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Restart()
    {
        //Перезапуск игры (загрузка текущей сцены)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //StartCoroutine(SomeMethodEnumerator());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
