using strange.extensions.signal.impl;

public class SelectEmoSignal : Signal<EmoTileData> {}
public class SetEmoSignal : Signal<NodeCollumTileView, int> {}
public class PlayMusicSignal : Signal {}
public class StopMusicSignal : Signal {}
public class ChangeTempoSignal : Signal<int> {};
public class SelectTimeSigSignal : Signal<db_TimeSigsData> {};