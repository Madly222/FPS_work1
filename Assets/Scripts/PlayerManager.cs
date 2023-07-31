using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;//obligatoriu pentru schimbarea scenei
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverLay;

    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    void Update()
    {
        playerHPText.text = "+" + playerHP;

    }

    public IEnumerator TakeDamage(int damageAmount) //ienumerator e pentru curotina
    {
        bloodOverLay.SetActive(true);
        playerHP -= damageAmount;
        if(playerHP <= 0)
        {
            isGameOver = true;   
        }
        yield return new WaitForSeconds(1f);
        bloodOverLay.SetActive(false);

    }

}
