// See https://aka.ms/new-console-template for more information
Random rand = new Random();
Console.WriteLine("Hello! This program will allow the user to give a phrase, translate that to pig latin then encrypt it");
string userPhrase = "";
string[] phraseArray = {""};
bool numberFound = true;
string pigLatinPhrase = "";
while(numberFound)
{
    numberFound = false;
    Console.WriteLine("Please give a phrase.");
    userPhrase = Console.ReadLine();
    phraseArray = userPhrase.Split();
    for(int i = 0; i < userPhrase.Length; i++)
    {
        string letter = userPhrase.Substring(i,1);
        numberFound = int.TryParse(letter, out int nums);
        if(numberFound)
        {
            break;
        }
    }
}

//for each statement to create the phrase in pig latin to later encrypt phrase
if(!numberFound)
{

    foreach(string word in phraseArray)
    {
        switch(word[0])
        {
            case 'a'or 'A':
            case 'e':
            case 'i' or 'I':
            case 'o':
            case 'u':
            case 'y':
                pigLatinPhrase += word + "way ";
                break;
            default:
                int count = 0;
                bool leaveForEach = false;
                foreach(char letter in word)
                {
                    switch(letter)
                    {
                        case 'q':
                            pigLatinPhrase += word.Substring(count + 2, word.Length - count - 2) + word.Substring(0, count + 2) + "ay ";
                            leaveForEach = true;
                            break;
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'y':
                            pigLatinPhrase += word.Substring(count, word.Length - count) + word.Substring(0, count) + "ay ";
                            leaveForEach = true;
                            break;
                        default:
                            break;
                    }
                    //once the word is changed we want the foreach loop to stop
                    if(leaveForEach)
                    {
                        break;
                    }
                    count++;
                }
                break;
        }
    }
    Console.WriteLine(pigLatinPhrase);

    //using nested for each statement to shift each letter by a certain number
    string[] pigLatinArray = pigLatinPhrase.Split();
    string encryptedPhrase = "";
    //random number for the encryption off set
    int randOffSet = rand.Next(1, 25);
    foreach(string word in pigLatinArray)
    {
        foreach(char letter in word)
        {
            if((int)letter + randOffSet < 123){
                encryptedPhrase += (char)((int)letter + randOffSet);
            }
            else
            {
                encryptedPhrase += (char)((int)letter + randOffSet - 26);
            }
        }
        encryptedPhrase += " ";
    }
    Console.WriteLine(encryptedPhrase);
}
