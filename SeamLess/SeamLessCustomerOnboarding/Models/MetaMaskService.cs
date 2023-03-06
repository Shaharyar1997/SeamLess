using MetaMask.Blazor;
using MetaMask.Blazor.Enums;
using MetaMask.Blazor.Exceptions;
using Microsoft.AspNetCore.Components;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.ABI.Model;
using System.Numerics;

namespace SeamLessCustomerOnboarding.Models
{
    public class MetaMaskService
    {
        private IMetaMaskService metaMaskClient;
        public MetaMaskService(IMetaMaskService metaMaskService)
        {
            metaMaskClient=metaMaskService;
        }

        public bool HasMetaMask { get; set; }
        public string? SelectedAddress { get; set; }
        public string? SelectedChain { get; set; }
        public string? TransactionCount { get; set; }
        public string? SignedData { get; set; }
        public string? SignedDataV4 { get; set; }
        public string? FunctionResult { get; set; }
        public string? RpcResult { get; set; }
        public Chain? Chain { get; set; }

       public  async Task InitializeMetaMask()
        {
            IMetaMaskService.AccountChangedEvent += MetaMaskService_AccountChangedEvent;
            IMetaMaskService.ChainChangedEvent += MetaMaskService_ChainChangedEvent;
            IMetaMaskService.OnConnectEvent += IMetaMaskService_OnConnectEvent;
            IMetaMaskService.OnDisconnectEvent += IMetaMaskService_OnDisconnectEvent;

            HasMetaMask = await metaMaskClient.HasMetaMask();
            if (HasMetaMask) {
                await metaMaskClient.ListenToEvents();
            }

        }
        public string getAddress()
        {
            return SelectedAddress;
        }
        public async Task<bool> isConnected()
        {
            return await metaMaskClient.IsSiteConnected();
        }
        private async Task MetaMaskService_ChainChangedEvent((long, Chain) arg)
        {
            Console.WriteLine("Chain Changed");
            await GetSelectedNetwork();
        }
        private async Task MetaMaskService_AccountChangedEvent(string arg)
        {
            Console.WriteLine("Account Changed");
            await GetSelectedAddress();
       
        }
        private void IMetaMaskService_OnDisconnectEvent()
        {
            Console.WriteLine("Disconnect");
        }

        private void IMetaMaskService_OnConnectEvent()
        {
            Console.WriteLine("Connect");
        }

        public async Task ConnectMetaMask()
        {
            await metaMaskClient.ConnectMetaMask();
            await GetSelectedAddress();
        }
        public async Task<string> GetSelectedAddress()
        {
            SelectedAddress = await metaMaskClient.GetSelectedAddress();
            return SelectedAddress;
        }
        public async Task<string> GetSelectedNetwork()
        {
            var chainInfo = await metaMaskClient.GetSelectedChain();
            Chain = chainInfo.chain;
            
            SelectedChain = $"ChainID: {chainInfo.chainId}, Name: {chainInfo.chain.ToString()}";
            return SelectedChain;
        }
        public async Task<string> GetTransactionCount()
        {
            var transactionCount = await metaMaskClient.GetTransactionCount();
            return transactionCount.ToString();
        }
        public async Task<string> SignData(string label, string value)
        {
            try
            {
                var result = await metaMaskClient.SignTypedData("test label", "test value");
                SignedData = $"Signed: {result}";
                return SignedData;
            }
            catch (UserDeniedException)
            {
                SignedData = "User Denied";
                return SignedData;
            }
            catch (Exception ex)
            {
                SignedData = $"Exception: {ex}";
                return SignedData;
            }
        }
        public async Task CallSmartContractFunctionExample1()
        {
            try
            {
                string address = "0x21253c6f5E16a56031dc8d8AF0bb372bc4A4DfDA";
                BigInteger weiValue = 0;
                string data = GetEncodedFunctionCall();

                data = data[2..]; //Remove the 0x from the generated string
                var result = await metaMaskClient.SendTransaction(address, weiValue, data);
                FunctionResult = $"TX Hash: {result}";
            }
            catch (UserDeniedException)
            {
                FunctionResult = "User Denied";
            }
            catch (Exception ex)
            {
                FunctionResult = $"Exception: {ex}";
            }
        }

        public async Task CallSmartContractFunctionExample2()
        {
            try
            {
                string address = "0x722BcdA7BD1a0f8C1c9b7c0eefabE36c1f0fBF2a";
                BigInteger weiValue = 1000000000000000;
                string data = GetEncodedFunctionCallExample2();

                data = data[2..]; //Remove the 0x from the generated string
                var result = await metaMaskClient.SendTransaction(address, weiValue, data);
                FunctionResult = $"TX Hash: {result}";
            }
            catch (UserDeniedException)
            {
                FunctionResult = "User Denied";
            }
            catch (Exception ex)
            {
                FunctionResult = $"Exception: {ex}";
            }
        }

        private string GetEncodedFunctionCall()
        {
            //This example uses Nethereum.ABI to create the ABI encoded string to call a smart contract function

            //Smart contract has a function called "share"
            FunctionABI function = new FunctionABI("share", false);

            //With 4 inputs
            var inputsParameters = new[] {
                    new Parameter("address", "receiver"),
                    new Parameter("string", "appId"),
                    new Parameter("string", "shareType"),
                    new Parameter("string", "data")
            };
            function.InputParameters = inputsParameters;

            var functionCallEncoder = new FunctionCallEncoder();

            var data = functionCallEncoder.EncodeRequest(function.Sha3Signature, inputsParameters,
                "0x92B143F46C3F8B4242bA85F800579cdF73882e98",
                "MetaMask.Blazor",
                "Sample",
                DateTime.UtcNow.ToString());
            return data;
        }

        private string GetEncodedFunctionCallExample2()
        {
            
            FunctionABI function = new FunctionABI("setColor", false);

            //With 4 inputs
            var inputsParameters = new[] {
                    new Parameter("string", "color")
            };
            function.InputParameters = inputsParameters;

            var functionCallEncoder = new FunctionCallEncoder();

            var data = functionCallEncoder.EncodeRequest(function.Sha3Signature, inputsParameters, new object[] { "green" });

            return data;
        }


        public async Task<string> GenericRpc()
        {
            var result = await metaMaskClient.RequestAccounts();
            return result;
        }

        public async Task<string> GetBalance()
        {
            var address = await metaMaskClient.GetSelectedAddress();
            var result = await metaMaskClient.GetBalance(address);
            return result.ToString();
        }
        public void Dispose()
        {
            IMetaMaskService.AccountChangedEvent -= MetaMaskService_AccountChangedEvent;
            IMetaMaskService.ChainChangedEvent -= MetaMaskService_ChainChangedEvent;
            IMetaMaskService.OnConnectEvent -= IMetaMaskService_OnConnectEvent;
            IMetaMaskService.OnDisconnectEvent -= IMetaMaskService_OnDisconnectEvent;
        }
    }
}
