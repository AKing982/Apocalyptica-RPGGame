using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterlist;
    public int index;

    private void Start()
    {
        characterlist = new GameObject[transform.childCount];

        // Fill array with prefabs
        for(int i = 0; i < transform.childCount; i++)
        {
            characterlist[i] = transform.GetChild(i).gameObject;

        }

        // Toggle off renderer
        foreach(GameObject go in characterlist)
        {
            go.SetActive(false);
        }

        // Toggle on the first index
        if(characterlist[0])
        {
            characterlist[0].SetActive(true);
        }

    

    }

    public void ToggleLeft()
    {
        // Toggle off the current model
        characterlist[index].SetActive(false);

        index--;

        if (index == characterlist.Length)
        {
            index = 0;
        }

        // Toggle on the current model
        characterlist[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterlist[index].SetActive(false);

        index++;

        if (index < 0)
        {
            index = characterlist.Length - 1;
        }

        // Toggle on the current model
        characterlist[index].SetActive(true);
    }

    public void SelectButton()
    {

    }





}
