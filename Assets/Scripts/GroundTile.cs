using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] private GameObject obstaclePrefab;
    //¬ыход за пределы плитки
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    //—павн преп€дствий на плитке
    void SpawnObstacle()
    {
        //¬ыбор случайного расположени€ (расто€ни€) преп€дстви€ на плитке
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //—павн преп€дстви€ в заданном месте
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        //
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
