using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Quebracabeca : MonoBehaviour
{
    Touch touch;
    Vector3 pos;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            pos = Camera.main.ScreenToViewportPoint(touch.position);

            
            if(touch.phase == TouchPhase.Began )
            {
                if (transform.position == pos)
                {
                    transform.position = pos;
                }
            }            
        }
    }
}
