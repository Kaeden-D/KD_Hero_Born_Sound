using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomExtensionsBehavior
{

    public static class StringExtensions
    {

        public static void FancyDebug(this string str)
        {

            Debug.LogFormat("This string contains {0} characters.", str.Length);

        }

    }

}

/*
public class CustomeExtensionsBehvaior : MonoBehaviour
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