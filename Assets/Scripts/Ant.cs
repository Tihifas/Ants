using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public float speed;
    public IPickUpAble pickUpAble;
    public bool Carrying { get => pickUpAble != null; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
    }

    public void StartWalking(float? speed = null)
    {
        if (speed == null) speed = this.speed;

        Vector2 forward = Forward(); //https://answers.unity.com/questions/609527/how-do-i-make-a-game-object-move-in-the-direction.html
        Vector2 velocity = forward * (float)speed;
        SetVelocity(velocity);
    }

    public Vector2 GetVelocity()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        return velocity;
    }

    public void SetVelocity(Vector2 velocity)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    public IEnumerator MoveTo(Vector2 target, float? speed = null)
    {
        if (speed == null) speed = this.speed;

        Vector2 vecToTarget = (Vector3)target - this.transform.position;

        LookAt(target);

        StartWalking();

        //This assumes it's speed was not changed!
        float distance = vecToTarget.magnitude;
        float secondsToDestination = distance / (float)speed;
        yield return new WaitForSeconds(secondsToDestination);

        SetVelocity(Vector2.zero);
    }

    public IEnumerator MoveToCurrentPosOfObj(GameObject targetObj)
    {
        yield return MoveTo(targetObj.transform.position);
    }

    //USE THIS? https://answers.unity.com/questions/1244393/best-way-to-move-a-rigidbody2d-from-point-a-to-poi.html
    //TODO move to vector helper
    //Modified https://forum.unity.com/threads/quaternion-lookrotation-in-2d.292572/
    //public static Quaternion RotationInDirection(Transform currentTransform, Vector2 target) //TODO can it be made without current transform?
    //{
    //    float angle = AngleBetweenPoints(ForwardFromTransform(currentTransform), target);
    //    Debug.Log("angle:" + angle);
    //    return Quaternion.Euler(new Vector3(0f, 0f, angle));
    //    //return Quaternion.Slerp(currentTransform.rotation, targetRotation, time.deltaTime);
    //}
    //public static float AngleBetweenPoints(Vector2 a, Vector2 b)
    //{
    //    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    //}

    private Vector2 Forward()
    {
        return this.transform.up;
    }

    private void LookAt(Vector2 target)
    {
        Vector3 direction = (Vector3)target - this.transform.position;
        this.transform.up = direction;
    }

    private void LookAt(GameObject targetObj)
    {
        LookAt(targetObj.transform.position);
    }

    void OnTriggerEnter2D(Collider2D targetCollider)
    {
        Debug.Log("OnTriggerEnter2D");
        GameObject targetGo = targetCollider.gameObject;
        var pickUpAbleComponent = targetGo.GetComponent<IPickUpAble>();
        bool targetIsPickUppAble = (pickUpAbleComponent != null && pickUpAbleComponent.IsPickUpAble);
        if (targetIsPickUppAble)
        {
            pickUpAbleComponent.IsPickUpAble = false;
            PickUpObject(targetGo);
        }
    }

    private void PickUpObject(GameObject target)
    {
        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();

        Vector2 forward = Forward();
        Vector2 carryPoint = ((Vector2)this.transform.position) + Forward() * 0.4f;
        target.transform.position = carryPoint;

        FixedJoint2D joint = (FixedJoint2D)this.gameObject.AddComponent(typeof(FixedJoint2D));
        joint.connectedBody = targetRb;
    }

    //private void FetchAPickupAbleAndGoTo(Vector2 destination)
    //{
    //    PickUpAble pickUpAble = FindObjectsOfType<PickUpAble>()[0];
    //    StartCoroutine(MoveTo(pickUpAble.transform.position));
    //}

}
