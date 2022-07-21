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

    public bool IsPickUpAble { get; set; } = true;
}

public interface IPickUpAble
{
    public bool IsPickUpAble { get; set; }
}