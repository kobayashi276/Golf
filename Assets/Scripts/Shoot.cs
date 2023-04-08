using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float xroat, yroat = 0f;
    public GameObject player;
    public float rotateSpeed = 5f;
    public LineRenderer Line;
    public float power = 30f;
    public Camera camera;

    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float timer;

    // private LayerMask rayLayer;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Line.transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Line.transform.position = player.transform.position;
        // xroat+=Input.GetAxis("Mouse X")*rotateSpeed;
        // yroat+=Input.GetAxis("Mouse Y")*rotateSpeed;
        // Line.transform.rotation = Quaternion.Euler(0f,xroat,0f);

        // if (Input.GetKeyDown("space")){
        //     timer = Time.time;
        // }
        // if (Input.GetKeyUp("space")){
        //     float releaseTimer = Time.time - timer;
        //     if (timer != 0){
        //         // player.GetComponent<Rigidbody>().velocity = player.transform.forward;
        //         Vector3 lineForward = Line.transform.forward;
        //         Vector3 lineRight = Line.transform.right;

        //         // lineForward.y=0;
        //         // lineRight.y=0;

        //         Vector3 forwardRelative = 2 * lineForward;
        //         Vector3 rightRelative = 2 * lineRight;

        //         Vector3 moveDir = forwardRelative + rightRelative;
        //         Vector3 movement = new Vector3(moveDir.x,0.0f,moveDir.z);
        //         player.GetComponent<Rigidbody>().velocity = movement;
        //     }
        //     Debug.Log(player.GetComponent<Rigidbody>().velocity);
            
        }
        // transform.position = player.position;
        // if (Input.GetMouseButton(0)){
        //     xroat+=Input.GetAxis("Mouse X")*rotateSpeed;
        //     yroat+=Input.GetAxis("Mouse Y")*rotateSpeed;
        //     transform.rotation = Quaternion.Euler(yroat,xroat,0f);
        //     Line.gameObject.SetActive(true);
        //     Line.SetPosition(0,transform.position);
        //     Line.SetPosition(1,transform.position + transform.forward * 4f);
        //     if (yroat<-35f){
        //         yroat = -35f;
        //     }
        // }
        // if (Input.GetMouseButtonUp(0)){
        //     player.velocity = transform.forward * power;
        //     Line.gameObject.SetActive(false);
        // }
        // Line.transform.LookAt(Input.mousePosition);
    }

    // Vector3 ClickedPoint(){
    //     Vector3 position = Vector3.zero;
    //     var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycasHit hit = new RaycasHit();
    //     if (Physics.Raycast(ray,out hit,Mathf.Infinity, rayLayer))
    //     {
    //         position = hit.point;
    //     }
    //     return position;
    // }
