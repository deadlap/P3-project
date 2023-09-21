using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour {
    static WebCamTexture camera;
    void Start() {
        if (camera == null){
            camera = new WebCamTexture();
        }
        
    }

    void Update() {
        
    }
}
