using System.Collections.Generic;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum NotePositionType
{
    Left,
    Right,
    Center
}

public class NodeTileView : View
{
    private const float MoveTime = 0.3f;
    private const float LeftPosition = -18;
    private const float RightPosition = 18;

    [SerializeField] private Image icon;
    [SerializeField] private Button button;
    [Inject] public IGameStateData gameStateData { get; set; }


    public EmoTileData emoTileData =>
        gameStateData.collumDatas[nodeCollumTileView.nodeCollumTileData.columnIndex].emoDatas[index];

    public NodeCollumTileView nodeCollumTileView { get; private set; }
    public int index { get; private set; }

    public NotePositionType positionType;

    private bool isSetable => nodeCollumTileView.nodeCollumTileData.isSetable;
    
    public void AddOnclickListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public void SetData(EmoTileData emoTileData)
    {
        icon.transform.SetLocalPositionX(0);
        positionType = NotePositionType.Center;
        icon.gameObject.SetActive(emoTileData != null);
        if (emoTileData == null)
        {
            if (!isSetable)
            {
                button.image.color = new Color(0, 0, 0, 50);
                button.interactable = isSetable;
            }

            return;
        }

        icon.sprite = emoTileData.sprite;
    }

    public void MoveNoteToLeft()
    {
        icon.transform.DOLocalMoveX(LeftPosition, MoveTime);
        positionType = NotePositionType.Left;
    }

    public void MoveNoteToRight()
    {
        icon.transform.DOLocalMoveX(RightPosition, MoveTime);
        positionType = NotePositionType.Right;
    }

    public void MoveToNoteToCenter()
    {
        icon.transform.DOLocalMoveX(0, MoveTime);
        positionType = NotePositionType.Center;
    }

    public void OnClick()
    {
        //Todo - do move effect
    }

    public void Init(int index, NodeCollumTileView nodeCollumTileView)
    {
        this.nodeCollumTileView = nodeCollumTileView;
        this.index = index;
    }

    public void SetSetable()
    {
        if (emoTileData != null && isSetable == false)
        {
            return;
        }

        button.image.color = isSetable ? new Color(255, 255, 255, 255) : new Color(0, 0, 0, 50);
        button.interactable = isSetable;
    }

    public void OnPlay()
    {
        if (emoTileData == null)
        {
            return;
        }

        transform.DOScale(Vector3.one * 1.2f, 0.2f).OnComplete(() => transform.DOScale(Vector3.one, 0.2f));
    }
}