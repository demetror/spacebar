using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GUIText text;
    public int score;

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void  incScore(int add) {
        score = score + add;
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = "Score :" + score;
    }

}
