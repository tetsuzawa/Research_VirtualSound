using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEventControler : MonoBehaviour
{
    protected Color white;
    public Color green;
    public Color grey;


    public void onPointerClick(BaseEventData data)
    {

        Debug.Log("clicked");

    }

    public void OnHoverEnter(Transform t)
    {
        Debug.Log("OnHoverEnter");
        white = t.gameObject.GetComponent<Renderer>().material.color;
        t.gameObject.GetComponent<Renderer>().material.color = grey;

    }

    public void OnHover(Transform t){
        //t.gameObject.GetComponent<Renderer>().material.color = cyan;
    }

    public void OnHoverExit(Transform t)
    {
        Debug.Log("OnHoverExit");
        t.gameObject.GetComponent<Renderer>().material.color = white;
}

    public void OnPrimarySelect(Transform t){
        t.gameObject.GetComponent<Renderer>().material.color = green;
    }

    public void OnSecondarySelect(Transform t)
    {
        t.gameObject.GetComponent<Renderer>().material.color = white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
