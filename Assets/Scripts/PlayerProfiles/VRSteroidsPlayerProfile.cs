using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


//[System.Serializable, XmlRoot(Namespace = "VRSteroids", ElementName = "PlayerProfile", DataType = "PlayerProfile", IsNullable=true)]
//[System.Serializable, XmlRoot(DataType = "VRSteroidsPlayerProfile", ElementName = "VRSteroidsPlayerProfile", Namespace="VRSteroids")]
[System.Serializable, XmlRoot("VRSteroidsPlayerProfile")]
public class VRSteroidsPlayerProfile {

    [XmlAttribute("name")]
    public string playerName;
    
    [XmlAttribute("score")]
    public int playerScore = 0;
    
    public float timeGameStarted = 0;
    public float timeGameEnded = 0;

    

    public float timeSurvived = 0;

    public int wavesSurvived = 0;
    public int asteroidsDestroyed = 0;
    
    public VRSteroidsPlayerProfile()
    {

    }
}
