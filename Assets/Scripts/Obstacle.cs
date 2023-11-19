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
        //Посик объекта типа PlayerMovement (прикреплён к Player)
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Если игрок врезался в препядствие, он умирает
        if (collision.gameObject.name == "Player")
        {
            //Убийство игрока
            playerMovement.Die();
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
