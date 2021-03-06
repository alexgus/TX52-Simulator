using UnityEngine;

public class WheelRobot2 : Robot
{
    public Vector3 centerOfMass;

    [Range(0, 100)]
    public float brake;

    [Range(0, 100)]
    public float motor;

    [Range(0, 45)]
    public float steer;

    public WheelCollider wFL, wFR, wBL, wBR;

    public override void Move(Direction dir, float? distance = null)
    {
        switch (dir)
        {
            case Direction.FORWARD:

                wBR.brakeTorque = 0.0f;
                wBL.brakeTorque = 0.0f;
                wBL.motorTorque = motor;
                wBR.motorTorque = motor;
                break;

            case Direction.BACKWARD:

                wBR.brakeTorque = 0.0f;
                wBL.brakeTorque = 0.0f;

                wBL.motorTorque = -1 * motor;
                wBR.motorTorque = -1 * motor;
                break;

            case Direction.LEFT: break;
            case Direction.RIGHT: break;
            default: break;
        }
    }

    public override void Rotate(Direction dir, float? angle = null)
    {
        switch (dir)
        {
            case Direction.RIGHT:

                wFL.steerAngle = steer;
                wFR.steerAngle = steer;
                break;

            case Direction.LEFT:
                wFL.steerAngle = -steer;
                wFR.steerAngle = -steer;
                break;

            default: break;
        }
    }

    public void Start()
    {
        this.GetComponentInChildren<Rigidbody>().centerOfMass = centerOfMass;
    }

    public override void Stop(Stop axe)
    {
        switch (axe)
        {
            case global::Stop.MOVE:
                wBL.motorTorque = 0.0f;
                wBR.motorTorque = 0.0f;
                wBR.brakeTorque = brake;
                wBL.brakeTorque = brake;
                break;

            case global::Stop.ROTATE:
                wFL.steerAngle = 0.0f;
                wFR.steerAngle = 0.0f;
                break;

            case global::Stop.FULLSTOP: break;
        }
    }
}