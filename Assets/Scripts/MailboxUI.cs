using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailboxUI : MonoBehaviour
{
    public static MailboxUI Instance;

    [Header("List View")]
    public GameObject mailItemPrefab;
    public Transform mailListContent;

    [Header("Detail View")]
    public TMP_Text titleText;
    public TMP_Text messageText;
    public Button claimButton;

    private string currentMailId;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        RefreshList();
    }

    public void RefreshList()
    {
        foreach (Transform child in mailListContent)
            Destroy(child.gameObject);

        foreach (Mail mail in MailboxManager.Instance.GetAllMail())
        {
            GameObject item = Instantiate(mailItemPrefab, mailListContent);
            item.GetComponent<MailItemUI>().Setup(mail);
        }
    }

    public void ShowMailDetail(Mail mail)
    {
        currentMailId = mail.id;

        titleText.text = mail.title;
        messageText.text = mail.message;

        MailboxManager.Instance.MarkAsRead(mail.id);
        RefreshList();

        claimButton.interactable = !mail.isClaimed;

        claimButton.onClick.RemoveAllListeners();
        claimButton.onClick.AddListener(() =>
        {
            ClaimMail(mail);
        });
    }

    private void ClaimMail(Mail mail)
    {
        MailboxManager.Instance.Claim(mail.id);

        Debug.Log($"Received reward: {mail.rewardAmount}");

        claimButton.interactable = false;
        RefreshList();
    }
}
