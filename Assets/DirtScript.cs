using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject[] dirts = GameObject.FindGameObjectsWithTag("Dirt");
        if (dirts.Length == 1)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("gameOver");
        }

        Destroy(gameObject);
    }
}
