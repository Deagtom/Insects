using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private string _decksDirectory = "Decks";

    public void SaveDeck(List<Card> deck, string deckName)
    {
        DeckData deckData = new DeckData { playerDeck = deck };

        string json = JsonUtility.ToJson(deckData);

        string path = Path.Combine(Application.persistentDataPath, _decksDirectory, deckName + ".json");

        if (!Directory.Exists(Path.Combine(Application.persistentDataPath, _decksDirectory)))
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, _decksDirectory));
        }

        File.WriteAllText(path, json);
    }

    public List<Card> LoadDeck(string deckName)
    {
        string path = Path.Combine(Application.persistentDataPath, _decksDirectory, deckName + ".json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DeckData deckData = JsonUtility.FromJson<DeckData>(json);
            return deckData.playerDeck;
        }

        return new List<Card>();
    }

    public List<string> LoadAllDecks()
    {
        List<string> deckNames = new List<string>();
        string directoryPath = Path.Combine(Application.persistentDataPath, _decksDirectory);

        if (Directory.Exists(directoryPath))
        {
            string[] files = Directory.GetFiles(directoryPath, "*.json");

            foreach (string filePath in files)
            {
                deckNames.Add(Path.GetFileNameWithoutExtension(filePath));
            }
        }

        return deckNames;
    }
}