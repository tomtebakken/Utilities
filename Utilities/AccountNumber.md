# Norwegian bank account number Utility
This utility is built to validate if a Norwegian bank account number is in the correct format including control digit validation. It is also built to get witch bank the Account number belongs to. 

## Support Formats
The formats this utilities support are 'xxxx yy zzzzc', 'xxxx yy.zzzzc' or 'xxxxyyzzzzc'

### Formatting description

- xxxx are the bank identifier
- yy is the account type
- zzzz are the account number
- c is a control digit. It is calculated on the basis of all 10 previous digits. The calculation is performed by  Mod 11

## IsValid
Checks is the bank Account is of a valid format. 
- Param:
    - accountNumber: Bank Account Number
- Return: 
    - true if valid
```C#
    true = "1150 12 34569".IsValid();
    true = "1150.12.34569".IsValid();
    true = "11501234569".IsValid();
    false = "115012345".IsValid(); 
```

## GetWitchBank
Checks what Bank the bank account number belongs to. It looks up if the bank using bank Identification in the JSON file Norwegian BIC-IBAN (Depending on the age this file may be out of date. It was downloaded in 2024). 
- Param:
    - accountNumber: Bank Account Number
- Return: 
    - Name of the Bank. If the bank is not found Unknown is returned
```C#
    "DNB Bank ASA" = "1150 12 34569".GetWitchBank();
    "Unknown" = "1234 12 34569".GetWitchBank();
```


