namespace SeamLessCustomerOnboarding.Models
{
    public class MetaMaskStateContainer
    {
        /// <summary>
        /// Does the Browser has Meta Mask Installed
        /// </summary>
        public bool hasMetaMask { get; set; }
        /// <summary>
        /// Ethereum Address
        /// </summary>
        public string selectedEthereumAddress { get; set; } = string.Empty;
        /// <summary>
        /// Connect to MetaMask
        /// </summary>
        
        public bool isConnected { get; set; } = false;
        public bool getMetaMaskAvaialability()
        {
            return hasMetaMask;
        }
        /// <summary>
        /// get the Selected Ethereum Address
        /// </summary>
        /// <returns>string</returns>
        public string getEthereumAddress()
        {
            return selectedEthereumAddress;
        }

        /// <summary>
        /// Get Meta Mask Connection Status
        /// </summary>
        /// <returns></returns>
        public bool isMetaMaskConnected()
        {
            return isConnected; 
        }
        /// <summary>
        /// On State Change
        /// </summary>
        public event Action OnStateChange;

        /// <summary>
        /// Used To Set Value Of State
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(string address,bool isConnected,bool HasMetaMask)
        {
            this.selectedEthereumAddress = address;
            this.isConnected = isConnected; 
            this.hasMetaMask= HasMetaMask;  
            NotifyStageChange();
        }
        /// <summary>
        /// The state change event notification
        /// </summary>
        private void NotifyStageChange() => OnStateChange?.Invoke();
    }
}
