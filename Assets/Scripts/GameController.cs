using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject win;
    public GameObject camera;
    public float rotationSpeed;
    public TextMeshProUGUI timeFeed;
    public Button button;
    public GameObject pauseFeed;

    private int time;
    private string[] scenes = new string[] {"Level1","Level2","Level3"};
    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        time = 0;
        pauseFeed.SetActive(false);
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p")){
            pauseFeed.SetActive(true);
        }

        if (!win.activeSelf){
            camera.transform.position = new Vector3(player.transform.position.x+2.54f,player.transform.position.y+3.11f,player.transform.position.z - 0.7f);
        }
        else{
            camera.GetComponent<AudioSource>().Stop();
            if (SceneManager.GetActiveScene().name == "Level3"){
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Main menu";
            }
        }
            
            // camera.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void closePauseFeed(){
        pauseFeed.SetActive(false);
    }

    public void MainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void increaseTime(){
        time++;
        setTime();
    }

    private void setTime(){
        timeFeed.text = "Time: " + time.ToString();
    }

    public void NextLevel(){
        string currentScene = SceneManager.GetActiveScene().name;
        for (int i=0;i<scenes.Length;i++){
            if (scenes[i]==currentScene){
                if (i==scenes.Length-1){
                    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
                }
                else
                    UnityEngine.SceneManagement.SceneManager.LoadScene(scenes[i+1]);
            }
        }
    }
}
