using UnityEngine;

public class DestroyAtRandomTime : MonoBehaviour
{
    public GameObject sadConfetti;

    public int minTime, maxTime;
    private float destroyT = 0f; //po jakim czasie ma nast�pi� usuni�cie obiektu
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
            Instantiate(sadConfetti, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            sadConfetti.GetComponent<AudioSource>().Play();

            Destroy(this.gameObject);
        }
    }
}
