/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Reflection;
using Dev2.Activities;
using Dev2.Factories;
using Dev2.Interfaces;
using Dev2.Util;
using Dev2.Utilities;

namespace Dev2.FindMissingStrategies
{
    //This is loaded based on SpookyAction implementing IFindMissingStrategy
    public class SequenceActivityFindMissingStrategy : IFindMissingStrategy
    {
        #region Implementation of ISpookyLoadable<Enum>

        public Enum HandlesType() => enFindMissingType.Sequence;

        /// <summary>
        /// Gets all the fields for a specific activity
        /// </summary>
        /// <param name="activity">The activity that the fields will be retrieved from</param>
        /// <returns>Returns all the fields in a list of strings</returns>
        public List<string> GetActivityFields(object activity)
        {
            var results = new List<string>();
            var stratFac = new Dev2FindMissingStrategyFactory();
            if (activity is DsfSequenceActivity sequenceActivity)
            {
                foreach (var innerActivity in sequenceActivity.Activities)
                {
                    if (innerActivity is IDev2Activity dsfActivityAbstractString)
                    {
                        GetResults(dsfActivityAbstractString, stratFac, results);
                    }
                }
            }

            var properties = StringAttributeRefectionUtils.ExtractAdornedProperties<FindMissingAttribute>(activity);

            foreach (PropertyInfo propertyInfo in properties)
            
            {
                var property = propertyInfo.GetValue(activity, null);
                if (property != null)
                {
                    results.Add(property.ToString());
                }
            }

            return results;
        }

        static void GetResults(IDev2Activity dsfActivityAbstractString, Dev2FindMissingStrategyFactory stratFac, List<string> results)
        {
            var findMissingType = dsfActivityAbstractString.GetFindMissingType();
            var strategy = stratFac.CreateFindMissingStrategy(findMissingType);
            results.AddRange(strategy.GetActivityFields(dsfActivityAbstractString));
        }

        #endregion
    }
}
