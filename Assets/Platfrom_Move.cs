using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfrom_Move : MonoBehaviour
{
     public  float speed = 1f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        speed += 0.01f;
        print(speed);
        Destroy(gameObject,10f);
    }
}
