using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GetAllChildren
{
    public static List<GameObject> GetAll(this GameObject obj)
    {
        List<GameObject> allChildren = new List<GameObject>();
        List<GameObject> Children2 = new List<GameObject>();
        Get2Children(obj, ref allChildren, ref Children2);
        return Children2;
    }

    /*
    //子要素を取得してリストに追加
    public static void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren,ref Chilchildren);
        }
        return;
    }
    */

    //子要素を取得してリストに追加
    public static void Get2Children(GameObject obj, ref List<GameObject> allChildren, ref List<GameObject> Children2)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            GameObject o = ob.gameObject;
            Transform children_2 = o.GetComponentInChildren<Transform>();

            foreach (Transform oo in children_2)
            {
                Children2.Add(oo.gameObject);
            }

        }
        return;
    }
}