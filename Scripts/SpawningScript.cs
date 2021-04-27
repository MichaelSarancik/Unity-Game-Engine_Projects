using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawningScript : MonoBehaviour
{

    public GameObject normalChicken;
    public GameObject armoredChicken;
    public GameObject spawnerMiddle;
    public GameObject spawnerLeft;
    public GameObject spawnerRight;
    public int ChickensRemaining;
    public TextMeshProUGUI ChickensLeft;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChickensLeft.text = ChickensRemaining.ToString();
    }


    public void SpawnChickensWave1()
    {
        ChickensRemaining = 15;
        for (int i = 0; i < 5; i++)
        {
            GameObject newChicken = Instantiate(normalChicken, spawnerMiddle.transform, false);
            newChicken = Instantiate(normalChicken, spawnerLeft.transform, false);
            newChicken = Instantiate(normalChicken, spawnerRight.transform, false);
        }
    }

    public void SpawnChickensWave2()
    {
        ChickensRemaining = 25;
        for (int i = 0; i < 10; i++)
        {

            GameObject newChicken = Instantiate(normalChicken, spawnerLeft.transform, false);
            newChicken = Instantiate(normalChicken, spawnerRight.transform, false);

        }

        for (int i = 0; i < 5; i++)
        {
            GameObject newChicken2 = Instantiate(armoredChicken, spawnerMiddle.transform, false);
        }

    }



    public void SpawnChickensWave3()
    {
        ChickensRemaining = 30;
        for (int i = 0; i < 10; i++)
        {
            GameObject newChicken2 = Instantiate(armoredChicken, spawnerMiddle.transform, false);
            newChicken2 = Instantiate(armoredChicken, spawnerLeft.transform, false);
            newChicken2 = Instantiate(armoredChicken, spawnerRight.transform, false);

        }


    }



}
