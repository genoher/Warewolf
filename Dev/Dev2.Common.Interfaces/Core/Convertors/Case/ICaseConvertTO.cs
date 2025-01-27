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
using Dev2.Common.Interfaces.Interfaces;

namespace Dev2.Common.Interfaces.Core.Convertors.Case
{
    public interface ICaseConvertTO : IDev2TOFn, IEquatable<ICaseConvertTO>
    {
        string StringToConvert { get; set; }
        string ConvertType { get; set; }
        IList<string> Expressions { get; set; }
        string ExpressionToConvert { get; set; }
        string Result { get; set; }
        string WatermarkTextVariable { get; set; }
    }
}