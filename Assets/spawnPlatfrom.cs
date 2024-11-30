using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlatfrom : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipeGO;
    [SerializeField] private float coinRange = 2f;
    [SerializeField] private GameObject CoinGO;
    private float timer;
    void Start()
    {
        SpawnPipes();
    }

    private void Update()
    {
       
        if (timer > maxTime)
        {
            SpawnPipes();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipes()
    {

        Vector3 spawePos = transform.position + new Vector3(Random.Range(-heightRange, heightRange),0 );
        GameObject pipe = Instantiate(pipeGO,spawePos,Quaternion.identity);

       
        Destroy(pipe, 10f);
        Invoke("SpawnCoin", 30);
        Destroy(CoinGO, 10f);

    }
    private void SpawnCoin()
    {
        Vector3 spaweCoinPos = transform.position + new Vector3(Random.Range(-coinRange , coinRange),0);
        Instantiate(CoinGO, spaweCoinPos, Quaternion.identity);
        
    }

       



}
