using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetDegree: MonoBehaviour
{

    // Use this for initialization
    [ContextMenu("Deploy")]
    private void Deploy()
    {

        int degree = 0;
        List<GameObject> list = GetAllChildren.GetAll(gameObject);
        Debug.Log(list.Count);
        foreach (GameObject obj in list)
        {
            obj.name = "text" + degree.ToString();
            TextMesh targetText = obj.GetComponent<TextMesh>();
            targetText.text = degree.ToString() + "°";

            degree += 5;
        }
    }

}