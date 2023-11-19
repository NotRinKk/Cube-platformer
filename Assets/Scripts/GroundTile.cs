using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] private GameObject obstaclePrefab;
    //����� �� ������� ������
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    //����� ����������� �� ������
    void SpawnObstacle()
    {
        //����� ���������� ������������ (���������) ����������� �� ������
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //����� ����������� � �������� �����
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
