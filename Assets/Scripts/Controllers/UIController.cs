using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateLifes(int lifeCount)
    {
        _textMeshPro.text = lifeCount.ToString();
    }
}
