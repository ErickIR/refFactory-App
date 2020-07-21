using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Helper
{
    public class ClickRegulator
    {
        public Dictionary<string, ThreadSafeBool> ClickStatus = new Dictionary<string, ThreadSafeBool>();
        private readonly ThreadSafeBool _preventOtherClicks = new ThreadSafeBool(false);

        // returns false if safe to execute, true means cannot execute
        public bool SetClicked(string name, bool preventOtherClicks = false)
        {
            if (_preventOtherClicks.Get()) return true;

            if (ClickStatus.ContainsKey(name))
            {
                var alreadyClicked = ClickStatus[name].Get();
                if (alreadyClicked) return true;
                ClickStatus[name].Set(true);
                if (preventOtherClicks) _preventOtherClicks.Set(true);
                return false;
            }

            ClickStatus.Add(name, new ThreadSafeBool(true));
            if (preventOtherClicks) _preventOtherClicks.Set(true);
            return false;
        }

        public void ClickDone(string name)
        {
            ClickStatus[name].Set(false);
            _preventOtherClicks.Set(false);
        }
    }
}
