using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalCanvans : MonoBehaviour
{
    public GameObject BOi;
    public static Animator Ani;
    public Animator Anim;
    public GameObject Fail, Win;

    public int CurrentLevel;

   // public Scene[] Levels;
    public string[] Levelstrr;

    //public Scene Level1, Level2, Level3, Level4, Level5;
    public string Level1str, Level2str, Level3str, Level4str, Level5str;

    public Sprite[] QRCodes;

    //public Scene ServerRoom;
    public string ServerRoomstr;

    public Image QR;

    void NextMission()
    {
        CurrentLevel++;
        QR.sprite = QRCodes[Random.Range(0, QRCodes.Length)];
        switch (CurrentLevel) {
            case 1:
                SceneManager.LoadScene(Level1str);
                break;
            case 2:
                SceneManager.LoadScene(Level2str);
                break;
            case 3:
                SceneManager.LoadScene(Level3str);
                break;
            case 4:
                SceneManager.LoadScene(Level4str);
                break;
            case 5:
                SceneManager.LoadScene(Level5str);
                break;
            case 6:
                LevelSetup();
                CurrentLevel = 1;
                SceneManager.LoadScene(Level1str);
                // SceneManager.LoadScene(ServerRoomstr);
                break;
        }
    }

    //  GameObject.FindGameObjectWithTag("Can").GetComponent<GlobalCanvans>().FinishedMission();

    public void FinishedMission()
    {
        StartCoroutine(LoadMiss());
    }

    IEnumerator LoadMiss()
    {
        Ani.SetBool("Load", true);
        yield return new WaitForSeconds(0.5f);
        NextMission();
    }

    //  GameObject.FindGameObjectWithTag("Can").GetComponent<GlobalCanvans>().Anim.SetBool("Load", false);

    private void Awake()
    {
        Fail.SetActive(false);
        Win.SetActive(false);
        DontDestroyOnLoad(this.gameObject);
        Ani = Anim;
        LevelSetup();
        //Ani.SetBool("Load", true);
        FinishedMission();
    }

    public void Restartmisson()
    {
        Fail.SetActive(false);
        Win.SetActive(false);
        DontDestroyOnLoad(this.gameObject);
        Ani = Anim;
        LevelSetup();
        //Ani.SetBool("Load", true);
        FinishedMission();
    }

    public void WinGame()
    {
      //  GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().Finished = true;
        Win.SetActive(true);
        Fail.SetActive(false);
    }

    public void LoseGame()
    {
       // GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().Finished = true;
        GameObject[] sss =    GameObject.FindGameObjectsWithTag("Bot");
        for (int i = 0; i < sss.Length; i++)
        {
            sss[i].SetActive(false);
        }
        Win.SetActive(false);
        Fail.SetActive(true);
    }

    private void Update()
    {
        if (Ani.GetBool("Load") == true) { } //BOi.SetActive(true); 
        else
        {
            if (Ani.GetBool("Load") == false) BOi.SetActive(false);
        }
    }

    int RandomBoi()
    {
        int boi = Random.Range(0, Levelstrr.Length);
        return boi;
    }

    public void LevelSetup()
    {
        CurrentLevel = 0;
        Level1str = "Vedanth";
        //Level1str = Level1.name;
        Level2str = Levelstrr[RandomBoi()];
        //Level2str = Level2.name;
        Level3str = Levelstrr[RandomBoi()];
        //Level3str = Level3.name;
        Level4str = Levelstrr[RandomBoi()];
        //Level4str = Level4.name;
        Level5str = Levelstrr[RandomBoi()];
        //Level5str = Level5.name;
    }

}
