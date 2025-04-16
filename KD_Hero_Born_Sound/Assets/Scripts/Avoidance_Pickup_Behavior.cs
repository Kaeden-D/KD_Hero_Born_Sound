using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance_Pickup_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player")
        {

            Debug.Log("Enemies Repelled for x Seconds.");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            if (Player.Avoid)
            {

                Player.AvoidRestart = true;

            }
            else
            {

                Player.AvoidStart(5f);

            }

        }

    }

}
