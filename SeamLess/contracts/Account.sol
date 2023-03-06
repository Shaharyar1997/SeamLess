// SPDX-License-Identifier: GPL-3.0
pragma experimental ABIEncoderV2;
pragma solidity >=0.5.0 <=0.9.0;

import "./Types.sol";
import "./Helper.sol";


contract Account{

    address[] internal accounts;
    mapping(address=>Types.Account)  accountmapping;

    event AddAccount( address customer_id,address bank_id,Types.Account account);
        
    event AccountUpdate( address customer_id,address bank_id,Types.Account account);
    
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

        Types.Account[] memory banksList_ = new Types.Account[](pageLength_);
        for (uint256 i = startIndex_; i < endIndex_; i++)
            banksList_[i] = accountmapping[accounts[i]];
        return (pages, banksList_);
    }
         modifier isValidAccount(address customerid_,uint256 account_id) {
        require( customerid_!= address(0), "Id is Empty");
        require(accountmapping[customerid_]._Id != account_id, "Invalid Account Id");
        
        _;
    }
  
   
    function getCustomerAccountInfomration(address customer_id) internal view returns(Types.Account memory)
    {
        require(customer_id!=address(0),"Incorrect Account_id");
        return accountmapping[customer_id];
    }
    function AddAccounts(address customer_id,address bank_id,Types.Account memory account) public {
        emit AddAccount(customer_id,bank_id,account);
           
    }
    function UpdateAccounts(address customer_id,address bank_id,Types.Account memory account) public {
        emit AccountUpdate(customer_id,bank_id,account);
           
    }
        
      
        
}