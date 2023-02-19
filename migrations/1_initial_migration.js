const Types = artifacts.require("Types");
const Helpers = artifacts.require("Helper");
const Customers = artifacts.require("Customer");
const Banks = artifacts.require("Bank");
const Account = artifacts.require("Account");
module.exports = function (deployer) {
  deployer.deploy(Helpers);
    deployer.deploy(Types);
    deployer.link(Helpers, Customers);
    deployer.link(Types, Customers);
    deployer.deploy(Customers);
    deployer.link(Helpers, Banks);
    deployer.link(Types, Banks);
    deployer.deploy(Banks);
    deployer.link(Helpers, Account);
    deployer.link(Types, Account);
    deployer.deploy(Account);

};
