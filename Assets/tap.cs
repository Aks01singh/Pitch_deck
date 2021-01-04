using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class tap : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    public GameObject arsessionorigin;
    
    [SerializeField] ARRaycast​Manager raycastManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                arsessionorigin.GetComponent<ARPlaneManager>().enabled = false;
            }
            // else
            //    spawnedObject.transform.position = hitPose.position;

        }
    }
}
