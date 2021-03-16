using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] GameObject explotionPrefab;
    [SerializeField] GameObject[] powerUpsPrefabs;
    [SerializeField] int powerUpChance = 20;
    bool isQuitting;



        private void Start()
    {
        //gameManagerObj = GameObject.Find("GameManager");
        //gameManager = gameManagerObj.GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.BricksOnLevel++;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager != null)
        {
            gameManager.BricksOnLevel--;

        }
        Instantiate(explotionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if(isQuitting)
            return;

        if (gameManager.powerUpOnscene)
            return;

        int possibility = Random.Range(0, 100);

        if(possibility < powerUpChance)
        {
            int randomPoweUp = Random.Range(0, powerUpsPrefabs.Length);
            Instantiate(powerUpsPrefabs[randomPoweUp], transform.position, Quaternion.identity);
            gameManager.powerUpOnscene = true;
        }
   
    }
}
