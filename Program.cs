// See https://aka.ms/new-console-template for more information
Random rand = new Random();
Console.WriteLine("Hello! This program will allow the user to give a phrase, translate that to pig latin then encrypt it");
Console.WriteLine("Please give a phrase.");
string userPhrase = Console.ReadLine();
string[] phraseArray = userPhrase.Split();
bool numberFound = false;

//for each statement to create the phrase in pig latin to later encrypt phrase
string pigLatinPhrase = "";
for(int i = 0; i < userPhrase.Length - 1; i++)
{
    string letter = userPhrase.Substring(i,i+1);
    numberFound = int.TryParse(letter, out int nums);
}
if(!numberFound)
{

    foreach(string word in phraseArray)
    {
        switch(word[0])
        {
            case 'a':
            case 'e':
            case 'i':
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
