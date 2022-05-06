using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    private float speed = 20; //pr�dko�� wyrzutu �nie�ki
    private bool alreadyThrown; //czy dana �nie�ka zosta�a ju� rzucona
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
        {   //wystrzelona �nie�ka nie dotkn�a bombki i nie dotkn�a gwiazdy
            GameState.points -= 6;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Star") //gdy �nie�ka trafi�a w gwiazd�
        {
            GameState.points += 10;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ball") //gdy �nie�ka trafi�a w bombk� 
        {
            GameState.points += 5;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Destroyer") //gdy �nie�ka spad�a niewystrzelona w przepa��
        {
            GameState.points -= 6;
            Destroy(this.gameObject);
        }
    }
}
