using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0, 0, -10);
    [SerializeField] float smoothing = 2f;
    Transform t;
    // Start is called before the first frame update

    void Awake()
    {
        t = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + defaultDistance;
        t.position = Vector3.Lerp(t.position, targetCamPos, smoothing * Time.deltaTime);
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
