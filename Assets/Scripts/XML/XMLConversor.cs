using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XMLConversor : MonoBehaviour
{
    public void SaveData()
    {
        DataManager player = new DataManager();
        player.levels = playerValues.levelsUnlocked;

        XmlSerializer serializer = new XmlSerializer(player.GetType());
        StreamWriter writer = new StreamWriter("data.xml");
        serializer.Serialize(writer, player);
        writer.Close();
    }
}
