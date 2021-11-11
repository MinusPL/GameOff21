using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CutSceneTrigger : MonoBehaviour
{
    private PlayableDirector timeline;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
        timeline.played += Timeline_played;
        timeline.stopped += Timeline_stopped;
    }

    private void Timeline_stopped(PlayableDirector obj)
    {
        Debug.Log("Timeline Stoped!");
    }

    private void Timeline_played(PlayableDirector obj)
    {
        Debug.Log("TimeLine Played!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timeline.Play();
        }
    }
}
