using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtRandomTime : MonoBehaviour
{
    public int minTime, maxTime;
    private float destroyT; //po jakim czasie ma nast�pi� usuni�cie obiektu
    private float destroyTimer = 0f;//odliczanie czasu do usuni�cia
    void Start()
    {
        destroyT = Random.Range(minTime, maxTime+1);
    }

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if(destroyTimer >= destroyT)
        {
            Destroy(this.gameObject);
        }
    }
}
