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
        //���� ����� ����, �������� �������� ������
        if (!alive)
        {
            return;
        }

        Vector3 forwardXMovement = transform.forward * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardXMovement);//������� �������������� + ���������
    }

    private void Jump()
    {
        //�������� ���������� �� ����� (���������� ������� � �������)
        float hiegth = GetComponent<Collider>().bounds.size.y;
        bool grounded = Physics.Raycast(transform.position, Vector3.down, (hiegth / 2) + 0.1f, groundMask);

        //���������� ������, ���� ����� ���������� �� �����
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void Die()
    {
        alive = false;
        //�������� ����� ������������ (3 �������)
        gameOverText.text = "Game Over!";//
        Invoke("Restart", 3);
    }
    private IEnumerator SomeMethodEnumerator()
    {
        //����� ������� Game Over
        yield return new WaitForSeconds(3f); // ���� 3 �������.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Restart()
    {
        //���������� ���� (�������� ������� �����)
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
