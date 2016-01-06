using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Texture backgroundTexture;
	// Use this for initialization
	void OnGUI () {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
    }
}
