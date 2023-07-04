using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int totalCoins = 0;
    [SerializeField] TextMeshProUGUI CoinCount;
    [SerializeField] AudioSource CoinSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Coin")
        {
            Destroy(other.gameObject);
            totalCoins++;
            CoinCount.text = totalCoins.ToString();
            CoinSound.Play();
        }
    }
}
