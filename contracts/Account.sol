// SPDX-License-Identifier: GPL-3.0
pragma experimental ABIEncoderV2;
pragma solidity >=0.4.25 <0.9.0;

import "./Types.sol";
import "./Helper.sol";


contract Account{

    address[] internal accounts;
    mapping(address=>Types.Account)  account;

    event AddAccount( string name,
        string FatherName,        string DateOfBirth,
        string Place_Of_Birth,
        string Mother_Name,
        string CNICNumber,
        string MobileNumber,
        string Address,
        string Occupation,
        string SourceOfIncome,
        string PurposeOfAccount,
        string signature,
        uint256 Expected_Transaction_TurnOver,
        string NextOfKin,address customer_id,address bank_id);
    event AccountUpdate( string name,
        string FatherName,        string DateOfBirth,
        string Place_Of_Birth,
        string Mother_Name,
        string CNICNumber,
        string MobileNumber,
        string Address,
        string Occupation,
        string SourceOfIncome,
        string PurposeOfAccount,
        string signature,
        uint256 Expected_Transaction_TurnOver,
        string NextOfKin,address customer_id,address bank_id);

         modifier isValidAccount(address id_) {
        require( id_!= address(0), "Id is Empty");
        require(account[id_]._id != 0, "Invalid Account Id");
        
        _;
    }
    function getallAccount(uint256 pageNumber)
        internal
        view
        returns (uint256 totalPages, Types.Account[] memory)
    {
        require(pageNumber > 0, "PN should be > 0");
        (
            uint256 pages,
            uint256 pageLength_,
            uint256 startIndex_,
            uint256 endIndex_
        ) = Helper.getIndexes(pageNumber, accounts);

        Types.Account[] memory AccountList_ = new Types.Account[](pageLength_);
        for (uint256 i = startIndex_; i < endIndex_; i++)
            AccountList_[i] = account[accounts[i]];
        return (pages, AccountList_);
    }
    function getAccountInfomration(address _id) internal returns(Types.Account memory)
    {
        require(_id!=address(0),"Incorrect Ethereum Address");
        return account[_id];
    }
    function addAccount(
        string memory name,
        string  memory FatherName,        
        string memory DateOfBirth,
        string memory Place_Of_Birth,
        string memory Mother_Name,
        string memory CNICNumber,
        string memory MobileNumber,
        string memory Address,
        string memory Occupation,
        string memory SourceOfIncome,
        string memory PurposeOfAccount,
        string memory signature,
        uint256 Expected_Transaction_TurnOver,
        string memory NextOfKin,address customer_id,address bank_id) public  {
            require(customer_id!=address(0),"Customer Address Invalid");
            require(bank_id!=address(0),"Bank Address Invalid");
           emit AddAccount(name, FatherName, DateOfBirth, Place_Of_Birth, Mother_Name, CNICNumber, MobileNumber, Address, Occupation, SourceOfIncome, PurposeOfAccount, signature, Expected_Transaction_TurnOver, NextOfKin,customer_id,bank_id); 
         }
       function updateAccount(
        string memory name,
        string  memory FatherName,        
        string memory DateOfBirth,
        string memory Place_Of_Birth,
        string memory Mother_Name,
        string memory CNICNumber,
        string memory MobileNumber,
        string memory Address,
        string memory Occupation,
        string memory SourceOfIncome,
        string memory PurposeOfAccount,
        string memory signature,
        uint256 Expected_Transaction_TurnOver,
        string memory NextOfKin,address customer_id,address bank_id) public  {
            require(customer_id!=address(0),"Customer Address Invalid");
            require(bank_id!=address(0),"Bank Address Invalid");
           emit AccountUpdate(name, FatherName, DateOfBirth, Place_Of_Birth, Mother_Name, CNICNumber, MobileNumber, Address, Occupation, SourceOfIncome, PurposeOfAccount, signature, Expected_Transaction_TurnOver, NextOfKin, customer_id, bank_id);(name, FatherName, DateOfBirth, Place_Of_Birth, Mother_Name, CNICNumber, MobileNumber, Address, Occupation, SourceOfIncome, PurposeOfAccount, signature, Expected_Transaction_TurnOver, NextOfKin,customer_id,bank_id); 
         }
         function getCustomAttributes(uint256  account_id,address customer_id) internal returns(Types.CustomAttribute[] memory)
         {
               require(account_id != 0,"Invalid Account ID");
            require(customer_id!=address(0),"CustomerID Invalid");
            
         }
}