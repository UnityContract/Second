using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WaitForTriggerPlayableAsset : PlayableAsset
{
    public ExposedReference<WaitTrigger> m_WaitTrigger;
    public double seekTime;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<WaitForTriggerPlayableBehavior>.Create(graph);
        playable.GetBehaviour().m_WaitTrigger = m_WaitTrigger.Resolve(graph.GetResolver());
        playable.GetBehaviour().seekTime = seekTime;
        return playable;
    }
}