using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject win;
    public GameObject camera;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!win.activeSelf)
            camera.transform.position = new Vector3(player.transform.position.x+2.54f,player.transform.position.y+3.11f,player.transform.position.z - 0.7f);
            // camera.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
