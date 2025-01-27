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

namespace Dev2.Common.Interfaces.Core.Convertors.DateAndTime
{
    public enum DateTimeAmPm
    {
        am,
        pm
    }

    public interface IDateTimeResultTO
    {
        int Years { get; set; }
        int Months { get; set; }
        int Days { get; set; }
        int DaysOfWeek { get; set; }
        int DaysOfYear { get; set; }
        int Weeks { get; set; }
        int Hours { get; set; }
        int Minutes { get; set; }
        int Seconds { get; set; }
        int Milliseconds { get; set; }
        bool Is24H { get; set; }
        DateTimeAmPm AmPm { get; set; }
        string Era { get; set; }
        ITimeZoneTO TimeZone { get; set; }

        void NormalizeHours();
        void NormalizeMonths();
        void NormalizeDays();

        DateTime ToDateTime();
    }
}