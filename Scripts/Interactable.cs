using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public Button click;
    public UnityEvent interactAction;

    // Update is called once per frame

    void Update()
    { 
        Button btn = click.GetComponent<Button>();     
        
        if (isInRange)
        {            
            btn.onClick.AddListener(invokeAction);
        }
    }

    void invokeAction()
    {
        Debug.Log("Button was clicked");
        interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Is not in Range");
        }
    }
}
