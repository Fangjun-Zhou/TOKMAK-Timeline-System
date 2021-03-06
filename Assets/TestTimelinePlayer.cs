using System;
using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.EventSystem.Runtime;
using FinTOKMAK.TimelineSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

public class TestTimelinePlayer : MonoBehaviour
{
    #region Public Field

    /// <summary>
    /// The timeline to play.
    /// </summary>
    public Timeline timeline;

    /// <summary>
    /// The target TimelineSystem.
    /// </summary>
    public TimelineSystem timelineSystem;

    [TimelineEvent]
    public string targetEvent;

    #endregion

    private void Awake()
    {
        timelineSystem.RegisterEvent(targetEvent, TestEventListener);
    }

    private void OnDestroy()
    {
        timelineSystem.UnRegisterEvent(targetEvent, TestEventListener);
    }

    #region Public Methods

    /// <summary>
    /// The test method to play a timeline.
    /// </summary>
    [Button]
    public void PlayTimeline()
    {
        timelineSystem.PlayTimeline(timeline);
    }

    #endregion

    #region Private Field

    /// <summary>
    /// The test event listener.
    /// </summary>
    private void TestEventListener(IEventData data)
    {
        Debug.Log("Event invoked.");
    }

    #endregion
}
