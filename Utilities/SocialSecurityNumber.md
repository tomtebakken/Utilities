# Norwegian social security number (Fødselsnummer)
A Norwegian social security number (Fødselsnummer) contains veritas information. The Information that can be gotten except for if it is validly formatted is Date of Birth, year of birth (including century), Gender and the type of number (normal, D-number or H-Number). This dose not support FH numbers because it is used by the The healthcare system for uniq identification and dose not follow a person out side of the health system.

This document should give a good overview of the how to get information from a Norwegian social security number and how this library works.

## Information
Gets the available information of a norwegian social security number
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - a new SocialSecurityNumberInformation{ IsValid, DateOfBirth, Gender, BirthNumberType } class with information from a Norwegian Social Security Number
```C#
    { IsValid = true, DateOfBirth = "31.01.1923", Gender = Gender.male, BirthNumberType = "Normal" } = "31012312345".Information();true
    { IsValid = false, DateOfBirth = "01.01.0001", Gender = Gender.male, BirthNumberType = "" } = "33412312345".Information();
    { IsValid = false, DateOfBirth = "01.01.0001", Gender = Gender.male, BirthNumberType = "" } = "29022312345".Information();
```

## IsValidFormat
Checks a string based norwegian social security number (Fødselsnummer) to se if it is of a valid format. It also tacks into consideration D-numbers and H-numbers, but not FH-numbers.
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - True if the social security number is of a valid format, otherwise false.
```C#
    true = "31012312345".IsValidFormat();
    true = "71012312345".IsValidFormat();
    false = "33412312345".IsValidFormat();
    false = "29022312345".IsValidFormat(); // Returns false because this was not a leap year.
```

## WitchGender
Gets the gender information from a norwegian social security number (Fødselsnummer).
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - female if the ninth digit is even number, if not is male. if its not the correct length it returns none..
```C#
    Gender.female = "70019950032".WitchGender(); 
    Gender.male = "51111199993".WitchGender(); 
    Gender.none = "".WitchGender(); 
```

## BirthNumberType
Get what type of number the norwegian social security number (Fødselsnummer).
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - The type of number it is. If it is a not D-Number, H-Number or in error it's Normal. If the Date is larger than 40 it's a D-Number. If the Month is lager than 40 it's a H-Number. If both date and month is larger then 40 it's in error and an empty string is returned.
```C#
"Normal" = "31012312388".BirthNumberType();
"D-Number" = "71012312371".BirthNumberType();
"H-Number" = "31412312345".BirthNumberType();
```

## GetDateOfBirth
Gets the date of birth from a norwegian social security number (Fødselsnummer).
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - The Date of birth if the number is of the correct length and format
```C#
"30.01.1899" = "70019950032".GetDateOfBirth();
"11.11.1911" = "51111199993".GetDateOfBirth();
"10.06.1999" = "50069949824".GetDateOfBirth();
```

## YearOfBirth
Gets the year of birth from a Norwegian social security number (Fødselsnummer)
- Param:
    - socialSecurityNumber: Norwegian Social Security Number
- Return: 
    - 4 digit number representing the year of birth
```C#
1899 = "70019950032".GetDateOfBirth();
1911 = "51111199993".GetDateOfBirth();
1999 = "50069949824".GetDateOfBirth();
```
