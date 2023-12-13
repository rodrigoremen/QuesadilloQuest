using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LsUiManager : MonoBehaviour
{
    public static LsUiManager instance;

    public Text lNameText;

    public GameObject lNamePanel;

    public Text coinsText;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
