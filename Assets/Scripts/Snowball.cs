using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snowball : MonoBehaviour
{
    public GameObject confetti;
    private AudioSource audioSource;

    private float speed = 40; //prêdkoœæ wyrzutu œnie¿ki
    private bool alreadyThrown; //czy dana œnie¿ka zosta³a ju¿ rzucona

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
        {   //wystrzelona œnie¿ka nie dotknê³a bombki i nie dotknê³a gwiazdy
            GameState.points += penaltyPoint;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Star") //gdy œnie¿ka trafi³a w gwiazdê
        {
            GameState.points += starPoint;

            Instantiate(confetti, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            confetti.GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ball") //gdy œnie¿ka trafi³a w bombkê 
        {
            GameState.points += ballPoint;

            Instantiate(confetti, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            confetti.GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Destroyer") //gdy œnie¿ka spad³a niewystrzelona w przepaœæ
        {
            GameState.points += penaltyPoint;
            Destroy(this.gameObject);
        }
    }

}
