using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float turnSpeed, horizotalMove;

    //public Vector3 movement = new Vector3 (0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        horizotalMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed );
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizotalMove);
    }
    //
    /*private void OnCollisionEnter(Collision collideObject)
    {
        if(collideObject.gameObject.tag == "Coin")
        {
            Debug.Log(" Collide with coin");
            Destroy(collideObject.gameObject);
        }
    }*/
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log(" Trigger with coin");
            Destroy(other.gameObject);
        }
    }
}                       //------------ Vector3.right = (1,0,0)
                        //------------ Vector3.left = (-1,0,0)\
