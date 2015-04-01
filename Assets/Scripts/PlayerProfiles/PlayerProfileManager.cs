using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class PlayerProfileManager : MonoBehaviour
{
    private const string savedProfileDirectory = "SavedProfiles";
    private const string savedProfileFilename = "VRSteroids_Profiles.xml";

    private static PlayerProfileManager instance;
    public static VRSteroidsPlayerProfile currentPlayer;
    public static PlayerProfileManager Instance { get { return instance; } }


    public int maxNumberOfSavedProfiles = 15;



    public VRSteroidsPlayerProfile[] profiles;
    //public PlayerProfileArray array;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            gameObject.name = gameObject.name + "(PlayerProfileManager component removed)";
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadProfiles();
        }
    }

    void Start()
    {
        CreateNewCurrentPlayer();
    }

    void SaveProfiles()
    {

        var serializer = new XmlSerializer(typeof(VRSteroidsPlayerProfile[]), new XmlRootAttribute("VRSteroidsPlayerProfile"));


        string _directory = Path.Combine(Application.persistentDataPath, savedProfileDirectory);
        string _fullFilePath = Path.Combine(_directory, savedProfileFilename);

        if (!Directory.Exists(_directory))
        {
            Debug.LogError("No folder found" + _directory);
            System.IO.Directory.CreateDirectory(_directory);

        }
        else
        {
            if (!File.Exists(_fullFilePath))
            {
                Debug.LogError("No file found " + _fullFilePath);
            }


            var _stream = new FileStream(_fullFilePath, FileMode.Create);
            /*
                profiles = new PlayerProfile[maxNumberOfSavedProfiles];
                PlayerProfile _testProfile = new PlayerProfile();

                _testProfile.playerName = "Potato";
                _testProfile.timeSurvived = 31.4f;
                _testProfile.playerScore = 3000;
                profiles[0] = _testProfile;
            */

            serializer.Serialize(_stream, profiles);
            _stream.Close();
        }
    }


    [ContextMenu("Save Dummy Profiles")]
    void SaveDummyProfiles()
    {
        var serializer = new XmlSerializer(typeof(VRSteroidsPlayerProfile[]), new XmlRootAttribute("VRSteroidsPlayerProfile"));


        string _directory = Path.Combine(Application.persistentDataPath, savedProfileDirectory);
        string _fullFilePath = Path.Combine(_directory, savedProfileFilename);

        if (!Directory.Exists(_directory))
        {
            Debug.LogError("No folder found" + _directory);
            System.IO.Directory.CreateDirectory(_directory);

        }

        if (!File.Exists(_fullFilePath))
        {
            Debug.LogError("No file found " + _fullFilePath);
        }


        var _stream = new FileStream(_fullFilePath, FileMode.Create);

        profiles = new VRSteroidsPlayerProfile[maxNumberOfSavedProfiles];

        VRSteroidsPlayerProfile _testProfile = new VRSteroidsPlayerProfile();
        _testProfile.playerName = "Goku";
        _testProfile.timeSurvived = 31.4f;
        _testProfile.playerScore = 3000;

        profiles[0] = _testProfile;

        VRSteroidsPlayerProfile _testProfile1 = new VRSteroidsPlayerProfile();
        _testProfile1.playerName = "Vegeta";
        _testProfile1.timeSurvived = 41.4f;
        _testProfile1.playerScore = 1300;

        profiles[1] = _testProfile1;

        VRSteroidsPlayerProfile _testProfile2 = new VRSteroidsPlayerProfile();
        _testProfile2.playerName = "Piccolo";
        _testProfile2.timeSurvived = 51.9f;
        _testProfile2.playerScore = 2100;

        profiles[3] = _testProfile2;


        serializer.Serialize(_stream, profiles);
        _stream.Close();

    }


    public void EraseProfiles()
    {

        Debug.Log("Erasing player profiles,", this);

        var serializer = new XmlSerializer(typeof(VRSteroidsPlayerProfile[]), new XmlRootAttribute("VRSteroidsPlayerProfile"));


        string _directory = Path.Combine(Application.persistentDataPath, savedProfileDirectory);
        string _fullFilePath = Path.Combine(_directory, savedProfileFilename);

        if (!Directory.Exists(_directory))
        {
            Debug.LogError("No folder found" + _directory);
            System.IO.Directory.CreateDirectory(_directory);

        }

        if (!File.Exists(_fullFilePath))
        {
            Debug.LogError("No file found " + _fullFilePath);
        }

        var _stream = new FileStream(_fullFilePath, FileMode.Create);

        profiles = new VRSteroidsPlayerProfile[maxNumberOfSavedProfiles];


        serializer.Serialize(_stream, profiles);
        _stream.Close();

    }


    void LoadProfiles()
    {
        //profiles = new PlayerProfile[maxNumberOfSavedProfiles];
        // TODO load the saved profiles.

        var serializer = new XmlSerializer(typeof(VRSteroidsPlayerProfile[]), new XmlRootAttribute("VRSteroidsPlayerProfile"));

        string _directory = Path.Combine(Application.persistentDataPath, savedProfileDirectory);
        string _fullFilePath = Path.Combine(_directory, savedProfileFilename);


        if (!File.Exists(_fullFilePath))
        {
            //Debug.Log ("Path not found " + _fullFilePath);
            SaveDummyProfiles();
        }

        

        using (var _stream = new FileStream(_fullFilePath, FileMode.Open))
        {
            if (_stream == null)
            {
                Debug.LogError("No file found!");
            }

            else
            {
                var _loaded = serializer.Deserialize(_stream) as VRSteroidsPlayerProfile[];
                if (_loaded == null)
                {
                    Debug.Log("Null load");
                }
                else
                {
                    //Debug.Log("Loaded an array of length: " + _loaded.Length.ToString());
                    profiles = _loaded;
                }



                foreach (VRSteroidsPlayerProfile _profile in _loaded)
                {
                    if (_profile != null)
                    {
                        //Debug.Log("Found profile: " + _profile.playerName);
                    }
                }

            }
        }


    }

    public void SortPlayerIntoHighScores(VRSteroidsPlayerProfile _newProfile)
    {
        // 3-2-15 Now sorts correctly

        VRSteroidsPlayerProfile[] _newArray = profiles;
        System.Array.Resize<VRSteroidsPlayerProfile>(ref _newArray, maxNumberOfSavedProfiles + 1);


        if (_newProfile != null)
            _newArray[_newArray.Length - 1] = _newProfile;


        System.Array.Sort(_newArray,    // If X is null, return false.  If Y is null, return true, 
                   delegate(VRSteroidsPlayerProfile x, VRSteroidsPlayerProfile y)
                   {
                       if (x == null && y == null) return 0;
                       if (x == null) return 1;
                       if (y == null) return -1;
                       return -1 * x.playerScore.CompareTo(y.playerScore);
                   });
        //Debug.Log ("Sort complete");

        System.Array.Resize<VRSteroidsPlayerProfile>(ref _newArray, maxNumberOfSavedProfiles);


        profiles = _newArray;
        SaveProfiles();

    }


    [ContextMenu("Create New Current Player")]
    public void CreateNewCurrentPlayer()
    {
        //Debug.Log("creating new player");

        //Debug.Log("Current player being assigned");

        VRSteroidsPlayerProfile _newPlayer = new VRSteroidsPlayerProfile();

        currentPlayer = _newPlayer;
    }


}
