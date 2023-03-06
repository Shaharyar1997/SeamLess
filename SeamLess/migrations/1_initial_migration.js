const Types = artifacts.require("Types");
const Helpers = artifacts.require("Helper");
const Customers = artifacts.require("Customers");
const Banks = artifacts.require("Banks");
const Account =artifacts.require("Account");

module.exports = function (deployer, network, accounts) {
  if (network == "development") {
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
  }else{
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
  }
};
