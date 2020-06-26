using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text fpsText;

    void FixedUpdate()
    {
        float fps = Time.frameCount / Time.time;
        fpsText.text = fps.ToString("F0") + "FPS";
    }
}
