using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    Obstacle obstacle;
    // Start is called before the first frame update
    void Start()
    {
        //����� ������� ���� PlayerMovement (��������� � Player)
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //���� ����� �������� � �����������, �� �������
        if (collision.gameObject.name == "Player")
        {
            //�������� ������
            playerMovement.Die();
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
