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
using Dev2.Common.Interfaces.Data;
using Dev2.Data.Interfaces;
using Dev2.DataList.Contract;

namespace Dev2.Data.Parsers
{
    public class OutputLanguageParser : ServiceActivityVariableMapping, IDev2LanguageParser
    {

        #region Attributes

        const string _elementTag = "Output";
        const string _mapsToAttribute = "MapsTo";

        #endregion

        #region Ctor
        internal OutputLanguageParser() : base(_elementTag, _mapsToAttribute, false) { }

        #endregion

        #region Methods
        public IList<IDev2Definition> Parse(string OutputDefinition) => base.Parse(OutputDefinition);

        public IList<IDev2Definition> ParseAndAllowBlanks(string OutputDefinition) => base.Parse(OutputDefinition, false);
        #endregion
    }
}
