[System.Serializable]
public struct Card
{
    public string name;
    public string info;
    public string imagePath;
    public int attack;
    public int defence;
    public int id;

    public Card(string name, string info, string imagePath, int attack, int defence, int id)
    {
        this.name = name;
        this.info = info;
        this.imagePath = imagePath;
        this.attack = attack;
        this.defence = defence;
        this.id = id;
    }
}