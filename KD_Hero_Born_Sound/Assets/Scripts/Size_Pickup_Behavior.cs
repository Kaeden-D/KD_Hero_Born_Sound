using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size_Pickup_Behavior : MonoBehaviour
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

            float change = Random.Range(75, 125) / 100f;

            Debug.Log("Size Changed to " + change);

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.SizeChange(change);

        }

    }

}
