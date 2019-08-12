﻿using UnityEngine;


        //パネルオブジェクトを取得
        List<GameObject> panel_list = new List<GameObject>();
        {
            panel_list.Add(panel.gameObject);
        }

        //各オブジェクトを円状に配置
        //Vector3 childPostion = transform.position;
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
                //panel.transform.localRotation = Quaternion.Euler(0, azimuth - 90, - inclination);