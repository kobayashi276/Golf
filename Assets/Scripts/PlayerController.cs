using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float minSpeed;
    public GameObject win;


    [SerializeField] private float shotPower, maxForce;
    private float shotFore;
    private Vector3 startPos, endPos, direction;
    private bool canShoot, shotStarted;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canShoot = true;
        rb.sleepThreshold = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
        Debug.Log(startPos);
        Debug.Log(endPos);
        if (Input.GetMouseButtonDown(0) && canShoot){
            startPos = MousePositionInWorld();
            shotStarted = true;
        }

        if (Input.GetMouseButton(0) && shotStarted){
            endPos = MousePositionInWorld();
            shotFore = Mathf.Clamp(Vector3.Distance(endPos,startPos),0,maxForce);
        }
        if (Input.GetMouseButtonUp(0) && shotStarted){
            canShoot = false;
            shotStarted = false;
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
        }
    }

    private Vector3 MousePositionInWorld(){
        Vector3 position = Vector3.zero;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)){
            position = hit.point;
        }
        return position;
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Hole"){
            Debug.Log("YOU WIN");
            win.SetActive(true);
        }
    }
}
