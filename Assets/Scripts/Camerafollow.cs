using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    [SerializeField]
    GameObject camtarget;
    [SerializeField]
    GameObject police;

    void Update()
    {
        transform.position = camtarget.transform.position;
        transform.LookAt(police.transform.position);
    }
}
