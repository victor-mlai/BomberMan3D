using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float Speed = 5f;

    public Camera FPCamera;

    private float xClamp = 0.0f;

    void Awake()
    {
        // Lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Player Move
        float horiz = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        Vector3 movHoriz = transform.right * horiz;
        Vector3 movVerti = transform.forward * verti;

        Vector3 velocity = (movHoriz + movVerti).normalized * Speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + velocity);

        // Player Rotate
        float yRot = Input.GetAxisRaw("Mouse X") * 5;
        float xRot = Input.GetAxisRaw("Mouse Y") * 5;

        // rotate capsule left-right
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, yRot, 0));

        // rotate camera up-down
        Vector3 targetRotCam = FPCamera.transform.eulerAngles;
        targetRotCam.x -= xRot;
        xClamp -= xRot;

        // clamp the up-down rotation
        if (xClamp > 90)
        {
            xClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xClamp < -90)
        {
            xClamp = -90;
            targetRotCam.x = 270;
        }

        FPCamera.transform.rotation = Quaternion.Euler(targetRotCam);
    }
}
