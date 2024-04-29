using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenghth, startpos;
    public GameObject cam;

    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        lenghth = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

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
