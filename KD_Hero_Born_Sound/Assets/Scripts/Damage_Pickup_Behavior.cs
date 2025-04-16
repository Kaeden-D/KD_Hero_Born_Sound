using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Pickup_Behavior : MonoBehaviour
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

            Debug.Log("Damage Increased.");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.DamageChange(1);

        }

    }

}
