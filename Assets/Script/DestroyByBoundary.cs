using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other) //当物体出来这个界限以后销毁
    {
        Destroy(other.gameObject);
    }
}
