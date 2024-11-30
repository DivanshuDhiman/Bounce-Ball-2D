using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] private float topPosY, middlePosY;
    [SerializeField] private RectTransform pausePanelRect;
    [SerializeField] private float tweenDuration;
    [SerializeField] private GameObject pasueMenu;


    public void Pause()
    {
        pasueMenu.SetActive(true);
        Time.timeScale = 0f;
        PausePanelIntro();
    }
    public async void Resume()
    {
        await PausePanelOutro();
        pasueMenu.SetActive(false);
        Time.timeScale = 1f;
    }    
    public async void Restart()
    {
        await  PausePanelOutro();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pasueMenu.SetActive(false);
        Time.timeScale = 1f;
       
    }
    private void PausePanelIntro()
    {
        pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);

    }
    async Task PausePanelOutro()
    {
      await pausePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}


