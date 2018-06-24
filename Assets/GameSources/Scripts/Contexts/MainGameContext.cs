using System.Collections.Generic;
using AudioHelm;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;
using UnityEngine.Audio;

public class MainGameContext : MVCSContext {
  public MainGameContext() : base() {}

  public MainGameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) {}

  protected override void mapBindings() {

    //Command
    commandBinder.Bind<SelectEmoSignal>().To<SelectEmoCommand>().Pooled();
    commandBinder.Bind<SetEmoSignal>().To<SetEmoCommand>().Pooled();
    commandBinder.Bind<PlayMusicSignal>().To<PlayMusicCommand>().Pooled();
    commandBinder.Bind<StopMusicSignal>().To<StopMusicCommand>().Pooled();

    //Model
    injectionBinder.Bind<IGameStateData>().To<GameStateData>().ToSingleton();
    injectionBinder.Bind<IEmoDataManager>().To<EmoDataManager>().ToSingleton();
    injectionBinder.Bind<IClefsDataManager>().To<ClefsDataManager>().ToSingleton();
    injectionBinder.Bind<ITimeSigsDataManager>().To<TimeSigsDataManager>().ToSingleton();
    injectionBinder.Bind<AudioHelmClock>().To<AudioHelmClock>().ToSingleton();

    //Audio mixer
    AudioMixer audioMixer = Resources.Load<AudioMixer>("AudioMixers/BulletPoints");
    injectionBinder.Bind<AudioMixer>().To(audioMixer).ToSingleton();

    //List sequencer
    Dictionary<AudioMixerGroup, MusicManagerView> sequencerDic = new Dictionary<AudioMixerGroup, MusicManagerView>();
    injectionBinder.Bind<Dictionary<AudioMixerGroup, MusicManagerView>>().To(sequencerDic).ToSingleton();

    //Singleton
    injectionBinder.Bind<MainGameContext>().To(this).CrossContext().ToSingleton();

    //view - mediator
    mediationBinder.Bind<EmoListView>().To<EmoListMediator>();
    mediationBinder.Bind<EmoTileView>().To<EmoTileMediator>();
    mediationBinder.Bind<StaffView>().To<StaffMediator>();
    mediationBinder.Bind<NodeCollumTileView>().To<NodeCollumTileMediator>();
    mediationBinder.Bind<NodeTileView>().To<NodeTileMediator>();
    mediationBinder.Bind<MusicFieldView>().To<MusicFieldMediator>();
    mediationBinder.Bind<MelodyTileView>().To<MelodyTileMediator>();
    mediationBinder.Bind<CurrentEmoView>().To<CurrentEmoMediator>();
    mediationBinder.Bind<MusicManagerView>().To<MusicManagerMediator>();
    mediationBinder.Bind<BottomMenuView>().To<BottomMenuMediator>();
    mediationBinder.Bind<TempoTileView>().To<TempoTileMediator>();
    mediationBinder.Bind<ClefTileView>().To<ClefTileMediator>();
    mediationBinder.Bind<TimeSigTileView>().To<TimeSigTileMediator>();
  }

  protected override void addCoreComponents() {
    base.addCoreComponents();
    injectionBinder.Unbind<ICommandBinder>();
    injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
  }
}