using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotationsPerMinute = 80f;
    void Update()
    {
        transform.Rotate(0, rotationsPerMinute * Time.deltaTime, 0);
    }
}
