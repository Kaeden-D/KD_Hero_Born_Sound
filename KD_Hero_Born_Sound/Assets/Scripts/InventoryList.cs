using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList<T> where T: class
{

    private T _item;
    public T item
    {

        get { return _item; }

    }

    public InventoryList()
    {

        Debug.Log("Generic list initalized...");

    }

    public void SetItem(T newItem)
    {

        _item = newItem;
        Debug.Log("New item added...");

    }

}

/*
public class InventoryList : MonoBehaviour
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