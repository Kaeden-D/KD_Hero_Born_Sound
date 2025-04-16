using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pickup_Behavior : MonoBehaviour
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

            Debug.Log("Health Increased.");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.HealthChange(1);

        }

    }

}
