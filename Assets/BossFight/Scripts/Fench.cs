using UnityEngine;

public class Fench : MonoBehaviour
{
    public bool up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 38f && !up)
        {
            transform.position += Vector3.down * Time.deltaTime * 2f;
        }

        if(transform.position.y < 45f && up)
        {
            transform.position += Vector3.up * Time.deltaTime * 2f;
        }
    }
}
