using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedBehavior : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player")
        {

            PlayerBehavior Player = other.gameObject.GetComponent<PlayerBehavior>();
            Player.HealthChange(-10);

        }

    }

}
