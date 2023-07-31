using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene("Level");
    }
}
