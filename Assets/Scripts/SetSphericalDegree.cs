using UnityEngine;using System.Collections;using System.Collections.Generic;using UnityEngine.UI;public class SetSphericalDegree : MonoBehaviour{    //半径    [SerializeField]    private float _Radius;    [SerializeField]    private float _ChildElements;    [SerializeField]    private float _AzimuthElements;    [SerializeField]    private float _InclinationElements;    /*    private void Awake()    {        Deploy();    }    */    //Inspectorの内容(半径)が変更された時に実行    /*    private void OnValidate()    {        Deploy();    }    */    // Use this for initialization    [ContextMenu("Deploy")]    private void Deploy()    {        int degree = 0;        int azimuth = 0;        int inclination = 0;        //オブジェクト間の角度差        float azimuthDiff = 360f / _AzimuthElements;        float inclinationDiff = 180f / _InclinationElements;


        //パネルオブジェクトを取得
        List<GameObject> panel_list = new List<GameObject>();        foreach (Transform panel in transform)
        {
            panel_list.Add(panel.gameObject);
        }        Debug.Log(panel_list.Count);        Debug.Log(panel_list[1].name);        //メッシュテキストを取得        List<GameObject> list = GetAllChildren.GetAll(gameObject);        Debug.Log(list.Count);

        //各オブジェクトを円状に配置
        //Vector3 childPostion = transform.position;        for (int i = 0; i < _ChildElements / _InclinationElements; i++)        {            azimuth = (int)(azimuthDiff * i);            for (int j = 0; j<_ChildElements / _AzimuthElements; j++)            {                inclination = (int)(inclinationDiff * j)-90;                GameObject obj = list[j +  (int)(i * _InclinationElements)];                obj.name = "pos(" + azimuth.ToString() + "," + (inclination).ToString() + ")";                TextMesh targetText = obj.GetComponent<TextMesh>();                targetText.text = "(" + azimuth.ToString() + ", " + (inclination).ToString() + ")";
                targetText.characterSize = 0.01f;

                //各オブジェクトを円状に配置
                Vector3 childPostion = transform.position;
                Debug.Log(childPostion);

                //Debug.Log(transform.name + "###########");
                /*
                childPostion.x = _Radius * Mathf.Sin((inclination - 90) * Mathf.Deg2Rad) * Mathf.Sin(azimuth * Mathf.Deg2Rad) + childPostion.x;
                childPostion.y = _Radius * Mathf.Cos((inclination - 90) * Mathf.Deg2Rad) + childPostion.y;
                childPostion.z = _Radius * Mathf.Sin((inclination - 90) * Mathf.Deg2Rad) * Mathf.Cos(azimuth * Mathf.Deg2Rad) + childPostion.z;
                */
                //Debug.Log(transform.name + "###########");
                childPostion.x = _Radius * Mathf.Sin(-(inclination - 90) * Mathf.Deg2Rad) * Mathf.Sin(-azimuth * Mathf.Deg2Rad) + childPostion.x;
                childPostion.y = _Radius * Mathf.Cos(-(inclination - 90) * Mathf.Deg2Rad) + childPostion.y;
                childPostion.z = _Radius * Mathf.Sin(-(inclination - 90) * Mathf.Deg2Rad) * Mathf.Cos(-azimuth * Mathf.Deg2Rad) + childPostion.z;

                //パネルの位置
                GameObject panel = panel_list[j + (int)(i * _InclinationElements)];
                panel.transform.position = childPostion;
                panel.transform.localScale = new Vector3(100f, 500f, 500f);

                //パネルの角度
                //panel.transform.localRotation = Quaternion.Euler(0, azimuth - 90, - inclination);                panel.transform.localRotation = Quaternion.Euler(0, -azimuth - 90, inclination);                Debug.Log("$2$");                //SphereToDescartes(panel_list[j + (int)(i * _InclinationElements)], azimuth, inclination);            }        }    }    public void SphereToDescartes(GameObject panel, float azimuth, float inclination)    {        //各オブジェクトを円状に配置        Vector3 childPostion = transform.position;        //Debug.Log(transform.name + "###########");        childPostion.x = _Radius * Mathf.Sin((inclination - 90) * Mathf.Deg2Rad) * Mathf.Sin(azimuth * Mathf.Deg2Rad);        childPostion.y = _Radius * Mathf.Cos((inclination - 90) * Mathf.Deg2Rad);        childPostion.z = _Radius * Mathf.Sin((inclination - 90) * Mathf.Deg2Rad) * Mathf.Cos(azimuth * Mathf.Deg2Rad);        panel.transform.position = childPostion;        panel.transform.localRotation = Quaternion.Euler(0,0 ,0);    }}