using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadItem : MonoBehaviour
{
    private Transform player;
    public int minMoney = 0;
    public int currentMoney;
    public Text money;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Use()
    {
        Destroy(gameObject);
    }

    public void Sell()
    {
        currentMoney += 100;
        money.text = currentMoney.ToString();
    }
}
