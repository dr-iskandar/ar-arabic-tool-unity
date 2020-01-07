using UnityEngine;
using System.Collections;
using Vuforia;
public class MarkerObjek : MonoBehaviour,
                                            ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
  
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            for (int i = 1; i <= 8; i++)
            {
                GameObject.FindWithTag("TombolUI").transform.GetChild(i).gameObject.active = true;
            }
        
            foreach (Transform child in transform)
            {
                child.gameObject.active = true;
            }
            GameObject.FindWithTag("Model").GetComponent<Animator>().enabled = true;
            Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);
            foreach (Canvas component in canvasComponents)
            {
                component.enabled = false;
            }



           // Animator[] animk = GetComponentsInChildren<Animator>(true);
         //   foreach (Canvas component in  animk )
         //   {
          //      component.enabled = false;
         //   }
      ///      gameObject.GetComponent<AudioSource>().Play();
          
          
        }
        else
        {
            for (int i = 1; i <= 8; i++)
            {
                GameObject.FindWithTag("TombolUI").transform.GetChild(i).gameObject.active = false;
            }

            foreach (Transform child in transform)
            {
                child.gameObject.active = false;
            }


          //  gameObject.GetComponent<AudioSource>().Stop();
          
        }
    }
}