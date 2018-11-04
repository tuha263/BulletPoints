using System.Collections;
using System.Collections.Generic;
using System.Linq;
using strange.extensions.mediation.impl;
using UnityEngine;

public class EmoListMediator : EventMediator
{
    [Inject] public EmoListView view { get; set; }

    [Inject] public IEmoDataManager emoDataManager { get; set; }
    private List<Sprite> emoSprites;

    public override void OnRegister()
    {
    }

    public void Start()
    {
        LoadEmosFromResource();
    }

    private void LoadEmosFromResource()
    {
        view.PopulateEmos(emoDataManager.Datas);
        dispatcher.Dispatch(GameEvent.OnInitStaff);
    }
}