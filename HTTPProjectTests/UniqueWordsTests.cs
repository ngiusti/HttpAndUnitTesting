using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTTPProject.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPProject.Program.Tests
{
    [TestClass()]
    public class UniqueWordsTests
    {
        //Arrange
        UniqueWords words = UniqueWords.ListCreation();


        // compares known value with a known position. 
        [TestMethod()]
        public void ShouldReturnet()
        {
            //Act
            string result = words.UniqueBodyWords[1];    
            //Assert
            Assert.AreEqual("et", result);
        }
         // Checks if values will just return true values
        [TestMethod()]
        public void ShouldNotReturnSunt()
        {
            //Act
            string result = words.UniqueBodyWords[1];
            //Assert
            Assert.AreNotEqual("bob", result);
        }
        // compares a value against the whole list.
        [TestMethod()]
        public void SeeIfValueIsInList()
        {
            //Act
            List<string> titleResults = words.UniqueTitleWords.ToList();
            List<string> bodyResults = words.UniqueBodyWords.ToList();
            //Assert
            CollectionAssert.Contains(titleResults, "et");
            CollectionAssert.Contains(bodyResults, "et");
        }
        // See if random values are in lists
        [TestMethod()]
        public void AnyValue()
        {
            //Act
            List<string> titleResults = words.UniqueTitleWords.ToList();
            List<string> bodyResults = words.UniqueBodyWords.ToList();
            //Assert
            CollectionAssert.DoesNotContain(titleResults, "x");
            CollectionAssert.DoesNotContain(bodyResults, "x");
        }
        // See if the two Result lists are the same.
        [TestMethod()]
        public void UniqueLists()
        {
             
            //Act
            List<string> titleResults = words.UniqueTitleWords.ToList();
            List<string> bodyResults = words.UniqueBodyWords.ToList();
            //Assert
            CollectionAssert.AreNotEqual(bodyResults, titleResults);

        }
        // See if all values are of same Type
        [TestMethod]
        public void ListCheck()
        {
            //Act
            List<string> titleResults = words.UniqueTitleWords.ToList();
            List<string> bodyResults = words.UniqueBodyWords.ToList();
            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(titleResults, typeof(string));
            CollectionAssert.AllItemsAreInstancesOfType(bodyResults, typeof(string));

        }
    }
}