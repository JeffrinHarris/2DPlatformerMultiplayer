using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTransform;
    public float offsetY;

    public Transform parentObject;

    private Transform _transform;
    
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y + offsetY, this.transform.position.z);
        //copy gameobject position
        // parentObject.position = prefab.transform.position;
        if(GameObject.Find("LocalPlayer"))
        {
            _transform = GameObject.Find("LocalPlayer").transform;
            parentObject.position = _transform.position;
        }
        
    }
}
