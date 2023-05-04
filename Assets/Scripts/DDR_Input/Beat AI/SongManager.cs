using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public Transform parent;

    //Song beats per minute
    public float bpm;
    //The number of seconds for each song beat
    public float spb;
    public float songPos;
    public float songPosInBeat;
    //How many seconds have passed since the song started
    public float dspSongTime;

    public AudioSource musicSource;

    //Offbeat
    public float firstBeatOffset;

    //Loop
    //the number of beats in each loop
    public float bpl;
    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;
    //The current position of the song within the loop in beats.
    public float loopPosInBeats;

    //Loop Pos
    public float loopPositionInAnalog;

    //Conductor instance
    public static SongManager instance;

    //Spawn Note
    public GameObject[] NotePrefab;
    public Transform[] NoteTransform;
    public int randListObject;

    //Chance
    public float percentChance;

    //Note List
    //public List<GameObject> notes;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //musicSource = GetComponent<AudioSource>();
        spb = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    /*
    private void OnDisable()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            Destroy(notes[i]);
            notes.Remove(notes[i]);
            break;
        }
    }
    */
    private void Update()
    {
        loopPositionInAnalog = loopPosInBeats / bpl;

        songPos = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        songPosInBeat = songPos / spb;

        //calculate the loop position
        if (songPosInBeat >= (completedLoops + 1) * bpl)
        {
            completedLoops++;
            InstantiateRandNote();
        }
        loopPosInBeats = songPosInBeat - completedLoops * bpl;


    }

    void InstantiateRandNote()
    {
        randListObject = Random.Range(0, NotePrefab.Length);
        GameObject note = Instantiate(NotePrefab[randListObject], NoteTransform[randListObject].position , Quaternion.identity);
        if (Random.value > percentChance)
        {
            int randSecondNote;
            randSecondNote = Random.Range(0, NotePrefab.Length);

            if (randSecondNote != randListObject)
            {
                GameObject secondnote = Instantiate(NotePrefab[randSecondNote], NoteTransform[randSecondNote].position, Quaternion.identity);

                secondnote.transform.parent = parent.transform;
            }
        }
        note.transform.parent = parent.transform;
       // notes.Add(note);
        
    }
    

}
