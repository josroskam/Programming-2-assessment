class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    void Start() 
    {
        const string standardAlphabet = "abcdefghijklmnopqrstuvwxyz";
        string message = ReadString("Enter a message: ");
        string secretkey = ReadString("Enter the secret key: ");
        CreateSubstitutionAlphabet(message, secretkey);

        string encryptedMessage = ReplaceText(message, standardAlphabet, CreateSubstitutionAlphabet(secretkey, standardAlphabet));
        Console.WriteLine(encryptedMessage);

        string decryptedMessage = ReplaceText(encryptedMessage, CreateSubstitutionAlphabet(secretkey, standardAlphabet), standardAlphabet);
        Console.WriteLine(decryptedMessage);
    }

    string CreateSubstitutionAlphabet(string key, string standardAlphabet) 
    {
        string substitutionAlphabet = "";
        foreach (char letter in key)
        {
            if (!substitutionAlphabet.Contains(letter))
                substitutionAlphabet += letter;
        }

        foreach (char letter in standardAlphabet)
        {
            if (!substitutionAlphabet.Contains(letter))
                substitutionAlphabet += letter;
        }
        return substitutionAlphabet;
    }

    string ReplaceText(string input, string standardAlphabet, string substitutionAlphabet) 
    {
        string output = "";
        foreach (char letter in input)
        {
            int index = standardAlphabet.IndexOf(letter);
            if (index != -1)
                output += substitutionAlphabet[index];
            else
                output += letter;
        }
        return output;
    }

    string ReadString(string question)
    {
        Console.Write(question); 
        return Console.ReadLine();
    }
}