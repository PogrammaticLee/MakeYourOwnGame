using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRB;
    public float ForwardForce = 10f;
    public float JumpForce = 10f;

    private bool JumpInput = false;
    private int LanePosition = 0;
    private Vector3 TargetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            LanePosition--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LanePosition++;
        }

        TargetPosition = new Vector3(LanePosition * 3, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, 10 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        PlayerRB.AddForce(Vector3.forward * ForwardForce);

        if (JumpInput) {

            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            JumpInput = false;
        }
    }
}
