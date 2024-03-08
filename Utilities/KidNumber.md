# Norwegian billing Customer Identification Number (KID)
KID stands for Customer Identification Number, and is a number used in the payment of bills in Norway. The number is unique for each bill and identifies the customer and the claim being paid. This information is read and registered automatically by the bank, providing the sender of the bill with an overview of received payments.

A KID number can be from 3 to 25 digits long, and the last digit is a check digit. This is generated based on the other numbers and is intended to reveal whether a payer has entered the KID number incorrectly.

## Support Formats
The formats this utilities support are 'xxc'

### Formatting description

- xx is the Customer Identification Number (KID number) and can be from 2 to 24 digits long
- c is a control digit. It is calculated on the basis of all previous digits. The calculation can be performed by MOD10 or Mod11 (modulus). both are valid, but are dependent upon contracts between the veritas parties (witch are out side the control of this code).

## KidNumberIsValid
Checks to see if the KID number is a valid MOD10 (Modulus 10) or MOD11 (Modulus 11) number. 
- Param:
    - kidNumber: Customer Identification Number (KID number)
- Return: 
    - true if valid MOD10 (Modulus 10) or MOD11 (Modulus 11) number
```C#
    true = "5868".IsValid();
    true = "9144018081422460814781921".IsValid();
    false = "52".IsValid(); 
```


