﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using Dev2.Common;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Common.Wrappers;
using Dev2.Data.Interfaces;
using Dev2.Data.Interfaces.Enums;
using Dev2.PathOperations;
using Warewolf.Resource.Errors;

namespace Dev2.Data.PathOperations.Operations
{
    public class DoGetFilesAsPerTypeOperation : PerformListOfIOPathOperation
    {
        readonly IWindowsImpersonationContext _impersonatedUser;
        protected readonly IDev2LogonProvider _logOnProvider;
        protected readonly IActivityIOPath _path;
        protected readonly IFile _fileWrapper;
        protected readonly IDirectory _dirWrapper;
        protected readonly ReadTypes _type;
        protected readonly IDev2CRUDOperationTO _crudArguments;
        protected readonly string _newPath;

        public DoGetFilesAsPerTypeOperation(IActivityIOPath path, ReadTypes type)
            :this(path, type, new LogonProvider(), new FileWrapper(), new DirectoryWrapper(), ValidateAuthorization.RequiresAuth)
        {
        }
        public DoGetFilesAsPerTypeOperation(IActivityIOPath path, ReadTypes type, IDev2LogonProvider dev2LogonProvider, IFile file, IDirectory directory, ImpersonationDelegate impersonationDelegate)
            :base(impersonationDelegate)
        {
            _logOnProvider = dev2LogonProvider; 
            _fileWrapper = file;  
            _dirWrapper = directory; 
            _path = path;
            _type = type;
            _impersonatedUser = _impersonationDelegate(_path, _logOnProvider);
            _newPath = AppendBackSlashes(_path, _fileWrapper, _dirWrapper);
        }
        public override IList<IActivityIOPath> ExecuteOperation()
        {
            try
            {
                if (_impersonatedUser != null)
                {
                    return ExecuteOperationWithAuth();
                }
                if (!Dev2ActivityIOPathUtils.IsStarWildCard(_newPath))
                {
                    if (_dirWrapper.Exists(_newPath))
                    {
                        return AddDirsToResults(GetDirectoriesForType(_newPath, string.Empty, _type, _dirWrapper), _path);
                    }
                    throw new Exception(string.Format(ErrorResource.DirectoryDoesNotExist, _newPath));

                }
                var baseDir = Dev2ActivityIOPathUtils.ExtractFullDirectoryPath(_newPath);
                var pattern = Dev2ActivityIOPathUtils.ExtractFileName(_newPath);
                return AddDirsToResults(GetDirectoriesForType(baseDir, pattern, _type, _dirWrapper), _path);
            }
            catch (Exception exception)
            {
                Dev2Logger.Error(exception, GlobalConstants.WarewolfError);
                throw new Exception(string.Format(ErrorResource.DirectoryNotFound, _path.Path));
            }
        }
        
        public override IList<IActivityIOPath> ExecuteOperationWithAuth()
        {
            using (_impersonatedUser)
            {
                try
                {

                    if (!Dev2ActivityIOPathUtils.IsStarWildCard(_newPath))
                    {
                        return AddDirsToResults(GetDirectoriesForType(_newPath, string.Empty, _type, _dirWrapper), _path);
                    }
                    var baseDir = Dev2ActivityIOPathUtils.ExtractFullDirectoryPath(_newPath);
                    var pattern = Dev2ActivityIOPathUtils.ExtractFileName(_newPath);
                    return AddDirsToResults(GetDirectoriesForType(baseDir, pattern, _type, _dirWrapper), _path);

                }
                catch (Exception ex)
                {
                    Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                    throw new Exception(string.Format(ErrorResource.DirectoryNotFound, _path.Path));
                }
                finally
                {
                    _impersonatedUser.Undo();
                }
            }
        }
    }
}