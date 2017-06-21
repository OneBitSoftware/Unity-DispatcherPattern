using UnityEngine;
using UnityEngine.UI;

public class FrameTicker : MonoBehaviour {

    public Text FrameValue;

	void Update () {
        FrameValue.text = Time.frameCount.ToString();
	}
}
