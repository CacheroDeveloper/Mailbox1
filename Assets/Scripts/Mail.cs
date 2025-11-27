using System;

[Serializable]
public class Mail
{
    public string id;
    public string title;
    public string message;
    public bool isRead;
    public bool isClaimed;
    public int rewardAmount; // example reward (e.g., coins)

    public Mail(string title, string message, int rewardAmount)
    {
        this.id = Guid.NewGuid().ToString();
        this.title = title;
        this.message = message;
        this.rewardAmount = rewardAmount;
        this.isRead = false;
        this.isClaimed = false;
    }
}
