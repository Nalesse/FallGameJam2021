using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject tutorialUI;
    
    public void CloseTutorial()
    {
        tutorialUI.gameObject.SetActive(false);
        ResumeGame();
    }

    // Start is called before the first frame update
    private void Start()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
