using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehavior : MonoBehaviour
{

    public GameObject gameObject;

    public void DestroyDrone()
    {

        Destroy(gameObject);

    }

}
