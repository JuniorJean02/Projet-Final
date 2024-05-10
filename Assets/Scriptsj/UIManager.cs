using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text currentPlayerExpTxt;
    // private PlayerStats playerStats = PlayerStats.Instance;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerExpTxt.text = PlayerStats.Instance.experience.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Instance.experience.ToString() != currentPlayerExpTxt.text)
        {
            currentPlayerExpTxt.text = PlayerStats.Instance.experience.ToString();
        }
    }
}
