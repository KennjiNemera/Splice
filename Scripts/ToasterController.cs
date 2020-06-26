using System.Threading;
using UnityEngine;

public class ToasterController : MonoBehaviour
{
    public bool isToasting = false;
    public Animator animator;
    public GameObject toastedBread;
    public GameObject BreadBtn;
    public int targetTime;

    public void toastTime()
    {
        if (targetTime > 0)
        {
            targetTime -= 1;
            
            if (targetTime == 0)
            {
                timerEnded();
            }
        }
    }
    public void ToastBread()
    {
        //resets everytime we try to toast some bread
        targetTime = 30;
        Debug.Log("Target time is 30s");
        isToasting = false;

        if (targetTime > 0)
        {            
            if (!isToasting)
            {
                isToasting = true;
                Debug.Log("Is Toasting Some Crumbs");
            }

            animator.SetBool("isToasting", isToasting);
            InvokeRepeating("toastTime", 1.0f, 1.0f);
        }
    }

    public void timerEnded()
    {
        //Will spawn the toasted bread above the toaster

        Vector2 toastedPos = new Vector2(transform.position.x - 1, transform.position.y + 3);
        Vector2 toastedPos2 = new Vector2(transform.position.x + 1, transform.position.y + 3);
        Instantiate(toastedBread, toastedPos, Quaternion.identity);
        Instantiate(toastedBread, toastedPos2, Quaternion.identity);
        Debug.Log("Done toasting yay");
    }
}
