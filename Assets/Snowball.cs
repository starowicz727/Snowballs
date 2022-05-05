using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    private float speed = 10;
    private bool alreadyThrown;
    private float timer;
    private void Start()
    {
        alreadyThrown = false;
        timer = 0f;
    }
    private void Update()
    {
        if (alreadyThrown)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void Throw()
    {
        alreadyThrown = true;
        this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed * this.gameObject.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Star")
        {
            GameState.points += 10;
        }
        else if (collision.gameObject.tag == "Ball")
        {
            GameState.points += 5;
        }
        else if (alreadyThrown)
        {
            GameState.points -= 6;
        }

    }
}
