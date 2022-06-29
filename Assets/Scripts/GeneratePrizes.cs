using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrizes : MonoBehaviour
{
    public GameObject ball;
    public GameObject star;
    private float ballInstantiateT; //po jakim czasie ma nast�pi� kolejne Instantiate
    private float ballInstantiateTimer = 0f;//odliczanie czasu do nast�pnego u�ycia Instantiate
    private float starInstantiateT;
    private float starInstantiateTimer = 0f;

    private float randomX=0, randomY=0, randomZ=0;

    private float starMinTime, starMaxTime, ballMinTime, ballMaxTime;

    private void Start()
    {
        starMinTime = 10f; starMaxTime = 15f;
        ballMinTime = 2f; ballMaxTime = 6f;

        starInstantiateT = Random.Range(starMinTime, starMaxTime);
        ballInstantiateT = Random.Range(ballMinTime, ballMaxTime);
    }

    private void Update()
    {
        if(!GameState.endOfGame)//je�eli gra si� jeszcze nie sko�czy�a
        {
            //odmierzanie kolejnego Instantiate dla gwiazdy
            starInstantiateTimer += Time.deltaTime;
            if (starInstantiateTimer >= starInstantiateT)
            {
                RandomPosition();
                Instantiate(star, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
                starInstantiateT = Random.Range(starMinTime, starMaxTime);
                starInstantiateTimer = 0f;
            }

            //odmierzanie kolejnego Instantiate dla bombki 
            ballInstantiateTimer += Time.deltaTime;
            if (ballInstantiateTimer >= ballInstantiateT)
            {
                RandomPosition();
                Instantiate(ball, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
                ballInstantiateT = Random.Range(ballMinTime, ballMaxTime);
                ballInstantiateTimer = 0f;
            }
        }
    }

    private void RandomPosition() //metoda losuje X,Y i Z, u�ywane do tworzenia Vector3 dla Instantiate
    {
        randomY = Random.Range(0.7f, 2.5f);

        int randomXorZ = Random.Range(0, 2);
        if (randomXorZ == 0)
        {
            int randomSide = Random.Range(0, 2); //je�li wypadnie 0 to losujemy X po stronie prawej od gracza
            if (randomSide == 0)
            {
                randomX = -Random.Range(1.6f, 2.6f);
            }
            else
            {
                randomX = Random.Range(2.6f, 3.6f);
            }
            randomZ = Random.Range(0f, 8f);
        }
        else
        {
            int randomSide = Random.Range(0, 2); //je�li wypadnie 0 to losujemy Z za graczem
            if (randomSide == 0)
            {
                randomZ = -Random.Range(0f, 1.6f);
            }
            else
            {
                randomZ = Random.Range(7f, 8.6f);
            }
            randomX = Random.Range(0f, 4f);
        }

    }

}
