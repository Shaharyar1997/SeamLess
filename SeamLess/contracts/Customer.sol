// SPDX-License-Identifier: GPL-3.0
pragma experimental ABIEncoderV2;
pragma solidity >=0.5.0 <=0.9.0;
import "./Types.sol";
import "./Helper.sol";

contract Customers {
    address[] internal customerList;
    mapping(address => Types.Customer) internal customers;

    // Events

    event CustomerAdded(Types.Customer customer);
    event CustomerDataUpdated(Types.Customer customer);
    
function getallCustomers(uint256 pageNumber)
        internal
        view
        returns (uint256 totalPages, Types.Customer[] memory)
    {
        require(pageNumber > 0, "PN should be > 0");
        (
            uint256 pages,
            uint256 pageLength_,
            uint256 startIndex_,
            uint256 endIndex_
        ) = Helper.getIndexes(pageNumber, customerList);

        Types.Customer[] memory banksList_ = new Types.Customer[](pageLength_);
        for (uint256 i = startIndex_; i < endIndex_; i++)
            banksList_[i] = customers[customerList[i]];
        return (pages, banksList_);
    }
    // Modifiers

    /**
     * @notice Checks whether customer already exists
     * @param id_ Metamask address of the customer
     */
    modifier isValidCustomer(address id_) {
        require(id_ != address(0), "Id is Empty");
        require(customers[id_].id_ != address(0), "User Id Empty");
        require(
            !Helper.compareStrings(customers[id_].email, ""),
            "User Email Empty"
        );
        _;
    }

    

    // Support Functions

    function customerExists(address id_) internal view returns (bool exists_) {
        require(id_ != address(0), "Id is empty");
        if (
            customers[id_].id_ != address(0) &&
            !Helper.compareStrings(customers[id_].email, "")
        ) {
            exists_ = true;
        }
    }

    // Contract Functions

    function getcustomerdetails(address id_)
        internal
        view
        returns (Types.Customer memory)
    {
        return customers[id_];
    }

   
    function updateprofile(Types.Customer memory customer)
   internal {
        customers[msg.sender].name = customer.name;
        customers[msg.sender].email = customer.email;
        customers[msg.sender].MobileNumber = customer.MobileNumber;
        emit CustomerDataUpdated( customer);
    }

    function addcustomer(Types.Customer memory customer_) internal {
        customers[customer_.id_] = customer_;
        customerList.push(customer_.id_);
        emit CustomerAdded(customer_);
    }

    /**
     * @dev To Update KYC verification bank
     * @param id_ Customer's metamask ID
     */
    function updatekycdoneby(address id_) internal {
        require(id_ != address(0), "Customer Id Empty");
        customers[id_].kycVerifiedBy = msg.sender;
    }

  

   
    function searchcustomers(address id_, address[] memory customers_)
        internal
        view
        returns (bool, Types.Customer memory)
    {
        bool found_;
        Types.Customer memory customer_;

        for (uint256 i = 0; i < customers_.length; i++) {
            if (customers_[i] == id_) {
                found_ = true;
                customer_ = customers[id_];
                break;
            }
        }
        return (found_, customer_);
    }
}