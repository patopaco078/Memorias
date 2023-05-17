using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNotesHandler : MonoBehaviour
{
    [SerializeField] AudioSource[] musicNotesSources;
    [SerializeField] AudioSource badNoteSource;
    [SerializeField] float fadeInTime = 0.1f;
    [SerializeField] float fadeOutTime = 0.5f;

    public void PlayNote(int violinNote)
    {
        StopAllCoroutines();
        StartCoroutine(NoteFadeIn(violinNote));
    }

    public void StopNote(int violinNote)
    {
        StartCoroutine(NoteFadeOut(violinNote));
    }

    public void PlayBadNote()
    {
        badNoteSource.Play();
    }

    IEnumerator NoteFadeIn(int violinNote)
    {
        if (musicNotesSources[violinNote].isPlaying) musicNotesSources[violinNote].Stop();
        yield return null;

        musicNotesSources[violinNote].Play();

        while (musicNotesSources[violinNote].volume < 1)
        {
            yield return null;

            musicNotesSources[violinNote].volume += 1 * Time.deltaTime * (1/ fadeInTime);
            musicNotesSources[violinNote].volume = Mathf.Clamp01(musicNotesSources[violinNote].volume);
        }
    }

    IEnumerator NoteFadeOut(int violinNote)
    {
        //if (!musicNotesSources[violinNote].isPlaying) musicNotesSources[violinNote].Play();
        //yield return null;

        while (musicNotesSources[violinNote].volume > 0)
        {
            yield return null;

            musicNotesSources[violinNote].volume -= 1 * Time.deltaTime * (1 / fadeOutTime);
            musicNotesSources[violinNote].volume = Mathf.Clamp01(musicNotesSources[violinNote].volume);
        }

        //musicNotesSources[violinNote].Stop();
    }
}
