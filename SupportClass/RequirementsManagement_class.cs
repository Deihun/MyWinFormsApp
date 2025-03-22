using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.SupportClass
{
    class RequirementsManagement_class : IDisposable
    {
        public string _filter = "";
        private bool disposed;


        /// <summary>
        /// RequirementManagement Class enables for easier conversion of requirement conditions of a client. This call of method doesn't support getCheckmarks()
        /// </summary>
        public RequirementsManagement_class(string filter)
        {
            this._filter = filter;
        }

        /// <summary>
        /// RequirementManagement Class enables for easier conversion of requirement condition of a client. This call of method supports getCheckmarks()
        /// </summary>
        /// <param name="required_pallet"></param>
        public RequirementsManagement_class(CheckBox required_pallet, CheckBox required_clearance)
        {
            string conditions = $"\"pallet_required\": {(!required_pallet.Checked).ToString().ToLower()}," +
                                $"\"clearance_space_required\": {(!required_clearance.Checked).ToString().ToLower()}";
            _filter = $"{{ {conditions} }}";
        }

        /// <summary>
        /// Convert all requirement condition of Client into a string json format.
        /// </summary>
        /// <returns>JSON format string of all conditions</returns>
        public string getCheckmarks()
        {
            return _filter;
        }



        public List<string> getAllConditionAsList() 
        {
            List<string> conditions = new List<string>();// this still has no content even if the string i enter is correct or has a content. It still return zero count of it
            Dictionary<string, bool> rawcondition = JsonConvert.DeserializeObject<Dictionary<string, bool>>(_filter);
            if (_filter.Equals(string.Empty)) return conditions;
            foreach (var _condition in rawcondition)
            {
                if (_condition.Value) continue;
                    if (_condition.Key == "pallet_required")
                        conditions.Add("Required Pallet");

                    if (_condition.Key == "clearance_space_required")
                        conditions.Add("Require in-between spaces");
            }
            return conditions;
        }

        public bool _isRequiringPallet()
        {
            return _isRequiring("pallet_required");
        }

        public bool _isRequiringSpaceClearance()
        {
            return _isRequiring("clearance_space_required");
        }
        public bool _isRequiring(string require)
        {
            Dictionary<string, bool> rawcondition = JsonConvert.DeserializeObject<Dictionary<string, bool>>(_filter);
            foreach (var condition in rawcondition)
            {
                if (!condition.Value) continue;
                if (condition.Key.Equals($"{require}")) return true;
            }
            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        // Finalizer (only runs if Dispose() is not called)
        ~RequirementsManagement_class()
        {
            Dispose(false);
        }


        //private void instantiateConditions(string raw_condition)
        //{
        //    Dictionary<string, bool> rawcondition = JsonConvert.DeserializeObject<Dictionary<string, bool>>(raw_condition);

        //    foreach (var condition in rawcondition)
        //    {
        //        if (condition.Value)
        //        {
        //            string content = "";

        //            switch (condition.Key)
        //            {
        //                case "pallet_required":
        //                    content = "* Requiring Pallet";
        //                    break;
        //                case "clearance_space_required":
        //                    content = "* Requiring Clearance Space";
        //                    break;
        //            }

        //            Label label = new Label();
        //            label.Text = content;
        //            label.ForeColor = Color.DarkRed;
        //            conditioncontainer_flp.Controls.Add(label);
        //            this.Height += label.Height;
        //        }
        //    }
        //}
    }
}
