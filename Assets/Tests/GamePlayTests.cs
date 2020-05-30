using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GamePlayTests
    {
        [UnityTest]
        public IEnumerator FullGamePlayTests()
        {
            var source = new GameObject();
            source.AddComponent<Light>();

            var camera = source.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.white;

            source.AddComponent<BinarySearchEngine>();
            var numberWizard = source.AddComponent<NumberWizard>();

            int wait = 0;
            yield return new WaitForSeconds(wait);

            numberWizard.InitWizardNumberData(100, 1, 500);

            numberWizard.PlayerRespond("Lagi Damit");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(250, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Basar");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(375, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Damit");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(312, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Basar");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(343, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Damit");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(327, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Damit");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(319, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Damit");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(315, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Lagi Basar");
            yield return new WaitForSeconds(wait);
            Assert.AreEqual(317, numberWizard.GetOurGuess());

            numberWizard.PlayerRespond("Enggam!");
            yield return new WaitForSeconds(wait);
        }
    }
}
