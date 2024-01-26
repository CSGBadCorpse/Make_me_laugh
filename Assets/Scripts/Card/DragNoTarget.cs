using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragNoTarget : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragging = false;
    private bool selectMode = true;


    private PreView preView;
    private void Awake()
    {
        if (GetComponent<PreView>() != null)
        {
            preView = GetComponent<PreView>();
        }
        else
        {
            Debug.Log("没找到Preview组件");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!dragging)
            {
                // Debug.Log("按住鼠标左键");
                dragging = true;
                selectMode = false;
                //开始拖拽状态的预览
                preView.DragPreview();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("松开鼠标左键");
        selectMode = true;
        EndThisDrag();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //点击鼠标左键
        if (selectMode && eventData.button == PointerEventData.InputButton.Left)
        {
            if (!dragging)
            {
                // Debug.Log("选取");
                dragging = true;
                //开始拖拽状态的预览
                preView.DragPreview();
            }
        }
        //点击鼠标右键
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (dragging)
            {
                EndThisDrag();
            }
            else
            {
                Debug.Log("检视卡牌");
            }
        }
    }

    private void EndThisDrag()
    {
        // Debug.Log("取消拖拽");
        dragging = false;
        preView.EndDrag();

        // check if the card is in the battlefield
        // if not, return to the hand
        // if yes, do nothing
        if (transform.parent.name != "Battlefield")
        {
            transform.SetParent(GameObject.Find("CardHand").transform);
        }
    }

    private void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = Input.mousePosition;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }
}
