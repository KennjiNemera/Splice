using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public bool isSelling;
    public int minMoney = 0;
    public float currentHealth;
    private float coef = 0.1f;
    public HealthBar healthBar;
    public GameObject toastedBread;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isSelling)
        {
            TakeDamage();
            Debug.Log(currentHealth);
        }
        else if (currentHealth < 20f)
        {
            GainHealth();
            isSelling = false;
        } else
        {
            TakeDamage();
        }

        if (currentHealth == 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void setSelling()
    {
        Debug.Log("you have sold bread");
        isSelling = true;
        GainHealth();
    }

    void TakeDamage()
    {
        currentHealth -= coef * Time.deltaTime;

        healthBar.setHealth((int)currentHealth);

        
    }

    void Debugger()
    {
        Debug.Log("Button has been pressed");
    }

    public void GainHealth()
    {
        Debug.Log("You have gained health");

        currentHealth += 3;

        healthBar.setHealth((int)currentHealth);
    }
}
