using UnityEngine;

public class CoverSequencePress : MonoBehaviour
{
    //Dancepad Controller
    public string buttonToPress;
    public KeyCode keyToPress;

    string controllerString;
    int RandomController;

    //Light Sprite
    public Sprite newSprite;
    SpriteRenderer sp;

    public bool buttonPressed;

    //Audio
    public AudioSource audioSource;

    public void Awake()
    {
        controllerString = "Joystick" + RandomController + buttonToPress;

        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);
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
            RandomizeController();
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

    void RandomizeController()
    {
        int ddrPad = GameManager.DDR_PAD_NUM;
        int controller = GameManager.CONTROLLER_NUM;

        if (Random.value > .5)
        {
            RandomController = ddrPad;
        }
        else
        {
            RandomController = controller;
        }
    }

}

