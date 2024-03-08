# Utilities
This utility is created to help getting information and validate the formats of veritas numbers.

## Norwegian Social Security Number (Fødselsnummer) Utility
A Norwegian social security number (Fødselsnummer) contains veritas information. The Information that can be gotten except for if it is validly formatted is Date of Birth, year of birth (including century), Gender and the type of number (normal, D-number or H-Number). This dose not support FH numbers because it is used by the The healthcare system for uniq identification and dose not follow a person out side of the health system.

For more detailed information about the [Norwegian social security number (Fødselsnummer) go here](Utilities/SocialSecurityNumber.md).

## Norwegian Bank Account Number Utility
This utility is built to validate if a Norwegian bank account number is in the correct format including control digit validation. It is also built to get witch bank the Account number belongs to. 

For more detailed information about the [Norwegian bank account number Utility go here](Utilities/AccountNumber.md).


## Norwegian billing Customer Identification Number (KID)
KID stands for Customer Identification Number, and is a number used in the payment of bills in Norway. The number is unique for each bill and identifies the customer and the claim being paid. This information is read and registered automatically by the bank, providing the sender of the bill with an overview of received payments.

A KID number can be from 3 to 25 digits long, and the last digit is a check digit. This is generated based on the other numbers and is intended to reveal whether a payer has entered the KID number incorrectly.

For more detailed information about the [Customer Identification Number (KID)](Utilities/KidNumber.md).

# P.S.
The tests in this project are not perfect an can probably be improved, but it shows a bit of how I feel what a liberty should contain. 
