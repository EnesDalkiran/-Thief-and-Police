using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policecar : MonoBehaviour
{

    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Police")
        {
            gameManager.car();

        }
    }

}
