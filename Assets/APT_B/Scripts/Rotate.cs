using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rotate : MonoBehaviour
{
    Vector3 touch;
    private float scrollSpeed = 5f;
    private float X, Y, Z;
    public int speeds;

    public GameObject apartment;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Touch 2d zoom controller
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = currentDistTouch - distTouch;

            zoom(difference * 0.1f);
        }


        //rotation and movement 2d
        else if (Input.GetMouseButton(1))
        {
            float mousePosX = Input.mousePosition.x;
            float mousePosY = Input.mousePosition.y;
            float scrollDistance = 5f;
            if (mousePosX < scrollDistance)
            {
                transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
            }
            if (mousePosX >= Screen.width - scrollDistance)
            {
                transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
            }

            if (mousePosY < scrollDistance)
            {
                transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime);
            }
            if (mousePosY >= Screen.height - scrollDistance)
            {
                transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
            }
        }

        //rotation and movement 3d
        else if (Input.GetMouseButton(0))
        {
          X += Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
          Y += Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;
        }

        Y = Mathf.Clamp(Y, 0, 80);
        transform.rotation = Quaternion.Euler(Y, X, Z);

        //Mouse 3d zoom controler
        zoom(Input.GetAxis("Mouse ScrollWheel"));
        Flat();
    }

    void zoom(float increment)
    {
        if (increment > 0.1)
        {
            transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime);
        }
        if (increment < -0.1)
        {

            transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
        }
    }

    //Scroll changes for apartment
    void Flat()
    {
        if (Y >= 75 && transform.position.y > 6505f)
        {
            apartment.transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
        else
        {
            apartment.transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        }

        //Dynamic wall height changes
        /*switch (Y)
        {
            case float n when(Y<10):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                break;
            case float n when (Y < 20):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.85f, transform.localScale.z);
                break;
            case float n when (Y < 30):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.7f, transform.localScale.z);
                break;
            case float n when (Y < 40):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.55f, transform.localScale.z);
                break;
            case float n when (Y < 50):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.4f, transform.localScale.z);
                break;
            case float n when (Y < 60):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.25f, transform.localScale.z);
                break;
            case float n when (Y <= 80):
                apartment.transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
                break;
            default: 
                apartment.transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                break;
        }*/
    }

}
