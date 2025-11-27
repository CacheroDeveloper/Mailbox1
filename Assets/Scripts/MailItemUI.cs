using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailItemUI : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text statusText;

    private string mailId;

    public void Setup(Mail mail)
    {
        mailId = mail.id;

        titleText.text = mail.title;
        statusText.text = mail.isRead ? "Read" : "Unread";

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() =>
        {
            MailboxUI.Instance.ShowMailDetail(mail);
        });
    }
}
