using System;
using System.Collections.Generic;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using NUnit.Framework;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model
{
    public class MockPropertyData01 : PropertyData
    {
        public MockPropertyData01() :  base("0x1234", 1, 2){}
    }
    
    public class MockPropertyData02 : PropertyData
    {
        public MockPropertyData02() :  base("0xABCD", 1, 2){}
    }
    
    public class MockPropertyData03 : PropertyData
    {
        public MockPropertyData03() :  base("0x9999", 1, 2){}
    }
    
    public class SimCityWeb3ModelTest
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
        [Test]
        public void HasAnyData_IsZero_WhenDefault()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();

            // Act
            bool hasAnyData = simCityWeb3Model.HasAnyData();

            // Assert
            Assert.That(hasAnyData, Is.False);
        }
        
        [Test]
        public void HasAnyData_IsTrue_WhenAdd1()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            PropertyData propertyData = new MockPropertyData01();
            simCityWeb3Model.AddPropertyData(propertyData);
            
            // Act
            bool hasAnyData = simCityWeb3Model.HasAnyData();

            // Assert
            Assert.That(hasAnyData, Is.True);
        }
        
        
        [Test]
        public void GetPropertyDatas_CountIs0_WhenDefault()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();

            // Act
            List<PropertyData> propertyDatas = simCityWeb3Model.GetPropertyDatas();

            // Assert
            Assert.That(propertyDatas.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void AddPropertyData_CountIs1_WhenAdd1()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            PropertyData propertyData = new MockPropertyData01();
            
            // Act
            simCityWeb3Model.AddPropertyData(propertyData);
            List<PropertyData> propertyDatas = simCityWeb3Model.GetPropertyDatas();

            // Assert
            Assert.That(propertyDatas.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void AddPropertyData_ThrowException_WhenAddExistingObject()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            PropertyData propertyData = new MockPropertyData01();
            
            // Assert
            Assert.That(() =>
                {
                    // Act
                    simCityWeb3Model.AddPropertyData(propertyData);
                    simCityWeb3Model.AddPropertyData(propertyData);
                }, 
                Throws.TypeOf<Exception>());
        }
        
        [Test]
        public void RemovePropertyData_CountIs0_WhenAdd1_Remove1()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            PropertyData propertyData = new MockPropertyData01();
            simCityWeb3Model.AddPropertyData(propertyData);
            
            // Act
            simCityWeb3Model.RemovePropertyData(propertyData);
            List<PropertyData> propertyDatas = simCityWeb3Model.GetPropertyDatas();

            // Assert
            Assert.That(propertyDatas.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void ResetAllData_CountIs0_WhenAdd1_ResetAll()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            PropertyData propertyData = new MockPropertyData01();
            simCityWeb3Model.AddPropertyData(propertyData);
            
            // Act
            simCityWeb3Model.ResetAllData();
            List<PropertyData> propertyDatas = simCityWeb3Model.GetPropertyDatas();

            // Assert
            Assert.That(propertyDatas.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void SetPropertyDatas_CountIs3_WhenSet3()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            List<PropertyData> propertyDatasIn = new List<PropertyData>();
            propertyDatasIn.Add(new MockPropertyData01());
            propertyDatasIn.Add(new MockPropertyData02());
            propertyDatasIn.Add(new MockPropertyData03());
            
            // Act
            Debug.Log("check too");
            simCityWeb3Model.SetPropertyDatas(propertyDatasIn);
            List<PropertyData> propertyDatas = simCityWeb3Model.GetPropertyDatas();

            // Assert
            Assert.That(propertyDatas.Count, Is.EqualTo(3));
        }
        
        [Test]
        public void SetPropertyDatas_ThrowException_WhenAddExistingObject()
        {
            // Arrange
            SimCityWeb3Model simCityWeb3Model = new SimCityWeb3Model();
            List<PropertyData> propertyDatasIn = new List<PropertyData>();
            propertyDatasIn.Add(new MockPropertyData01());
            propertyDatasIn.Add(new MockPropertyData01());
            propertyDatasIn.Add(new MockPropertyData01());
            
            // Assert
            Assert.That(() =>
                {
                    // Act
                    simCityWeb3Model.SetPropertyDatas(propertyDatasIn);
                }, 
                Throws.TypeOf<Exception>());
        }
        

        
        //  Event Handlers --------------------------------
    }
}
