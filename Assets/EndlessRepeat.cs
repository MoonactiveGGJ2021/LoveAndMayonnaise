using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRepeat : MonoBehaviour
{
    public  float      BoundsSize = 0.9f;
    public float       MaxDistance = 5;
    public  Camera     MainCamera;
    private GameObject nextInstance;
    private SpriteRenderer spriteRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var cameraBounds = MainCamera.OrthographicBounds();
        var bufferedBounds = new Bounds(cameraBounds.center, cameraBounds.size * BoundsSize);
        var ownBounds = spriteRenderer.bounds;

        var ownX = ownBounds.min.x;
        var bufferedX = bufferedBounds.min.x;

        if (ownX < bufferedX)
        {
            if (nextInstance != null)
                return;
        
        
            var pos = ownBounds.center + (new Vector3(ownBounds.size.x, 0, 0));
            nextInstance = Instantiate(gameObject,pos,transform.rotation);
            nextInstance.GetComponent<EndlessRepeat>().nextInstance = null;
        }

        if (ownX < (bufferedX - (ownBounds.size.x * MaxDistance)))
            Destroy(this);

    }
}
