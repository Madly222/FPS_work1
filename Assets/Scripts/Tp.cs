using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public Vector3 Teleport_Point;

    void OnTriggerStay(Collider other)
    {
        other.transform.position = Teleport_Point;
    }
}
