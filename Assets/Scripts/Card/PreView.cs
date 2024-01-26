using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool EnablePreview = true;
    private Vector3 savePos;
    private Quaternion saveRotation;
    private Vector3 saveScale;
    [SerializeField]private float pointerEnterScale = 1.2f;
    [SerializeField]private float pointerEnterY = 15.0f;

    
    private DragNoTarget dragNoTarget;
    private void Awake()
    {
        if (GetComponent<DragNoTarget>() != null)
        {
            dragNoTarget = GetComponent<DragNoTarget>();
        }
        else
        {
            Debug.Log("没有添加拖拽脚本");
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        SaveCardSate();
        // Debug.Log("Mouse Enter");
        if (EnablePreview)
            StartPreView();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Mouse Exit");
        if (EnablePreview)
            EndPreView();
    }

    private void StartPreView()
    {
        transform.localPosition = savePos + Vector3.up * pointerEnterY;
        transform.localScale = saveScale * pointerEnterScale;
    }

    private void EndPreView()
    {
        transform.localPosition = savePos;
        transform.localScale = saveScale;
    }

    public void DragPreview()
    {
        //1.关闭普通预览功能
        EnablePreview = false;
        //2.进入拖拽预览状态
        StartDragPreView();
    }

    public void EndDrag()
    {
        transform.localPosition = savePos;
        transform.localRotation = saveRotation;
        transform.localScale = saveScale;
        EnablePreview = true;
    }

    private void StartDragPreView()
    {
        transform.localRotation = Quaternion.identity;
        transform.localScale = saveScale * pointerEnterScale;
    }

    private void SaveCardSate()
    {
        if (!dragNoTarget.dragging)
        {
            savePos = transform.localPosition;
            saveRotation = transform.localRotation;
            saveScale = transform.localScale;
        }
    }
}
