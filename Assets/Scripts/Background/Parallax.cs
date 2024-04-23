using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenghth, startpos;
    public GameObject camera;

    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        lenghth = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float dist = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if(temp > startpos + lenghth)
        {
            startpos += lenghth;    
        } else if (temp < startpos - lenghth) 
        { 
            startpos -= lenghth;    
        }
        
    }
}
