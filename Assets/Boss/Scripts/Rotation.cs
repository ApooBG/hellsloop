using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //values that will be set in the Inspector
    public float rotationSpeed;

    //values for internal use
    Animator animator;
    Transform target;
    Transform currentTransform;

    Quaternion _lookRotation;
    Vector3 _direction;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentTransform = GameObject.Find("FinalBoss").transform;
        rotationSpeed = 6F;
        animator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack")
        {
            Rotate();
        }
    }

    void Rotate()
    {
            //find the vector pointing from our position to the target
            _direction = (target.position - currentTransform.transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);
            _lookRotation.x = 0;
            _lookRotation.z = 0;

            //rotate us over time according to speed until we are in the required rotation
            currentTransform.transform.rotation = Quaternion.Slerp(currentTransform.transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
    }
}
