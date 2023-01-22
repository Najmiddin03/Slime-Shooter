using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour

{

    public int rotationOffset = 90;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        

        if ( !PauseMenu.GameIsPaused )
        {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 20f)) - transform.position;

        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);

        if(transform.eulerAngles.z < 89 || transform.eulerAngles.z > 275)
        {
            spriteRenderer.flipY = false;
        }
        else
        {
            spriteRenderer.flipY = true;
        }

        }
    }

    
    
}
