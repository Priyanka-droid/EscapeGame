using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{

    private AudioSource audioData;
    bool flag=true;
    // Start is called before the first frame update
    void Start()
    {
        audioData=GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    { 
        if(GameObject.FindWithTag("Player") == null && flag){
            audioData.Play();
            flag=false;
          StartCoroutine(PlayMusic());
        }
        
    }
     IEnumerator PlayMusic(){

        while(true){
            yield return new WaitForSeconds(1);
            audioData.Play();
        }
      
    }
}
