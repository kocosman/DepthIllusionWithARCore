using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthIllusion_ARFace_Binder : MonoBehaviour
{
    public GameObject noseTip;
    public GameObject projectionCam;
    public GameObject faceLightFixture;
    Light faceSpotLight;
    
    void Start()
    {
        faceSpotLight = faceLightFixture.GetComponent<Light>();
    }

    void Update()
    {
        // Face space to Content space mapping
        //from
        // x: +-0.2
        // y: +-0.2
        // z: 0.2-0.5
        //to
        // x: +-4.5
        // y: +-4.5
        // z: -5 - -10

        //Debug.Log("NoseTip Pos: " + noseTip.transform.position);
        Vector3 remappedPos = new Vector3(
                                             -noseTip.transform.position.x.Remap(-0.2f, 0.2f, -4.5f, 4.5f),
                                             noseTip.transform.position.y.Remap(-0.2f, 0.2f, -4.5f, 4.5f),
                                             noseTip.transform.position.z.Remap(0.2f, 0.5f, -5.0f, -10.0f)
            );

        projectionCam.transform.position = remappedPos;
        faceLightFixture.transform.position = remappedPos;
        //faceLightFixture.transform.eulerAngles = noseTip.transform.eulerAngles;
        faceLightFixture.transform.eulerAngles = new Vector3(-noseTip.transform.eulerAngles.x, noseTip.transform.eulerAngles.y, noseTip.transform.eulerAngles.z);
        faceSpotLight.intensity = noseTip.transform.position.z.Remap(0.1f, 0.7f, 2.0f, 0.3f); // Directional Light for Mars Scene
        //faceSpotLight.intensity = 1 + noseTip.transform.position.z.Remap(0.1f, 0.7f, 3.5f, 1.0f); // Crystal Scene
    }
}
