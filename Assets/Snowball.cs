using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    private float speed = 20; //prêdkoœæ wyrzutu œnie¿ki
    private bool alreadyThrown; //czy dana œnie¿ka zosta³a ju¿ rzucona
    private void Start()
    {
        alreadyThrown = false;
    }
    
    public void Throw()
    {
        alreadyThrown = true;
        this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed * this.gameObject.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( alreadyThrown && (collision.gameObject.tag != "Ball" && collision.gameObject.tag != "Star"))
        {   //wystrzelona œnie¿ka nie dotknê³a bombki i nie dotknê³a gwiazdy
            GameState.points -= 6;
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
        else if (collision.gameObject.tag == "Destroyer") //gdy œnie¿ka spad³a niewystrzelona w przepaœæ
        {
            GameState.points -= 6;
            Destroy(this.gameObject);
        }
    }
}
