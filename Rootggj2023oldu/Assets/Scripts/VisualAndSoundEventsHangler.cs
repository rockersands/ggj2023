using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VisualAndSoundEventsHangler : MonoBehaviour
{
    public static VisualAndSoundEventsHangler instance;
    public PlayableDirector timelineFirstCutscene;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }
    public GameObject gameScene;
    public GameObject MainManu;
    public Animator screenTransitionAnim;
    public void ScreenTransition()
    {
        screenTransitionAnim.SetTrigger("Transition");
        AudioController.PlaySfx(AudioController.Sfx.transition);
    }
    public void PlayTimelineCinematicStart()
    {
        timelineFirstCutscene.Play();
    }
    public void HoverSelection()
    {
        Debug.Log("hi");
        AudioController.PlaySfx(AudioController.Sfx.hover);
    }
    public void SelectButton()
    {
        AudioController.PlaySfx(AudioController.Sfx.selectMenu);
    }
    public void StartGame()
    {
        AudioController.PlaySfx(AudioController.Sfx.startGame);
    }
}
