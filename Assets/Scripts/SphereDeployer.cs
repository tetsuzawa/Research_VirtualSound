using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDeployer : MonoBehaviour
{
    //半径
    [SerializeField]
    private float _radius;

    private void Awake()
    {
        Deploy();
    }

    //Inspectorの内容(半径)が変更された時に実行
    private void OnValidate()
    {
        Deploy();
    }

    [ContextMenu("Deploy")]
    private void Deploy()
    {
        List<List<GameObject>> childList = new List<List<GameObject>>();
        //水平方向の子のリスト
        List<GameObject> azim_childList = new List<GameObject>();
        //鉛直方向の子のリスト
        List<GameObject> incl_childList = new List<GameObject>();

        foreach (Transform azim_child in transform)
        {
            azim_childList.Add(azim_child.gameObject);

            foreach (Transform incl_child in azim_child)
            {
                incl_childList.Add(incl_child.gameObject);

            }
        }

        //オブジェクト間の角度差
        float azimuthDiff = 360f / (float) azim_childList.Count;
        float inclinationDiff = 180f / (float) incl_childList.Count * (float) azim_childList.Count;

        Debug.Log(azim_childList.Count);
        Debug.Log(incl_childList.Count);

        //各オブジェクトを円状に配置
        Vector3 childPostion = transform.position;

        for (int i = 0; i < azim_childList.Count; i++)
        {
            float azimuth = (azimuthDiff * i) * Mathf.Deg2Rad;

            for (int j = 0; j < incl_childList.Count * azim_childList.Count; j++)
            {
                float inclination = (inclinationDiff * j) * Mathf.Deg2Rad;
                //childPostion.x = _radius * Mathf.Cos(azimuth) * Mathf.Cos(inclination);
                //childPostion.y = _radius * Mathf.Sin(inclination);
                //childPostion.z = _radius * Mathf.Sin(azimuth) * Mathf.Cos(inclination);
                childPostion.x = _radius * Mathf.Sin(inclination) * Mathf.Sin(azimuth);
                childPostion.y = _radius * Mathf.Cos(inclination);
                childPostion.z = _radius * Mathf.Sin(inclination) * Mathf.Cos(azimuth);

                incl_childList[j].transform.position = childPostion;
                incl_childList[j].transform.localRotation = Quaternion.Euler(0, azimuth * -i, 0);
            }
        }

    }


    

}