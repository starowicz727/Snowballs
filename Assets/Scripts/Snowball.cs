using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    public GameObject confetti;
    private AudioSource audioSource;

    private float speed = 40; //pr�dko�� wyrzutu �nie�ki
    private bool alreadyThrown; //czy dana �nie�ka zosta�a ju� rzucona

    private int starPoint = 10;
    private int ballPoint = 5;
    private int penaltyPoint = -5;
    private void Start()
    {
        alreadyThrown = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    public void Throw()
    {
        audioSource.Play();

        alreadyThrown = true;
        this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = speed * this.gameObject.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( alreadyThrown && (collision.gameObject.tag != "Ball" && collision.gameObject.tag != "Star"))
        {   //wystrzelona �nie�ka nie dotkn�a bombki i nie dotkn�a gwiazdy
            GameState.points += penaltyPoint;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Star") //gdy �nie�ka trafi�a w gwiazd�
        {
            GameState.points += starPoint;

            Instantiate(confetti, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            confetti.GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ball") //gdy �nie�ka trafi�a w bombk� 
        {
            GameState.points += ballPoint;

            Instantiate(confetti, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            confetti.GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Destroyer") //gdy �nie�ka spad�a niewystrzelona w przepa��
        {
            GameState.points += penaltyPoint;
            Destroy(this.gameObject);
        }
    }

}
