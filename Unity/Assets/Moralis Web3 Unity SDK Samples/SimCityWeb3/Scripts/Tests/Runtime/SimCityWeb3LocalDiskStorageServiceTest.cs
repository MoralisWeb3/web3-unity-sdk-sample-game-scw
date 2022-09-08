using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class SimCityWeb3LocalDiskStorageServiceTest
    {
        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------

        
        //  Unity Methods----------------------------------
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Executes BEFORE ALL test methods of this test class
        }
        
        [SetUp]
        public void Setup()
        {
            // Executes BEFORE EACH test methods of this test class
        }
        
        [TearDown]
        public void TearDown()
        {
            // Executes AFTER EACH test methods of this test class
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Executes AFTER ALL test methods of this test class
        }

        
        //  General Methods -------------------------------
        [UnityTest]
        public IEnumerator NoExceptions_When_LoadPropertyDatasAsync() => UniTask.ToCoroutine(async () =>
        {
            // Arrange
            SimCityWeb3LocalDiskStorageService simCityWeb3LocalDiskStorageService =
                new SimCityWeb3LocalDiskStorageService();

            // Act
            List<PropertyData> propertyDatas = await simCityWeb3LocalDiskStorageService.LoadPropertyDatasAsync();

            // Assert
            Assert.That(propertyDatas.Count, Is.GreaterThanOrEqualTo(0));
            
        });
        

        //  Event Handlers --------------------------------
    }
}
