using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayNight : MonoBehaviour
{
    public Light2D sun;
    public Light2D flash;
    public Text time;
    public Text daysAliveText;
    public int daysAlive = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sunset());
    }

    IEnumerator Sunset()
    {
        while(sun.intensity > 0.4f)
        {
            sun.intensity -= 0.0005f;
            flash.intensity += 0.0005f;

            //World Time UI
            if (sun.intensity > 0.8f)
            {
                time.text = "Daytime";
            }
            else if (sun.intensity > 0.6f)
            {
                time.text = "Sunset";
            }
            else
            {
                time.text = "Night";
            }

            yield return new WaitForSeconds(0.1f);
        }

        //increment the days the player has been alive by checking for the end of a day cycle
        daysAlive += 1;

        //update the text to show the days the player has been alive for
        daysAliveText.text = "Days: " + daysAlive;

        StartCoroutine(Sunrise());
        StopCoroutine(Sunset());
    }

    IEnumerator Sunrise()
    {
        while (sun.intensity < 1f)
        {
            sun.intensity += 0.0005f;
            flash.intensity -= 0.0005f;

            //World Time UI
            if (sun.intensity < 0.55f)
            {
                time.text = "Early Morning";
            }
            else if (sun.intensity < 0.65f)
            {
                time.text = "Sunrise";
            }
            else
            {
                time.text = "Daytime";
            }

            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(Sunset());
        StopCoroutine(Sunrise());
    }
}
