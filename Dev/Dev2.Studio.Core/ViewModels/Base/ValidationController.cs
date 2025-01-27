#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.Generic;
using System.Linq;


namespace Dev2.Studio.Core.ViewModels.Base
{
    public class ValidationController : SimpleBaseViewModel
    {
        protected Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        protected void AddError(string key, string value)
        {
            var errorInfo = new KeyValuePair<string, string>(key, value);

            if (!ValidationErrors.ContainsKey(key) && !ValidationErrors.Contains(errorInfo))
            {
                ValidationErrors.Add(key, value);
            }

        }

        protected void RemoveError(string key)
        {
            ValidationErrors.Remove(key);
        }
    }
}
