using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<GameObject> listOfSnowballs;
    public static int points;
    public static bool endOfGame;

    private void Start()
    {
        points = 0;
        endOfGame = false;
    }

    private void Update()
    {
        DeleteDestroyedSnowballs(); //pomniejszanie listy o te œnie¿ki,
                                    // które zosta³y zniszczone
        if (listOfSnowballs.Count == 0)
        {
            endOfGame = true;
            listOfSnowballs.Add(new GameObject());
        }
    }

    private void DeleteDestroyedSnowballs()
    {
        for (int i = 0; i < listOfSnowballs.Count; i++)
        {
            if (listOfSnowballs[i] == null)
            {
                listOfSnowballs.RemoveAt(i);
            }
        }
    }
}
