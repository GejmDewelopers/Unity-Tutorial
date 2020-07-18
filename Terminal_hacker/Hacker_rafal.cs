using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string[] easyPasswords = { "kupcia", "penis", "dupa", "klucz" };
    string[] mediumPasswords = { "lunapark", "sześćdziewięć", "ziemniaki", "butelka" };
    string[] hardPasswords = { "konstantynopol", "dupskość", "konstantynopolitańczykowianeczka", "dupkościonopolitańczykowianeczka" };
    string currentPassword;
    string currentPasswordAnagram; //do przypominania

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Select difficulty:");
        Terminal.WriteLine("1. Easy");
        Terminal.WriteLine("2. Medium");
        Terminal.WriteLine("3. Hard");
    }

    void OnUserInput(string input)
    {
        if (input == "menu" || currentScreen==Screen.Win)
        {
            level = 0;
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            if (input == "help") {
                Terminal.ClearScreen();
                Terminal.WriteLine("Password anagram: " + currentPasswordAnagram);
            }
            else
            {
                CheckPassword(input);
            }
        }
    }

    void CheckPassword(string input)
    {
        if(input == currentPassword)
        {
            Win();
        }
        else
        {
            Terminal.WriteLine("Wrong,'help' to show anagram again");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        switch (level){
            case 1:
                currentPassword = randomPassMethod(easyPasswords);
                break;
            case 2:
                currentPassword = randomPassMethod(mediumPasswords);
                break;
            case 3:
                currentPassword = randomPassMethod(hardPasswords);
                break;
            default:
                currentPassword = "An error has occured!";
                break;
        }
        Terminal.WriteLine("you have chosen level " + level);
        currentPasswordAnagram = currentPassword.Anagram();
        Terminal.WriteLine("Password anagram: " + currentPasswordAnagram);
        Terminal.WriteLine("Please enter your password");
    }

    string randomPassMethod(string[] tab)
    {
        int randomNumber = Random.Range(0, tab.Length);
        return tab[randomNumber];
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            print("You chose easy mode");
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            print("You chose medium mode");
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            print("You chose hard mode");
            level = 3;
            StartGame();
        }
        else if (input == "69")
        {
            print("Ty zbereźniczku!");
        }
        else if (input == "420")
        {
            print("Are you zasiepaned?");
        }
        else
        {
            print("Insert a correct value");
        }
    }
    void Win()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Congratulations, you won!");
        Terminal.WriteLine("Press enter to play again");
    }
}
