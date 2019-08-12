using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * レーザーポインターを出すクラス
 */
public class LaserPointer_oculus : MonoBehaviour
{

    [SerializeField]
    private Transform _RightHandAnchor; // 右手

    [SerializeField]
    private Transform _LeftHandAnchor;  // 左手

    [SerializeField]
    private Transform _CenterEyeAnchor; // 目の中心

    [SerializeField]
    private float _MaxDistance = 100.0f; // 距離
    private float _MinDistance = 0.0f;

    [SerializeField]
    private LineRenderer _LaserPointerRenderer; // LineRenderer

    // コントローラー
    private Transform Pointer
    {
        get
        {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote)
            {
                return _RightHandAnchor;
            }
            else if (controller == OVRInput.Controller.LTrackedRemote)
            {
                return _LeftHandAnchor;
            }
            // どちらも取れなければ目の間からビームが出る
            return _CenterEyeAnchor;
        }
    }

    void Update()
    {
        var pointer = Pointer; // コントローラーを取得
                               // コントローラーがない or LineRendererがなければ何もしない
        if (pointer == null || _LaserPointerRenderer == null)
        {
            return;
        }

        // コントローラーのトリガー
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            // コントローラー位置からRayを飛ばす
            Ray pointerRay = new Ray(pointer.position, pointer.forward);

            // レーザーの起点
            _LaserPointerRenderer.SetPosition(0, pointerRay.origin);

            RaycastHit hitInfo;
            if (Physics.Raycast(pointerRay, out hitInfo, _MaxDistance))
            {
                // Rayがヒットしたらそこまで
                _LaserPointerRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
                _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
            }
        }
        else{
            // コントローラー位置からRayを飛ばす
            Ray pointerRay = new Ray(pointer.position, pointer.forward);
            // レーザーの起点
            _LaserPointerRenderer.SetPosition(0, pointerRay.origin);
            // コントローラーのトリガー無しの場合、Rayが向いている方向にMinDistance（０）
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MinDistance);
        }
    }
}
