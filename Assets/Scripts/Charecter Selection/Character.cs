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
        PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);
        SceneManager.LoadScene("SCENE");
    }
}
