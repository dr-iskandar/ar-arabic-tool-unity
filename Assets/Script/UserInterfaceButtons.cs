using UnityEngine;
using System.Collections;
using System.IO;

public class UserInterfaceButtons : MonoBehaviour
{
	public float scalingSpeed = 0.03f;
	public float rotationSpeed = 70.0f;
	public float translationSpeed = 5.0f;
    public AudioSource Halo, SelamatDatang, SampaiJumpa;
  

//	public GameObject Model;
	bool repeatScaleUp = false;
	bool repeatScaleDown = false;
	bool repeatRotateLeft = false;
	bool repeatRotateRight = false;
    bool repeatRotateUp = false;
    bool repeatRotateDown = false;
	bool repeatPositionUp = false;
	bool repeatPositionDown = false;
	bool repeatPositionLeft = false;
	bool repeatPositionRight = false;
    bool ket = true;
    bool ban = true;
    bool about = true;
    bool sound_tg = true;
	void Update ()
	{
		if (repeatScaleUp) {
			ScaleUpButton ();
		}

		if (repeatScaleDown) {
			ScaleDownButton ();
		}

		if (repeatRotateRight) {
			RotationRightButton();
		}

		if (repeatRotateLeft) {
			RotationLeftButton();
		}

        if (repeatRotateUp)
        {
            RotationUpButton();
        }

        if (repeatRotateDown)
        {
            RotationDownButton();
        }

		if (repeatPositionUp) {
			PositionUpButton();
		}

		if (repeatPositionDown) {
			PositionDownButton();
		}

		if (repeatPositionLeft) {
			PositionLeftButton();
		}

		if (repeatPositionRight) {
			PositionRightButton();
		}

	}

    IEnumerator Start()
    {
        Halo.Play();
        yield return new WaitForSeconds(0.5f);
        SelamatDatang.Play();
    }

    IEnumerator closes()
    {
        yield return new WaitForSeconds(2.5f);
        Application.Quit();
    }

    public void CloseAppButton ()
	{
        SampaiJumpa.Play();
        StartCoroutine(closes());
	}


