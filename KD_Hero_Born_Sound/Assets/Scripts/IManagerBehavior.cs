using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagerBehavior
{

    string State { get; set; }


    void Initialize();

}

/*
public class IManagerBehavior : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
*/