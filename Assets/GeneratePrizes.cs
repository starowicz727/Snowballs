using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrizes : MonoBehaviour
{
    public GameObject ball;
    public GameObject star;
    private float ballInstantiateT; //po jakim czasie ma nast¹piæ kolejne Instantiate
    private float ballInstantiateTimer = 0f;//odliczanie czasu do nastêpnego u¿ycia Instantiate
    private float starInstantiateT;
    private float starInstantiateTimer = 0f;

    private float randomX=0, randomY=0, randomZ=0;

    private void Start()
    {
        starInstantiateT = Random.RandomRange(10, 15);
        ballInstantiateT = Random.RandomRange(4, 8);
    }

    private void Update()
    {
        if(!GameState.endOfGame)//je¿eli gra siê jeszcze nie skoñczy³a
        {
            //odmierzanie kolejnego Instantiate dla gwiazdy
            starInstantiateTimer += Time.deltaTime;
            if (starInstantiateTimer >= starInstantiateT)
            {
                RandomPosition();
                Instantiate(star, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
                starInstantiateT = Random.RandomRange(10, 15);
                starInstantiateTimer = 0f;
            }

            //odmierzanie kolejnego Instantiate dla bombki 
            ballInstantiateTimer += Time.deltaTime;
            if (ballInstantiateTimer >= ballInstantiateT)
            {
                RandomPosition();
                Instantiate(ball, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
                ballInstantiateT = Random.RandomRange(4, 8);
                ballInstantiateTimer = 0f;
            }
        }
    }

    private void RandomPosition() //metoda losuje X,Y i Z, u¿ywane do tworzenia Vector3 dla Instantiate
    {
        randomY = Random.RandomRange(0.7f, 2.5f);

        int randomXorZ = Random.RandomRange(0, 2);
        if (randomXorZ == 0)
        {
            int randomSide = Random.RandomRange(0, 2); //jeœli wypadnie 0 to losujemy X po stronie prawej od gracza
            if (randomSide == 0)
            {
                randomX = -Random.RandomRange(1.6f, 2.6f);
            }
            else
            {
                randomX = Random.RandomRange(2.6f, 3.6f);
            }
            randomZ = Random.RandomRange(0f, 8f);
        }
        else
        {
            int randomSide = Random.RandomRange(0, 2); //jeœli wypadnie 0 to losujemy Z za graczem
            if (randomSide == 0)
            {
                randomZ = -Random.RandomRange(0f, 1.6f);
            }
            else
            {
                randomZ = Random.RandomRange(7f, 8.6f);
            }
            randomX = Random.RandomRange(0f, 4f);
        }

    }

}
