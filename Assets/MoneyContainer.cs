using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyContainer : MonoBehaviour
{
    private CoinPickup CP;
    public AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {
        CP = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinPickup>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSystem.PlaySoundEffect(coinSound);
            CP.AmountOfMoney = CP.AmountOfMoney + 50;
            Destroy(this.gameObject);
        }
    }

}
