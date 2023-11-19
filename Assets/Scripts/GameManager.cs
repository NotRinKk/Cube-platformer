using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _offset;

    PlayerMovement playerMovement;
    Obstacle obstacle;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    string scoreCheck = "Score: ";

    public static GameManager inst;

    private void Awake()
    {
        inst = this;
    }
    public void Update()
    {
        transform.position = _target.position - new Vector3(-_offset, 0f, 0f);
    }
    //Изменение текста счёта
    public void IncrementScore()
    {
        //Debug.Log(score);
        score++;
        scoreText.text = "SCORE: " + score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle"))
        {
            return;
        }
        IncrementScore();
    }
    void Check()
    {
        /*//Проверка успешного прохождения препятствия
        if ((obstacle.gameObject.transform.position.x + 0.7f) < (playerMovement.gameObject.transform.position.x - 1f))
        {
            //Увеличение счёта
            GameManager.inst.IncrementScore();
        }*/
        /*if ((obstacleTransform.position.x + obstacleWidthDelta) < (cubeTransform.position.x - cubeWidthDelta))
        {
            score += 1;
            textComponent.text = score.ToString();
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
