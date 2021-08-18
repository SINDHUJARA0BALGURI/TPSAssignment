using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningScore : MonoBehaviour
{
    public Text lastScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastScore.text = "Score: " + PlayerMovement.instance.score;
    }
}
