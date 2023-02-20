using UnityEngine;

public class BattleSequencePress : MonoBehaviour
{
    //Dancepad Controller
    public string buttonToPress;
    public KeyCode keyToPress;

    string controllerString;

    //Light Sprite
    public Sprite newSprite;
    SpriteRenderer sp;

    public bool buttonPressed;
    public bool otherButtonPressed;

    private GameObject player;

    //Audio
    public AudioSource audioSource;

    public void Awake()
    {
        controllerString = "Joystick" + GameManager.DDR_PAD_NUM + buttonToPress;

        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            ChangeSprite();
            PlayAudio();
        }
    }

    void ChangeSprite()
    {
        sp.sprite = newSprite;
        buttonPressed = true;
    }
    void PlayAudio()
    {
        audioSource.Play();
    }

}

