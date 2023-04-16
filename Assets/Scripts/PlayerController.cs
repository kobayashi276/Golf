using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float minSpeed;
    public GameObject win;
    public GameObject range;
    public GameObject gameController;
    private LineRenderer lineRenderer;


    [SerializeField] private float shotPower, maxForce;
    private float shotFore;
    private Vector3 lastVel;
    private Vector3 startPos, endPos, direction;
    private bool canShoot, shotStarted;
    private Rigidbody rb;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canShoot = true;
        rb.sleepThreshold = minSpeed;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lastPosition = transform.position;
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,transform.position);
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        lastVel = rb.velocity;
        // Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
        Debug.Log(startPos);
        Debug.Log(endPos);
        //Xu li keo tha
        if (Input.GetMouseButtonDown(0) && canShoot && OnMouseOverPlayer()){
            startPos = MousePositionInWorld();
            shotStarted = true;
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButton(0) && shotStarted){
            endPos = MousePositionInWorld();
            lineRenderer.SetPosition(1,new Vector3(startPos.x*2 - endPos.x,0f,startPos.z*2 - endPos.z));
            shotFore = Mathf.Clamp(Vector3.Distance(endPos,startPos),0,maxForce);

        }
        if (Input.GetMouseButtonUp(0) && shotStarted){
            canShoot = false;
            shotStarted = false;
            GetComponent<AudioSource>().Play();
            range.SetActive(false);
            lineRenderer.enabled = false;
            gameController.GetComponent<GameController>().increaseTime();
        }
        
        // float horAxis = Input.GetAxis("Horizontal");
        // float verAxis = Input.GetAxis("Vertical");
        // Vector3 camForward = camera.transform.forward;
        // Vector3 camRight = camera.transform.right;

        // camForward.y = 0;
        // camRight.y = 0;

        // Vector3 forwardRelative = verAxis * camForward;
        // Vector3 rightRelative = horAxis * camRight;
        // Vector3 moveDir = forwardRelative + rightRelative;
        // // Vector3 movement = new Vector3(Mathf.Clamp(horAxis,minScreen.x,maxScreen.x), 0.0f, Mathf.Clamp(verAxis,0,maxScreen.z));
        // Vector3 movement = new Vector3(moveDir.x,0.0f,moveDir.z);

        // rb.velocity=movement * speed;
        // if (movement != Vector3.zero){
        //     Quaternion target = Quaternion.LookRotation(movement, Vector3.up);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation,target,720 * Time.deltaTime);
        // }
        
    }

    private void FixedUpdate(){
        if (!canShoot){
            direction = startPos-endPos;
            direction.y=0;
            rb.AddForce(Vector3.Normalize(direction)*shotFore*shotPower,ForceMode.Impulse);
            startPos = endPos = Vector3.zero;
        }
        if (rb.IsSleeping()){
            canShoot = true;
            lastPosition = transform.position;
            lineRenderer.SetPosition(0,lastPosition);
            range.SetActive(true);
        }
    }

    private Vector3 MousePositionInWorld(){
        Vector3 position = Vector3.zero;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)){
            position = hit.point;
        }
        position.y = 0;
        return position;
    }

    private bool OnMouseOverPlayer(){
        Vector3 position = Vector3.zero;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)){
            if (hit.transform.tag == "Player")
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Hole"){
            Debug.Log("YOU WIN");
            win.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Respawn"){
            Debug.Log("RESPAWN");
            transform.position = lastPosition;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("Triggered");
    }
}
