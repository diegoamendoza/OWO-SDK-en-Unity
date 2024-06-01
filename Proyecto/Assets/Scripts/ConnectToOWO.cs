using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OWOGame;
public class ConnectToOWO : MonoBehaviour
{
   
    void Awake()
    {
        OWO.AutoConnect();   
    }
}
