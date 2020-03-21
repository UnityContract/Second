using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTrigger : MonoBehaviour
{
    bool recieveRayCast;
    public new Camera camera;
    Ray ray;
    RaycastHit hit;
    double time;
    public Highlighter highlighter;
    public SpriteRenderer circleSprite;
    private void OnEnable()
    {
        recieveRayCast = false;
        t = 0;
    }

    public void Open(double time)
    {
        recieveRayCast = true;
        this.time = time;
        highlighter.TweenStart();
    }

    public void Close()
    {
        recieveRayCast = false;
        highlighter.TweenStop();
    }
    float t = 0;
    void Update()
    {
        if (recieveRayCast)
        {
            ray = new Ray(camera.transform.position, camera.transform.forward);
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform == transform)
                {
                    t += Time.deltaTime;
                }
                else
                {
                    t = 0;
                }
            }
            else
            {
                t = 0;
            }
            circleSprite.sharedMaterial.SetFloat("_Fill", t / 1.5f);
            if (t > 1.5f)
            {
                Close();
                recieveRayCast = false;
                MySceneDirector.Instance.Seek(time);
                circleSprite.sharedMaterial.SetFloat("_Fill", 0);
            }
        }
    }
}