	public void RotationRightButton ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		GameObject.FindWithTag ("Model").transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
	}

	public void RotationLeftButton ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		GameObject.FindWithTag ("Model").transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
	}

    public void RotationUpButton()
    {
        // transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
        GameObject.FindWithTag("Model").transform.Rotate(rotationSpeed * Time.deltaTime,0, 0);
    }

    public void RotationDownButton()
    {
        // transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
        GameObject.FindWithTag("Model").transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
    }
	public void RotationRightButtonRepeat ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		repeatRotateRight=true;
	}
	
	public void RotationLeftButtonRepeat ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		repeatRotateLeft=true;
	}

    public void RotationUpButtonRepeat()
    {
        repeatRotateUp = true;
    }

    public void RotationDownButtonRepeat()
    {
        repeatRotateDown = true;
    }

	public void ScaleUpButton ()
	{
		// transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
        GameObject.FindWithTag("Model").GetComponent<Animator>().enabled = false;
			GameObject.FindWithTag ("Model").transform.localScale += new Vector3 (scalingSpeed, scalingSpeed, scalingSpeed);
		}
    public void TampilKet()
    {
        if (  GameObject.FindWithTag("Keterangan") != null)
        {
            
    
            if (ket)
            {
                GameObject.FindWithTag("Keterangan").GetComponent<Canvas>().enabled = true;

                GameObject.FindWithTag("Keterangan").transform.GetChild(0).gameObject.active = false;
                GameObject.FindWithTag("Keterangan").transform.GetChild(0).gameObject.active = true;

                GameObject.FindWithTag("Suara").GetComponent<AudioSource>().Stop();
                GameObject.FindWithTag("Keterangan").GetComponent<AudioSource>().Play();
                ket = false;
            }
            else
            {
                var animator = GameObject.FindWithTag("Keterangan").transform.GetChild(0).GetComponent<Animator>();
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                    animator.Play("Close");
                StartCoroutine(RunPopupDestroy(GameObject.FindWithTag("Keterangan").transform.GetChild(0).gameObject));
              
                GameObject.FindWithTag("Keterangan").GetComponent<AudioSource>().Stop();
              //  GameObject.FindWithTag("Suara").GetComponent<AudioSource>().Play();
    
                ket =true;
            }
        }
           
        // transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
      
    }
    private IEnumerator RunPopupDestroy(GameObject popup)
    {
        yield return new WaitForSeconds(0.5f);
        popup.active = false;
       
    }

    public void TampilBantuan()
    {
        if (GameObject.FindWithTag("Bantuan") != null)
        {
            if (ban)
            {
                GameObject.FindWithTag("Bantuan").GetComponent<Canvas>().enabled = true;


                GameObject.FindWithTag("Bantuan").transform.GetChild(0).gameObject.active = false;
                GameObject.FindWithTag("Bantuan").transform.GetChild(0).gameObject.active = true;
                ban = false;
            }
            else
            {
                //GameObject.FindWithTag("Bantuan").GetComponent<Canvas>().enabled = false;
                var animator = GameObject.FindWithTag("Bantuan").transform.GetChild(0).GetComponent<Animator>();
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                    animator.Play("Close");
                StartCoroutine(RunPopupDestroy(GameObject.FindWithTag("Bantuan").transform.GetChild(0).gameObject));
                ban = true;
            }
        }
    }

    public void TampilAbout()
    {
        if (GameObject.FindWithTag("About") != null)
        {
            if (about)
            {
                GameObject.FindWithTag("About").GetComponent<Canvas>().enabled = true;



                GameObject.FindWithTag("About").transform.GetChild(0).gameObject.active = false;
                GameObject.FindWithTag("About").transform.GetChild(0).gameObject.active = true;

                about = false;
            }
            else
            {
              //  GameObject.FindWithTag("About").GetComponent<Canvas>().enabled = false;
                var animator = GameObject.FindWithTag("About").transform.GetChild(0).GetComponent<Animator>();
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                    animator.Play("Close");
                StartCoroutine(RunPopupDestroy(GameObject.FindWithTag("About").transform.GetChild(0).gameObject));
                about = true;
            }
        }
    }
	public void ScaleUpButtonRepeat ()
	{
		repeatScaleUp = true;
		Debug.Log ("Up");
	}
	public void ScaleDownButtonRepeat ()
	{
		repeatScaleDown = true;
		Debug.Log ("Down");
	}
	public void PositionDownButtonRepeat ()
	{
		repeatPositionDown = true;
	}
	public void PositionUpButtonRepeat ()
	{
		repeatPositionUp = true;
	}
	public void PositionLeftButtonRepeat ()
	{
		repeatPositionLeft = true;
	}
	public void PositionRightButtonRepeat ()
	{
		repeatPositionRight = true;
	}
	
	public void ScaleUpButtonOff ()
	{
		repeatScaleUp = false;
		Debug.Log ("Off");
	}
	public void ScaleDownButtonOff ()
	{
		repeatScaleDown = false;
		Debug.Log ("Off");
	}

	public void RotateLeftButtonOff ()
	{
		repeatRotateLeft = false;
		Debug.Log ("Off");
	}

	public void RotateRightButtonOff ()
	{
		repeatRotateRight = false;
		Debug.Log ("Off");
	}

    public void RotationUpButtonOff()
    {
        repeatRotateUp = false;
    }

    public void RotationDownButtonOff()
    {
        repeatRotateDown = false;
    }



	public void PositionRightButtonOff ()
	{
		repeatPositionRight = false;
		Debug.Log ("Off");
	}
	public void PositionLeftButtonOff ()
	{
		repeatPositionLeft = false;
		Debug.Log ("Off");
	}
	public void PositionUpButtonOff ()
	{
		repeatPositionUp = false;
		Debug.Log ("Off");
	}
	public void PositionDownButtonOff ()
	{
		repeatPositionDown = false;
		Debug.Log ("Off");
	}
	
	public void ScaleDownButton ()
	{
		// transform.localScale += new Vector3(-scalingSpeed, -scalingSpeed, -scalingSpeed);
        GameObject.FindWithTag("Model").GetComponent<Animator>().enabled = false;
		GameObject.FindWithTag ("Model").transform.localScale += new Vector3 (-scalingSpeed, -scalingSpeed, -scalingSpeed);
	}

	public void PositionUpButton ()
	{
		GameObject.FindWithTag ("Model").transform.Translate (0, 0, -translationSpeed * Time.deltaTime);
	}

	public void PositionDownButton ()
	{

		GameObject.FindWithTag ("Model").transform.Translate (0, 0, translationSpeed * Time.deltaTime);
	}

	public void PositionRightButton ()
	{
		GameObject.FindWithTag ("Model").transform.Translate (-translationSpeed * Time.deltaTime, 0, 0);
	}

	public void PositionLeftButton ()
	{
		GameObject.FindWithTag ("Model").transform.Translate (translationSpeed * Time.deltaTime, 0, 0);  // backward
	}

	public void ChangeScene (int a)
	{
	//	Application.LoadLevel (a);
        LoadingScreenManager.LoadScene(a);
	}


    public void SoundT()
    {
        if (sound_tg)
        {
            AudioListener.volume = 0;
            sound_tg = false;
        }
        else
        {
            AudioListener.volume = 1;
            sound_tg = true;
        }
    }
	public void AnyButton ()
	{
		Debug.Log ("Any");
	}
}
