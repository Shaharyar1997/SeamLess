using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.Standards.ENS.PublicResolver.ContractDefinition;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System.Numerics;
using System.Security.Policy;

namespace SeamLessCustomerOnboarding.Models
{
    [FunctionOutput]
    public class GetBalanceOutputDTO : IFunctionOutputDTO
    {
        [Parameter("int256", "totalPages", 1)]
        public virtual BigInteger totalPages { get; set; }
        [Parameter("string", "currency", 2)]
        public virtual string Currency { get; set; }
    }
    public class CustomerContractExecutor
    {
        private static string ganacheURL = "HTTP://localhost:7545";
        string customerContractAddress = "0xB84feCc1dDEF8208aF3f560Ec55775A4A18F8c0C";

        private static string ABI = @"[
    {
      ""anonymous"": false,
      ""inputs"": [
        {
          ""components"": [
            {
              ""internalType"": ""string"",
              ""name"": ""email"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""address"",
              ""name"": ""id_"",
              ""type"": ""address""
            },
            {
              ""internalType"": ""address"",
              ""name"": ""kycVerifiedBy"",
              ""type"": ""address""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""name"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""FatherName"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""DateOfBirth"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Place_Of_Birth"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Mother_Name"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""CNICNumber"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""MobileNumber"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Address"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Occupation"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""SourceOfIncome"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""PurposeOfAccount"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""signature"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""uint256"",
              ""name"": ""Expected_Transaction_TurnOver"",
              ""type"": ""uint256""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""NextOfKin"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Email"",
              ""type"": ""string""
            },
            {
              ""components"": [
                {
                  ""internalType"": ""string"",
                  ""name"": ""name"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""value"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""formtype"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""bool"",
                  ""name"": ""optional"",
                  ""type"": ""bool""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""bank_id"",
                  ""type"": ""address""
                }
              ],
              ""internalType"": ""struct Types.CustomAttribute[]"",
              ""name"": ""customAttribute"",
              ""type"": ""tuple[]""
            },
            {
              ""components"": [
                {
                  ""internalType"": ""uint256"",
                  ""name"": ""_Id"",
                  ""type"": ""uint256""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountType"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountCurrency"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountTitle"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""availableBalance"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""MailingAddress"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""City"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""PostalCode"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""AddressType"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""NTN"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""bank_id"",
                  ""type"": ""address""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""customer_id"",
                  ""type"": ""address""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""addeDateTime"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""updateDateTime"",
                  ""type"": ""string""
                }
              ],
              ""internalType"": ""struct Types.Account[]"",
              ""name"": ""account"",
              ""type"": ""tuple[]""
            },
            {
              ""internalType"": ""enum Types.KycStatus"",
              ""name"": ""kycStatus"",
              ""type"": ""uint8""
            },
            {
              ""internalType"": ""bool"",
              ""name"": ""isKycVerified"",
              ""type"": ""bool""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""addeDateTime"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""updateDateTime"",
              ""type"": ""string""
            }
          ],
          ""indexed"": false,
          ""internalType"": ""struct Types.Customer"",
          ""name"": ""customer"",
          ""type"": ""tuple""
        }
      ],
      ""name"": ""CustomerAdded"",
      ""type"": ""event""
    },
    {
      ""anonymous"": false,
      ""inputs"": [
        {
          ""components"": [
            {
              ""internalType"": ""string"",
              ""name"": ""email"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""address"",
              ""name"": ""id_"",
              ""type"": ""address""
            },
            {
              ""internalType"": ""address"",
              ""name"": ""kycVerifiedBy"",
              ""type"": ""address""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""name"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""FatherName"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""DateOfBirth"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Place_Of_Birth"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Mother_Name"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""CNICNumber"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""MobileNumber"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Address"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Occupation"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""SourceOfIncome"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""PurposeOfAccount"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""signature"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""uint256"",
              ""name"": ""Expected_Transaction_TurnOver"",
              ""type"": ""uint256""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""NextOfKin"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""Email"",
              ""type"": ""string""
            },
            {
              ""components"": [
                {
                  ""internalType"": ""string"",
                  ""name"": ""name"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""value"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""formtype"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""bool"",
                  ""name"": ""optional"",
                  ""type"": ""bool""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""bank_id"",
                  ""type"": ""address""
                }
              ],
              ""internalType"": ""struct Types.CustomAttribute[]"",
              ""name"": ""customAttribute"",
              ""type"": ""tuple[]""
            },
            {
              ""components"": [
                {
                  ""internalType"": ""uint256"",
                  ""name"": ""_Id"",
                  ""type"": ""uint256""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountType"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountCurrency"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""accountTitle"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""availableBalance"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""MailingAddress"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""City"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""PostalCode"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""AddressType"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""NTN"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""bank_id"",
                  ""type"": ""address""
                },
                {
                  ""internalType"": ""address"",
                  ""name"": ""customer_id"",
                  ""type"": ""address""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""addeDateTime"",
                  ""type"": ""string""
                },
                {
                  ""internalType"": ""string"",
                  ""name"": ""updateDateTime"",
                  ""type"": ""string""
                }
              ],
              ""internalType"": ""struct Types.Account[]"",
              ""name"": ""account"",
              ""type"": ""tuple[]""
            },
            {
              ""internalType"": ""enum Types.KycStatus"",
              ""name"": ""kycStatus"",
              ""type"": ""uint8""
            },
            {
              ""internalType"": ""bool"",
              ""name"": ""isKycVerified"",
              ""type"": ""bool""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""addeDateTime"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""updateDateTime"",
              ""type"": ""string""
            }
          ],
          ""indexed"": false,
          ""internalType"": ""struct Types.Customer"",
          ""name"": ""customer"",
          ""type"": ""tuple""
        }
      ],
      ""name"": ""CustomerDataUpdated"",
      ""type"": ""event""
    }
  ]";
        private readonly IConfiguration configuration;
        private MetaMaskService serviceMetaMask;
        public CustomerContractExecutor(IConfiguration configuration,MetaMaskService serviceMetaMask)
        {
            this.configuration = configuration;
            this.serviceMetaMask = serviceMetaMask;

        }

        public async Task AddCustomer(Customer customer)
        {

            
            string sender = await serviceMetaMask.GetSelectedAddress();
            
            Web3 web3 = new Web3(ganacheURL);
            Contract customerContract = web3.Eth.GetContract(ABI, customerContractAddress);
            try
            {
                HexBigInteger gas = new HexBigInteger(new BigInteger(400000));
                HexBigInteger value = new HexBigInteger(new BigInteger(0));

                Task<string> castVoteFunction = customerContract.GetFunction("getallCustomers").SendTransactionAsync(sender,gas,value,new {pageNumber= 1 });
                castVoteFunction.Wait();
                Console.WriteLine("Vote Cast!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
       
    }
}
