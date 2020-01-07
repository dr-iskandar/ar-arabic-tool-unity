using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public bool mute;

    public float scalingSpeed = 0.03f;
    public float rotationSpeed = 70.0f;

    public GameObject Information;
    public GameObject[] Tools;

    public bool rotDown, rotUp, rotRight, rotLeft, scaleUp, scaleDown;

    public Text infoText;
    public AudioSource bunyiAudio;
    public AudioSource infoAudio;
    public AudioSource buttonAudio;

    public AudioClip tap, close;

    private void Update()
    {
        if (rotDown!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (rotUp!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (rotRight!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            }
        }

        if (rotLeft!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }

        if (scaleUp!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
            }
        }

        if (scaleDown!=false)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].transform.localScale -= new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
            }
        }
    }
    public void RotationDown(bool aktif)
    {
        audioClick();
        rotDown = aktif;
    }

    public void RotationUp(bool aktif)
    {
        audioClick();
        rotUp = aktif;
    }

    public void RotationRight(bool aktif)
    {
        audioClick();
        rotRight = aktif;
    }

    public void RotationLeft(bool aktif)
    {
        audioClick();
        rotLeft = aktif;
    }

    public void ScaleUp(bool aktif)
    {
        audioClick();
        scaleUp = aktif;
    }

    public void ScaleDown(bool aktif)
    {
        audioClick();
        scaleDown = aktif;
    }

    public void Refresh()
    {
        audioClick();
        for (int i = 0; i < Tools.Length; i++)
        {
            Tools[i].transform.localScale = new Vector3(1, 1, 1);
            Tools[i].transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void changeScene(string sceneName)
    {
        audioClick();
        SceneManager.LoadScene(sceneName);
    }

    public void showInfo()
    {
        if (!infoAudio.isPlaying)
        {
            audioClick();
            Information.SetActive(true);
            infoAudio.Play();
        }
    }

    public void muteAudio()
    {
        audioClick();
        if (mute != true)
        {
            bunyiAudio.Pause();
            mute = true;
        }
        else {
            bunyiAudio.Play();
            mute = false;
        }
    }

    public void closeInfo()
    {
        audioClose();
        infoAudio.Stop();
    }

    void audioClick()
    {
        buttonAudio.clip = tap;
        buttonAudio.Play();
    }

    void audioClose()
    {
        buttonAudio.clip = close;
        buttonAudio.Play();
    }
}