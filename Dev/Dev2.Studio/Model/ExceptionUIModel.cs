/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Caliburn.Micro;


namespace Dev2.Studio.Model
{
    public class ExceptionUiModel : PropertyChangedBase
    {
        BindableCollection<ExceptionUiModel> _exception;
        public BindableCollection<ExceptionUiModel> Exception
        {
            get
            {
                return _exception ?? (_exception = new BindableCollection<ExceptionUiModel>());
            }
            set
            {
                if(_exception == value)
                {
                    return;
                }

                _exception = value;
                NotifyOfPropertyChange(() => Exception);
            }
        }

        string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if(_message == value)
                {
                    return;
                }

                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }
    }
}
