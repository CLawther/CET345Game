using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float xOffset, yOffset, zOffset;
    // Update is called once per frame
    void Update()
    {
        //Setting camera position to be eqaul to Player's postion added by the offset of each axis 
        transform.position = Target.transform.position + new Vector3(xOffset, yOffset, zOffset);
        //Setting camera to look at Player's position 
        transform.LookAt(Target.transform.position);
    }
}
