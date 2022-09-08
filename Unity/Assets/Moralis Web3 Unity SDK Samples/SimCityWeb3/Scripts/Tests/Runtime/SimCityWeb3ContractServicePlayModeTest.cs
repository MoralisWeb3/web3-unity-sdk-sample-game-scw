using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Web3Api.Models;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
    
    /// <summary>
    /// 
    /// </summary>
    public class SimCityWeb3ContractServicePlayModeTest : BaseMoralisPlayModeTest
    {
        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------
        private static ChainList[] ChainListValue = new ChainList[]
        {
            ChainList.mumbai,
            ChainList.cronos_testnet
        };
        

        
        [UnityTest]
        public IEnumerator NoExceptions_When_LoadPropertyDatasAsync([ValueSource("ChainListValue")] ChainList chainList) => UniTask.ToCoroutine(async () =>
        {
            // Arrange
            SimCityWeb3ContractService simCityWeb3ContractService =
                new SimCityWeb3ContractService(chainList);

            // Act
            List<PropertyData> propertyDatas = await simCityWeb3ContractService.LoadPropertyDatasAsync();

            // Assert
            Assert.That(propertyDatas.Count, Is.GreaterThanOrEqualTo(0));
            
        });
        

        //  Event Handlers --------------------------------
    }
}
