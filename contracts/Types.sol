// SPDX-License-Identifier: GPL-3.0
pragma experimental ABIEncoderV2;
pragma solidity >=0.5.0 <=0.9.0;

library Types{
    //This is the role of the user
    enum Role{
        Admin, 
        Bank, 
        Customer
    }
    //This is the Bank Status whether the Bank is on network or not .
    enum BankStatus{
        Active,
        Inactive
    }
    enum KycStatus{
        Pending,
        Verified,
        Unverified
    }
    enum DataHashStatus{
        Pending,
        Approved,
        Rejected
    }
    struct User{
        address _id;
        Role _role;
        BankStatus status;

    }
    struct Customer{
        string name;
        string email;
        uint256 mobileNumber;
        address id_;
        address kycVerifiedBy;
        
     
        

    }
    struct Document{
        address customer_id;
        string name;
        string dataHash;
        uint256 dataHashUpdated;

    }
    struct Account{
        uint256 _id;
        string name;
        string FatherName;
        string DateOfBirth;
        string Place_Of_Birth;
        string Mother_Name;
        string CNICNumber;
        string MobileNumber;
        string Address;
        string Occupation;
        string SourceOfIncome;
        string PurposeOfAccount;
        string signature;
        uint256 Expected_Transaction_TurnOver;
        string NextOfKin;
        CustomAttribute[] customerAttribute;
        address bank_id;
        address customer_id;
    }
    struct CustomAttribute{
        string name;
        string value;
        string formtype;
       bool optional;
        address bank_id;
        address customer_id;
        uint256 account_id;

    }

   struct Bank {
        string name;
        string email;
         address id_;
        BankStatus status; // RBI, we call "admin" here can disable the bank at any instance
    }
    struct KycRequest {
        string id_; // Combination of customer Id & bank is going to be unique
        address userId_;
        string customerName;
        address bankId_;
        string bankName;
        string dataHash;
        uint256 updatedOn;
        KycStatus status;
        DataHashStatus dataRequest; // Get approval from user to access the data
        string additionalNotes; // Notes that can be added if KYC verification fails  OR
        // if customer rejects the access & bank wants to re-request with some message
    }
}