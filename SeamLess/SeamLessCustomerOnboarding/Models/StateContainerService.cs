namespace SeamLessCustomerOnboarding.Models
{
    public class StateContainerService
    {
        /// <summary>
        /// Value Of State
        /// </summary>
        public int Value { get; set; } = 0;
        /// <summary>
        /// On State Change
        /// </summary>
        public event Action OnStateChange;

        /// <summary>
        /// Used To Set Value Of State
        /// </summary>
        /// <param name="Value"></param>
        public void SetValue(int Value)
        {
            this.Value = Value;
            NotifyStageChange();
        }
        /// <summary>
        /// The state change event notification
        /// </summary>
        private void NotifyStageChange() => OnStateChange?.Invoke();

    }
}
