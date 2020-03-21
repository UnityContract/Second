using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WaitForTriggerPlayableBehavior : PlayableBehaviour
{
    public WaitTrigger m_WaitTrigger;
    public double seekTime;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (m_WaitTrigger != null)
        {
            m_WaitTrigger.Open(seekTime);
        }
    }
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (m_WaitTrigger != null)
        {
            m_WaitTrigger.Close();
        }
    }
}
