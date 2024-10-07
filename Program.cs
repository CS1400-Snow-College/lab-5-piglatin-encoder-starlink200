// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello! This program will allow the user to give a phrase, translate that to pig latin then encrypt it");
Console.WriteLine("Please give a phrase.");
string userPhrase = Console.ReadLine();
string[] phraseArray = userPhrase.Split();

//for each statement to create the phrase in pig latin to later encrypt phrase
string pigLatinPhrase = "";
foreach(string word in phraseArray)
{   
    switch(word[0])
    {
        case 'a':
        case 'e':
        case 'i':
        case 'o':
        case 'u':
            pigLatinPhrase += word + "way ";
            break;
        default:
            int count = 0;
            foreach(char letter in word)
            {
                if((letter.Equals('a') || letter.Equals('e') || letter.Equals('i') || letter.Equals('0') || letter.Equals('u')))
                {
                    pigLatinPhrase += word.Substring(count, word.Length - count) + word.Substring(0, count) + "ay ";
                    break;
                }
                count++;
            }
            break;
    }
}
Console.WriteLine(pigLatinPhrase);

string[] pigLatinArray = pigLatinPhrase.Split();
string encryptedPhrase = "";
foreach(string word in pigLatinArray)
{
    foreach(char letter in word)
    {
        encryptedPhrase += (char)((int)letter + 1);
    }
    encryptedPhrase += " ";
}
Console.WriteLine(encryptedPhrase);

