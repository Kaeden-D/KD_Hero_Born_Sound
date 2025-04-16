using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensionsBehavior;
using TMPro;

public class GameBehavior : MonoBehaviour, IManagerBehavior
{

    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public Stack<string> lootStack = new Stack<string>();
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    public TextMeshProUGUI textSize;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textAvoid;
    public TextMeshProUGUI textItems;
    public GameObject completeLevelUI;
    public GameObject loseLevelUI;
    public GameObject infoUI;

    private string state;

    public string State
    {

        get { return state; }

        set { state = value; }

    }

    private int ItemsCollected = 0;

    public int Items
    {

        get { return ItemsCollected; }

        set
        {

            ItemsCollected = value;
            Debug.LogFormat("Items: {0}", ItemsCollected);
            textItems.text = "Items Collected: " + ItemsCollected;

            if (ItemsCollected >= maxItems)
            {

                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;

            }
            else
            {

                labelText = "Item found, only " + (maxItems - ItemsCollected) + " more to go!";

            }

        }

    }

    private float PlayerSize = 1f;

    public float Size
    {

        get { return PlayerSize; }

        set
        {

            PlayerSize = value;
            Debug.LogFormat("Size: {0}", PlayerSize);
            textSize.text = "Player Size: " + PlayerSize;

        }

    }

    private int BulletDamage = 1;

    public int Damage
    {

        get { return BulletDamage; }

        set
        {

            BulletDamage = value;
            Debug.LogFormat("Damage: {0}", BulletDamage);

        }

    }

    private int PlayerHP = 10;

    public int HP
    {

        get { return PlayerHP; }

        set
        {

            PlayerHP = value;
            Debug.LogFormat("Lives: {0}", PlayerHP);
            textHealth.text = "Player Health: " + PlayerHP;

            if (PlayerHP <= 0)
            {

                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;

            }
            else
            {

                labelText = "Ouch... that's got hurt.";

            }

        }

    }

    private bool EnemyAvoid = false;

    public bool Avoid
    {

        get { return EnemyAvoid; }

        set 
        { 

            EnemyAvoid = value; 
            textAvoid.text = "Enemy Avoiding: " + EnemyAvoid;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        Items = Items;
        HP = HP;
        Size = Size;
        Avoid = Avoid;

        Initialize();
        InventoryList<string> inventoryList = new InventoryList<string>();

        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);

    }
    
    void Update()
    {

        if (showWinScreen)
        {
            completeLevelUI.SetActive(true);
            HideInfo();
        }
        else if(showLossScreen)
        {
            loseLevelUI.SetActive(true);
            HideInfo();
        }

    }

    public void HideInfo()
    {

        infoUI.SetActive(false);

    }

    public void Initialize()
    {

        state = "Manager initialized..";
        state.FancyDebug();
        Debug.Log(state);

        debug(state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;

        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");

    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
    }

    public static void Print(string newText)
    {

        Debug.Log(newText);

    }

    public void LogWithDelegate(DebugDelegate del)
    {

        del("Delegating the debug task...");

    }


    /*
    void OnGUI()
    {

        GUI.Box(new Rect(20, 20, 150, 25), "Player Size: " + PlayerSize);
        GUI.Box(new Rect(20, 50, 150, 25), "Player Health: " + PlayerHP);
        GUI.Box(new Rect(20, 80, 150, 25), "Enemy Avoiding: " + EnemyAvoid);
        GUI.Box(new Rect(20, 110, 150, 25), "Items Collected: " + ItemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {

                Utilities.RestartLevel(0);

            }

        }

        if (showLossScreen)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {

                try
                {

                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully...");

                }
                catch (System.ArgumentException e)
                {

                    Utilities.RestartLevel(0);
                    debug("Reverting to scene 0: " + e.ToString());

                }
                finally
                {

                    debug("Restart handled...");

                }

            }

        }

    }
    */

    public void PrintLootReport()
    {

        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a { 1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!", lootStack.Count);

    }

    public void Complete_Restart()
    {

        Debug.Log("Game Restarted");
        SceneManager.LoadScene(0);

    }

    public void Complete_Credits()
    {

        Debug.Log("Game Completed");
        SceneManager.LoadScene(2);

    }

}
