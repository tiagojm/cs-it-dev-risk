using System.Collections.Generic;

namespace CSQuestion.Models
{
    public class FlowPipelineService
    {
        private static FlowPipelineService _instance;
        private static readonly object _lock = new object();
        private List<TradeCategory> _stepList;
        private int lastLevel = 1;

        public static FlowPipelineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new FlowPipelineService();
                    }
                }

                return _instance;
            }
        }
        public IReadOnlyCollection<TradeCategory> StepList
        {
            get
            {
                return this._stepList.AsReadOnly();
            }
        }

        protected internal FlowPipelineService()
        {
            _stepList = new List<TradeCategory>();

            PushCategory(new PoliticallyExposedPersonCategory(lastLevel));
            PushCategory(new ExpiredCategory(lastLevel));
            PushCategory(new HighRiskCategory(lastLevel));
            PushCategory(new MediumRiskCategory(lastLevel));

            _stepList.Sort();
        }

        private void PushCategory(TradeCategory categoryTrade)
        {
            lock (_stepList)
            {
                _stepList.Add(categoryTrade);
                lastLevel++;
            }
        }
    }
}
