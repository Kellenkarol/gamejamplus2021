using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Range(1f,10f)]
    public float movementSpeed;
    private List<Material> layers = new List<Material>();

    Vector3 camStartPos;

    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;
        for(int c=0; c<childCount; c++)
        {
            // print(transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().material);
            layers.Add(transform.GetChild(c).gameObject.GetComponent<SpriteRenderer>().material);
        }

        camStartPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveParallax();
    }


    void MoveParallax()
    {
        Vector3 currentCamPos = Camera.main.transform.position;
        float currentCamMovement = (currentCamPos-camStartPos).x; // efeito parallax apenas na horizontal

        for(int c=0; c<layers.Count; c++)
        {
            float offset = -currentCamMovement*(layers.Count-c)*movementSpeed/1000;
            layers[c].mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
