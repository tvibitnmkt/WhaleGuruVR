using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


namespace Interactive360
{

    public class MenuManager : MonoBehaviour
    {

        public Button[] m_buttonsInScene; //A reference to all the buttons in the scene that would load new scenes
        public GameObject m_menu; //A reference to the menu being rendered
        public GameObject m_playButton; //A reference to the button that toggles the video content to play
        public GameObject m_pauseButton; //A reference to the button that toggle the video content to pause

        [SerializeField] string m_oculusMenuToggle = "Button2"; //The name of the oculus button input that will toggle the scene on and off

        private AudioSource m_menuToggleAudio; //Audio clip to play when the menu is closed

        public string menuSceneString;
        public int button4counter;
        public int button5counter;
        public int button6counter;
        public int button7counter;
        public int button8counter;
        public int button9counter;

        // on Start, bind all buttons to their respective scenes and call DontDestroyOnLoad to keep the Main Menu in every scene
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            BindButtonsToScenes();
            m_menuToggleAudio = GetComponent<AudioSource>();
        }

        //call the checkForInput method once per fram
        void Update()
        {
            checkForInput();
            var currentScene = GameManager.instance.activeScene;
                currentScene = currentScene.ToString();
                        
            var level = 0;

            if(currentScene.Contains("MainMenu_Gaze")) {
                menuSceneString = currentScene.ToString();
                Debug.Log("menu is: " + menuSceneString);
            }
            
            // Debug.Log("Current scene is: " + currentScene + ". Current level is: " + level);

            if (currentScene == "3D_Waterfront" || currentScene == "3D_Waterfrontb" || currentScene == "3D_Waterfrontc"
            || currentScene == "plastic" || currentScene == "whale"
            || currentScene == "plasticb" || currentScene == "whaleb"
            || currentScene == "plasticc" || currentScene == "whalec") {
                level = 1;
            }
            if (currentScene == "3D_Waterfront2" || currentScene == "3D_Waterfrontb2" || currentScene == "3D_Waterfrontc2"
            || currentScene == "plastic2" || currentScene == "whale2"
            || currentScene == "plasticb2" || currentScene == "whaleb2"
            || currentScene == "bamboo" || currentScene == "whalec2") {
                level = 2;
            }
            if (currentScene == "3D_Waterfront3" || currentScene == "3D_Waterfrontb3" || currentScene == "3D_Waterfrontc3"
            || currentScene == "plastic3" || currentScene == "whale3"
            || currentScene == "plasticb3" || currentScene == "whaleb3"
            || currentScene == "shark" || currentScene == "whalec3") {
                level = 3;
            }

            // removes the difficulity choices if scene has changed after choosing difficulity
            if (currentScene.Contains("3D_Waterfront")) {
            m_menu.transform.localScale = new Vector3(0, 0, 0);
            }

            // Outputs any keypress to console + scene name for debugging
            if (Input.anyKey) {
                Debug.Log("Key pressed and current scene is: " + currentScene + ". Current level is: " + level);
            }

            // This section is for manually selecting difficulity if user selected the wrong difficulity using eye-gaze
            if (Input.GetKeyDown(KeyCode.Alpha1) && currentScene != "3D_Waterfront" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 1;
                print("1 key was pressed" + "Current level is: " + level);
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("3D_Waterfront");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && currentScene != "3D_Waterfront2" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 2;
                print("2 key was pressed" + "Current level is: " + level);
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("3D_Waterfront2");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && currentScene != "3D_Waterfront3" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 3;
                print("3 key was pressed" + "Current level is: " + level);
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("3D_Waterfront3");
            }
            
            // This section is for difficulity level 1
            if (level == 1 && Input.GetKeyDown(KeyCode.Alpha4) && currentScene != "plastic" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 1;
                print("4 key was pressed, play plastic.");
                button4counter++;
                if (button4counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "whale" || currentScene == "3D_Waterfront") {
                    GameManager.instance.SelectScene("plastic");
                }
                if (currentScene == "whaleb" || currentScene == "3D_Waterfrontb") {
                    GameManager.instance.SelectScene("plasticb");
                }
                if (currentScene == "whalec" || currentScene == "3D_Waterfrontc") {
                    GameManager.instance.SelectScene("plasticc");
                }
                }
                button4counter = 0;
            }
            if (level == 1 && Input.GetKeyDown(KeyCode.Alpha5) && currentScene != "whale" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 1;
                print("5 key was pressed, play whale");
                button5counter++;
                if (button5counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "plastic" || currentScene == "3D_Waterfront") {
                    GameManager.instance.SelectScene("whale");
                }
                if (currentScene == "plasticb" || currentScene == "3D_Waterfrontb") {
                    GameManager.instance.SelectScene("whaleb");
                }
                if (currentScene == "plasticc" || currentScene == "3D_Waterfrontc") {
                    GameManager.instance.SelectScene("whalec");
                }
                }
                button5counter = 0;
            }

            // This section is for difficulity level 2
            if (level == 2 && Input.GetKeyDown(KeyCode.Alpha6) && currentScene != "plastic2" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 2;
                print("6 key was pressed, play plastic2");
                button6counter++;
/*                 if (button6counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("plastic2");
                button6counter = 0;
                } */
                if (button6counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "whale2" || currentScene == "3D_Waterfront2") {
                    GameManager.instance.SelectScene("plastic2");
                }
                if (currentScene == "whaleb2" || currentScene == "3D_Waterfrontb2") {
                    GameManager.instance.SelectScene("plasticb2");
                }
                if (currentScene == "whalec2" || currentScene == "3D_Waterfrontc2") {
                    GameManager.instance.SelectScene("bamboo");
                }
                }
                button6counter = 0;
            }
            if (level == 2 && Input.GetKeyDown(KeyCode.Alpha7) && currentScene != "whale2" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 2;
                print("7 key was pressed, play whale2");
                button7counter++;
/*                 if (button7counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("whale2");
                button7counter = 0;
                } */
                if (button7counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "plastic2" || currentScene == "3D_Waterfront2") {
                    GameManager.instance.SelectScene("whale2");
                }
                if (currentScene == "plasticb2" || currentScene == "3D_Waterfrontb2") {
                    GameManager.instance.SelectScene("whaleb2");
                }
                if (currentScene == "bamboo" || currentScene == "3D_Waterfrontc2") {
                    GameManager.instance.SelectScene("whalec2");
                }
                }
                button7counter = 0;
            }

            // This section is for difficulity level 3
            if (level == 3 && Input.GetKeyDown(KeyCode.Alpha8) && currentScene != "plastic3" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 3;
                print("8 key was pressed, play plastic3");
                button8counter++;
/*                 if (button8counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("plastic3");
                button8counter = 0;
                } */
                if (button8counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "whale3" || currentScene == "3D_Waterfront3") {
                    GameManager.instance.SelectScene("plastic2");
                }
                if (currentScene == "whaleb3" || currentScene == "3D_Waterfrontb3") {
                    GameManager.instance.SelectScene("plasticb3");
                }
                if (currentScene == "whalec3" || currentScene == "3D_Waterfrontc3") {
                    GameManager.instance.SelectScene("shark");
                }
                }
                button8counter = 0;
            }
            if (level == 3 && Input.GetKeyDown(KeyCode.Alpha9) && currentScene != "whale3" && !currentScene.Contains("MainMenu_Gaze"))
            {
                level = 3;
                print("9 key was pressed, play whale3");
                button9counter++;
/*                 if (button9counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("whale3");
                button9counter = 0;
                } */
                if (button9counter >= 1) {
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                if (currentScene == "plastic3" || currentScene == "3D_Waterfront3") {
                    GameManager.instance.SelectScene("whale3");
                }
                if (currentScene == "plasticb3" || currentScene == "3D_Waterfrontb3") {
                    GameManager.instance.SelectScene("whaleb3");
                }
                if (currentScene == "shark" || currentScene == "3D_Waterfrontc3") {
                    GameManager.instance.SelectScene("whalec3");
                }
                }
                button9counter = 0;
            }

            // This section is for manually selecting the videos for "whale" and "plastic"
            if (Input.GetKeyDown(KeyCode.W) && currentScene != "whale")
            {
                print("W key was pressed");
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("whale");
            }
            if (Input.GetKeyDown(KeyCode.P) && currentScene != "plastic")
            {
                print("p key was pressed");
                m_menu.transform.localScale = new Vector3(0, 0, 0);
                GameManager.instance.SelectScene("plastic");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                print("r key was pressed, demo reset");
                // GameManager.instance.SelectScene("MainMenu_Gaze");
                m_menu.transform.localScale = new Vector3(1, 1, 1);
            }
        
        }

        //if the menu is active, turn it off. If it is inactive, turn it on
        public void toggleMenu()
        {
            m_menu.SetActive(!m_menu.activeInHierarchy);
        }

        //If we detect input, call the toggleMenu method 
        private void checkForInput()
        {
            //check for input from specified Oculus Touch button or the App button on Google Daydream Controller
            if (Input.GetButtonDown(m_oculusMenuToggle) || GvrControllerInput.AppButtonDown)
            {
                toggleMenu();

                //if we have an audio source to play with menu toggle, play it now
                if (m_menuToggleAudio)
                    m_menuToggleAudio.Play();
            }

        }

        //Toggle between showing play and pause button when once is pressed
        public void toggleButton()
        {

            m_pauseButton.SetActive(!m_pauseButton.activeInHierarchy);
            m_playButton.SetActive(!m_playButton.activeInHierarchy);

        }


        // Each button will match up to a respective scene. Button 1 in the Menu Manager will match up to Scene 1 in the Video Manager
        public void BindButtonsToScenes()
        {
            //check to see if there are the same buttons in the menu as scenes to load. if not, return an error

            if (m_buttonsInScene.Length != GameManager.instance.scenesToLoad.Length)
            {
                Debug.Log("Amount of buttons and scenes do not match!");
                return;
            }

            //otherwise bind Button 1-i from Menu Manager, to load Scene 1-i in Video Manager 
            else
            {
                for (int i = 0; i < m_buttonsInScene.Length; i++)
                {
                    string sceneName = GameManager.instance.scenesToLoad[i];
                    m_buttonsInScene[i].onClick.AddListener(() => GameManager.instance.SelectScene(sceneName));

                }
            }

        }
    }
        
    

}

