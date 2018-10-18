using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_D.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        RuleViewModel _getRule() => new RuleViewModel
        {
            CreateIfNone = true,
            Destination = @"C:\Users\User\Desktop\des",
            ReplaceIfExist = true,
            Extensions="zip;jpg;png",
            Format="[skip] name [skip]",
            Name="MYTEST"
        };

        IEnumerable<StorageViewModel> _getStorages()
        {
            return new List<StorageViewModel>
            {
                new StorageViewModel{Extension="png",Name="[00] AAA [11]",Path=@"C:\Users\User\Desktop\trashs\[00] AAA [11].png",StorageType=Windows.Storage.StorageItemTypes.File},
                new StorageViewModel{Extension="jpg",Name="AAA",Path="aaa"},
            };
        }

        [TestMethod]
        public async Task TestStorageDispatcher ()
        {
            await new StorageDispatcher(_getStorages(), _getRule()).RunAsync();
        }
    }
}
