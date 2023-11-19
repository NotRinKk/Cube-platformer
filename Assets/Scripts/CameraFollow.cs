using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //смещение 
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ќтслежование игрока камерой + смещение (не измен€€ высоты)
        Vector3 targetPosition = player.position + offset;
        targetPosition.y = 1;
        transform.position = targetPosition;
    }
}
