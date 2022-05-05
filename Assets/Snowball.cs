using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    private float speed = 10; 

    public void Throw()
    {
        this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed*this.gameObject.transform.forward;
    }
}
