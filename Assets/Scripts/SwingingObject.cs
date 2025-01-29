using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingObject : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform cylinderEnd, hangingObject;
    private float maxDistance = 100f;
    private SpringJoint joint;
    [SerializeField] Transform GrappleCube;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
   

    // Update is called once per frame
    void Update()
    {
        grapplePoint = GrappleCube.transform.position;
        joint = hangingObject.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;

        float distanceFromPoint = Vector3.Distance(hangingObject.position, grapplePoint);

        joint.maxDistance = distanceFromPoint;
        joint.minDistance = distanceFromPoint * 0.25f;

        //Change joint charatceristics.
        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        lr.positionCount = 2;
    }
    private void LateUpdate()
    {
        DrawRope();
    }

    void DrawRope()
    {
        lr.SetPosition(0, cylinderEnd.position);
        lr.SetPosition(1, grapplePoint);
    }
}
