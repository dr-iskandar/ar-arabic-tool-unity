using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public int question;

    public int score;
    public int addScore;

    public AudioSource quizAudio;
    public AudioClip benar, salah, hasil;

    public Text textResult;
    public GameObject result;

    public GameObject[] qElement;

    private void Update()
    {
        textResult.text = score.ToString();
    }
    public void aTrue(GameObject nextQ)
    {
        next();

        if (question < 5)
        {
            score += addScore;
            trueorfalse(true);
            nextQ.SetActive(true);
        }
        else {
            score += addScore;
            quizAudio.clip = hasil;
            nextQ.SetActive(true);
            quizAudio.Play();
        }
    }

    public void aFalse(GameObject nextQ)
    {
        next();
        if (question < 5)
        {
            trueorfalse(false);
            nextQ.SetActive(true);
        }
        else {
            quizAudio.clip = hasil;
            nextQ.SetActive(true);
            quizAudio.Play();
        }
    }

    public void home()
    {
        score = 0;
        textResult.text = "";
        for (int i = 0; i < qElement.Length; i++)
        {
            qElement[i].SetActive(false);
        }
        trueorfalse(false);
        question = 0;
    }

    public void next()
    {
        question++;
    }
    void trueorfalse(bool trues)
    {
        if (trues)
        {
            quizAudio.clip = benar;
            quizAudio.Play();
        }
        else {
            quizAudio.clip = salah;
            quizAudio.Play();
        }
    }
}
