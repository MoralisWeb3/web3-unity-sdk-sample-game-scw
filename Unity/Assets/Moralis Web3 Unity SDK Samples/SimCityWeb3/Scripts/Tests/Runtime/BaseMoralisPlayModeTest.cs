using System.Collections;
using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Objects;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace MoralisUnity.Samples
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseMoralisPlayModeTest
    {
        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------
        
        //  Unity Methods----------------------------------
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Executes BEFORE ALL test methods of this test class
            Moralis.Start();
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
        /// <summary>
        /// Run the game, log in with your mobile game. Then stop the game.
        /// Now run the tests with success.
        ///
        /// This is hacky, but it works. In the future, I'd like to reduce the steps required. - srivello
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator _AuthenticationRequired_WhenTesting() => UniTask.ToCoroutine(async () =>
        {
            // Arrange

            // Act
            MoralisUser moralisUser = await Moralis.GetUserAsync();
            bool isAuthenticated = moralisUser != null;

            // Assert
            Assert.That(isAuthenticated, Is.True);
            
        });
        
        //  Event Handlers --------------------------------
    }
}
