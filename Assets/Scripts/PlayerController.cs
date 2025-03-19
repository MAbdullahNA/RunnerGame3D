using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    //public Vector3 movement = new Vector3 (0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
