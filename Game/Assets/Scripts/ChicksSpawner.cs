using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicksSpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject[] chicksReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedChick;

    private int randomIndex, randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnChicks());
    }


    IEnumerator SpawnChicks(){

        while(true){
            yield return new WaitForSeconds(Random.Range(1,7));

            randomIndex= Random.Range(0,chicksReference.Length);
            randomSide= Random.Range(0,2);

            spawnedChick= Instantiate(chicksReference[randomIndex]);

            if(randomSide==0){
                spawnedChick.transform.position= leftPos.position;
                spawnedChick.GetComponent<Chicks>().speed=Random.Range(3,6);
            }
            else{
            spawnedChick.transform.position= rightPos.position;
                spawnedChick.GetComponent<Chicks>().speed= -Random.Range(3,6);
                spawnedChick.GetComponent<SpriteRenderer>().flipX=true;
            }
        }
      
    }
}
