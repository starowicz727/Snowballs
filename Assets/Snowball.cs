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
        if (collision.gameObject.tag == "Destroyer" && !alreadyThrown) //gdy œnie¿ka nie by³a wystrzelona
        {                                                              //ale spad³a w przepaœæ przypadkiem 
            GameState.points -= 6;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Destroyer" && alreadyThrown) //gdy œnie¿ka spad³a w przepaœæ po wystrzale 
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Star") //gdy œnie¿ka trafi³a w gwiazdê
        {
            GameState.points += 10;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ball") //gdy œnie¿ka trafi³a w bombkê 
        {
            GameState.points += 5;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (alreadyThrown) //gdy wystrzelona œnie¿ka nie uderzy³a ani w gwiazdê ani w bombkê
        {
            GameState.points -= 6;
        }

    }
}
