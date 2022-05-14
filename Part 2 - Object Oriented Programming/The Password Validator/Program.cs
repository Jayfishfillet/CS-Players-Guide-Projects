Console.Title = "The Password Validator";

while (true)
{
    Console.Write("Pick a password: ");
    string mypass = Console.ReadLine();
    PasswordValidator myPassword = new PasswordValidator(mypass);
    myPassword.ValidationChecker();
}

 

class PasswordValidator
{
    public string Password { get; set; }
    public bool IsUpper { get; set; }
    public bool IsLower { get; set; }
    public bool IsDigit { get; set; }
    public bool Disallowed { get; set; }

    public PasswordValidator(string password)
    { 
        Password = password;
    }
    public void ValidationChecker()
    {
        PasswordLengthChecker(Password);
        UpperValidator(Password);
        LowerValidator(Password);
        DigitValidator(Password);
        DisallowedCharChecker(Password);

        if (IsUpper == true && IsLower == true && IsDigit == true && Disallowed == false)
        {
            Console.WriteLine("Password is valid.");
        }
        else if (IsUpper == false && IsLower == true && IsDigit == true)
        {
            Console.WriteLine("Password Invalid: there must be an upper case letter.");
        }
        else if (IsUpper == true && IsLower == false && IsDigit == true)
        {
            Console.WriteLine("Password Invalid: there must be a lower case letter.");
        }
        else if (IsUpper == true && IsLower == true && IsDigit == false)
        {
            Console.WriteLine("Password Invalid: there must be a digit.");
        }
        else if (Disallowed == true)
        {
            Console.WriteLine("Password Invalid: forbidden character is used.");
        }
        else
        {
            Console.WriteLine("Password Invalid: there must be an upper case letter, a lower case letter, and a digit\n");
        }
    }

    public void DisallowedCharChecker(string password)
    {
        if (Disallowed = password.Contains('T'))
        {
            Console.WriteLine("Unable to create a password with the Letter \'T\'");
            Disallowed = true;
        }
        else if (Disallowed = password.Contains('%'))
        {
            Console.WriteLine("Unable to create a password with the symbol: \'%\'");
            Disallowed = true;
        }
        else
        {
            Disallowed = false;
        }
    }

    public void PasswordLengthChecker(string mypass)
    {
        while (mypass.Length < 6 || mypass.Length > 13)
        {
            if (mypass.Length < 6)
            {
                Console.Write("Password is too short, it must be 6 characters long. ");
                mypass = Console.ReadLine();
            }
            else if (mypass.Length > 13)
            {
                Console.Write("Password is too long, it must be less than 13 characters long. ");
                mypass = Console.ReadLine();
            }
        }
    }

    public void UpperValidator(string password)
    {
        foreach (char Character in password)
        {
            if (char.IsUpper(Character))
            { 
                IsUpper = true;
            }
        }
    }

    public void LowerValidator(string password)
    {
        foreach (char Character in password)
        {
            if (char.IsLower(Character))
            {
                IsLower = true;
            }
        }
    }

    public void DigitValidator(string password)
    {
        foreach (char Character in password)
        {
            if (char.IsDigit(Character))
            {
                IsDigit = true;
            }
        }
    }
}