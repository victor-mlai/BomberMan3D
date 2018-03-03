using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float Speed = 5f;
    public Camera FPCamera;

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
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, yRot * 5, 0));    // rotate capsule left-right
        FPCamera.transform.Rotate(-xRot * 5, 0, 0); // rotate First Person Camera up-down
    }
}
