using UnityEngine;
using System.Collections;

public class VideoCaptureExample : MonoBehaviour {
    public void Start() {
        WebCamTexture webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}