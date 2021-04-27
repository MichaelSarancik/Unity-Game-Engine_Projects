using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveNumber : MonoBehaviour
{
    public bool readyToSpawn = true;
    public int RoundNum = 0;
    public GameObject spawnerManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("IncreaseRoundNum");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Spawner").GetComponent<SpawningScript>().ChickensRemaining <= 0)
        {
            StartNewWave();
            readyToSpawn = true;
        }
    }
       
    public void StartNewWave()
    {
        StartCoroutine("IncreaseRoundNum");
                     
    }
    IEnumerator IncreaseRoundNum()
    {

        yield return new WaitForSeconds(5.0f);

        if(RoundNum == 0 && readyToSpawn == true)
        {

            spawnerManager.GetComponent<SpawningScript>().SpawnChickensWave1();
            RoundNum++;
            readyToSpawn = false;
        }

        if (RoundNum == 1 && readyToSpawn == true)
        {

            spawnerManager.GetComponent<SpawningScript>().SpawnChickensWave2();
            RoundNum++;
            readyToSpawn = false;
        }

        if (RoundNum == 2 && readyToSpawn == true)
        {

            spawnerManager.GetComponent<SpawningScript>().SpawnChickensWave3();
            RoundNum++;
            readyToSpawn = false;
        }

        if(RoundNum == 3)
        {


            SceneManager.LoadScene("VR_Game_BossFight");


        }

    }

}
