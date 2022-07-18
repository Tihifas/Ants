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
        MoveTo(new Vector2(2, 2));
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: put in methods etc.

    }

    public void StartWalking()
    {
        Vector2 forward = ForwardFromTransform(transform); //https://answers.unity.com/questions/609527/how-do-i-make-a-game-object-move-in-the-direction.html
        Vector2 velocity = forward * speed;
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

    //Call as coroutine?
    public void MoveTo(Vector2 target)
    {
        Vector2 vectorTo = target - ((Vector2) transform.position);
        //vectorTo.Normalize(); Needed?
        //var calculatedRotation = RotationInDirection(transform, vectorTo);
        //transform.rotation = calculatedRotation;
        //start moving
        //stop moving
    }

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

    public static Vector2 ForwardFromTransform(Transform transform)
    {
        return transform.up;
    }
}
