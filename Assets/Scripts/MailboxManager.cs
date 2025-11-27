using System.Collections.Generic;
using UnityEngine;

public class MailboxManager : MonoBehaviour
{
    public static MailboxManager Instance;

    public List<Mail> mails = new List<Mail>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Sample mails added at game start
        mails.Add(new Mail("Welcome!", "Thanks for playing!", 100));
        mails.Add(new Mail("Daily Gift", "Here is your reward.", 50));
    }

    public List<Mail> GetAllMail()
    {
        return mails;
    }

    public void MarkAsRead(string id)
    {
        Mail mail = mails.Find(m => m.id == id);
        if (mail != null) mail.isRead = true;
    }

    public void Claim(string id)
    {
        Mail mail = mails.Find(m => m.id == id);
        if (mail != null) mail.isClaimed = true;
    }
}
