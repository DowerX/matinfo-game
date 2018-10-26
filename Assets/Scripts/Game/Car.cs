using UnityEngine;

public class Car : MonoBehaviour {
    public WheelCollider l1;
    public WheelCollider l2;
    public WheelCollider r1;
    public WheelCollider r2;

    public Transform l1_t;
    public Transform l2_t;
    public Transform r1_t;
    public Transform r2_t;

    private Vector3 l1_v;
    private Vector3 l2_v;
    private Vector3 r1_v;
    private Vector3 r2_v;

    private Quaternion l1_q;
    private Quaternion l2_q;
    private Quaternion r1_q;
    private Quaternion r2_q;
    private Quaternion xd;



    [Header("Car settings:")]

    [Tooltip("Default:1000")]
    public float speed = 1000f;

    [Tooltip("Default:10000")]
    public float breakingForce = 10000f;

    [Range(0f,89f)]
    [Tooltip("Default:45°")]
    public float maxSteering = 45f;

    [Range(0f, 90f)]
    [Tooltip("Correcting wheel rotaition. Default:0°")]
    public float steeringOffsetY = 0f;

    //[Tooltip("Set visual wheel rpm relative to velocity & motortorque.")]
    //public float rpm = 1f;

    [Space]
    public bool rearWD = true;
    public bool frontWD = true;

    public int a;
    public int b;
    public int c;

    [Header("Input settings:")]

    [Tooltip("Enables keybord input but disables controller. Doesn't effect steering!")]
    public bool keyboard = false;

    [Tooltip("Enables the player to flip back the car if he crashed it.")]
    public bool Flip = true;


    private void OnEnable()
    {
        l1.ConfigureVehicleSubsteps(a, b, c);
        l2.ConfigureVehicleSubsteps(a, b, c);
        r1.ConfigureVehicleSubsteps(a, b, c);
        r2.ConfigureVehicleSubsteps(a, b, c);
    }

    private void Update()
    {
        Steer();

        if (Input.GetButtonDown("Submit"))
        {
            transform.rotation = new Quaternion(0, Quaternion.identity.y, 0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }

        if (Input.GetButton("Cancel"))
        {
            Break();
        }

        if (!keyboard)
        {
            if (Input.GetAxis("RT") != -1)
            {
                Forward();
            }
            else if (Input.GetAxis("LT") != -1)
            {
                Backward();
            }
        }
        if (keyboard)
        {
            l2.brakeTorque = 0;
            r2.brakeTorque = 0;
            l1.brakeTorque = 0;
            r1.brakeTorque = 0;
            if (rearWD)
            {
                l2.motorTorque = Input.GetAxis("Vertical") * speed;
                r2.motorTorque = Input.GetAxis("Vertical") * speed;
            }
            if (frontWD)
            {
                l1.motorTorque = Input.GetAxis("Vertical") * speed;
                r1.motorTorque = Input.GetAxis("Vertical") * speed;
            }
        }

        UpdateVisuals();

    }

    private void UpdateVisuals()
    {

        l1.GetWorldPose(out l1_v,out l1_q);
        l2.GetWorldPose(out l2_v,out l2_q);
        r1.GetWorldPose(out r1_v,out r1_q);
        r2.GetWorldPose(out r2_v,out r2_q);

        l1_t.position = l1_v;
        l2_t.position = l2_v;
        r1_t.position = r1_v;
        r2_t.position = r2_v;

        xd = new Quaternion(0, 0, -l1_q.x, l1_q.w);
        l1_t.localRotation = xd;
        xd = new Quaternion(0, 0, -l2_q.x, l2_q.w);
        l2_t.localRotation = xd;
        xd = new Quaternion(0, 0, -r1_q.x, r1_q.w);
        r1_t.localRotation = xd;
        xd = new Quaternion(0, 0, -r2_q.x, r2_q.w);
        r2_t.localRotation = xd;
    }

    private void Steer()
    {
        l1.transform.localEulerAngles = new Vector3(0, Input.GetAxis("Horizontal") * maxSteering, 0);
        r1.transform.localEulerAngles = new Vector3(0, Input.GetAxis("Horizontal") * maxSteering, 0);
        l1.steerAngle = Input.GetAxis("Horizontal") * maxSteering + steeringOffsetY;
        r1.steerAngle = Input.GetAxis("Horizontal") * maxSteering + steeringOffsetY;

        r2.steerAngle = steeringOffsetY;
        l2.steerAngle = steeringOffsetY;
    }

    private void Break()
    {
        l2.motorTorque = 0;
        r2.motorTorque = 0;

        l1.motorTorque = 0;
        r1.motorTorque = 0;

        l2.brakeTorque = breakingForce;
        r2.brakeTorque = breakingForce;
        r1.brakeTorque = breakingForce;
        l1.brakeTorque = breakingForce;
    }

    private void Forward()
    {
        l2.brakeTorque = 0;
        r2.brakeTorque = 0;
        l1.brakeTorque = 0;
        r1.brakeTorque = 0;
        if (rearWD)
        {
            l2.motorTorque = Mathf.Clamp01(Input.GetAxis("RT")) * speed;
            r2.motorTorque = Mathf.Clamp01(Input.GetAxis("RT")) * speed;
        }
        if (frontWD)
        {
            l1.motorTorque = Mathf.Clamp01(Input.GetAxis("RT")) * speed;
            r1.motorTorque = Mathf.Clamp01(Input.GetAxis("RT")) * speed;
        }
    }

    private void Backward()
    {
        l2.brakeTorque = 0;
        r2.brakeTorque = 0;
        l1.brakeTorque = 0;
        r1.brakeTorque = 0;
        if (rearWD)
        {
            l2.motorTorque = Mathf.Clamp01(Input.GetAxis("LT")) * -speed;
            r2.motorTorque = Mathf.Clamp01(Input.GetAxis("LT")) * -speed;
        }
        if (frontWD)
        {
            l1.motorTorque = Mathf.Clamp01(Input.GetAxis("LT")) * -speed;
            r1.motorTorque = Mathf.Clamp01(Input.GetAxis("LT")) * -speed;
        }
    }
}
