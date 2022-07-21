using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MonoBehaviour, IPickUpAble
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Transform IPickUpAble.Transform {
    //    get { return transform; }
    //    set { transform = value; }
    //}
    
}

public interface IPickUpAble
{
    //Transform Transform { get; set; }
}