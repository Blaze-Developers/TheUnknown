using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedcharacter = 0;

    public void NextCharacter()
    {
        characters[selectedcharacter].SetActive(false);
        selectedcharacter = (selectedcharacter + 1) % characters.Length;
        characters[selectedcharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedcharacter].SetActive(false);
        selectedcharacter--;
        if (selectedcharacter < 0)
        {
            selectedcharacter += characters.Length;
        }
        characters[selectedcharacter].SetActive(true);
    }

    public void StartGame()
    {
        //ayo bitch you suck dick if you change this code imma kill you bitch you little piece of shit MotherFucker
        //You shouldn't have even opened this MF you piece of SHIT
        PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);
        SceneManager.LoadScene("fuckoff");
    }
}
