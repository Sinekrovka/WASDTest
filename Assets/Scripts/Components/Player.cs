using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int lifes;

    private void Start()
    {
        UIController.Instance.UpdateLifes(lifes);
    }

    private void OnTriggerEnter(Collider other)
    {
        lifes--;
        UIController.Instance.UpdateLifes(lifes);
        if (lifes <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
