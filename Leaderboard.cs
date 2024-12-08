namespace Game;

public class LeaderBoard
{
    public string Username;
    public int Points;

    public List<(string Username, int Points)> entries;
    
    public LeaderBoard()
    {
        entries = new List<(string Username, int Points)>();
    }

    public void AddUser(string username, int points)
    {
        
        
        for (int i = 0; i < entries.Count; i++) // checking if user exists, .Count - counts the amount of entries
        {
            if (entries[i].Username == username)
            {
                // Update the user's score
                entries[i] = (username, entries[i].Points + points);
                return;
            }
        }
        entries.Add((username, points));
    }
}

