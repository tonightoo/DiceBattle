using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.DataObjects;
using Application.Scenes;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class MenuTitleTest
    {

        private TitleMenu _titleMenu;

        private readonly string FIRST = "A";

        private readonly string SECOND = "B";

        private readonly string THIRD = "C";

        [TestInitialize]
        public void Initialize()
        {
            List<String> menu = new List<string>();
            menu.Add(FIRST);
            menu.Add(SECOND);
            menu.Add(THIRD);
            _titleMenu = new TitleMenu(menu);
        }

        public void TestCount()
        {
            Assert.AreEqual(3, _titleMenu.Count());
        }
            

        [TestMethod]
        public void TestNext()
        {
            _titleMenu.Next();
            Assert.AreEqual(1, _titleMenu.CurrentIndex);
            Assert.AreEqual(SECOND, _titleMenu.Get());

            _titleMenu.Next();
            Assert.AreEqual(2, _titleMenu.CurrentIndex);
            Assert.AreEqual(THIRD, _titleMenu.Get());

            _titleMenu.Next();
            Assert.AreEqual(0, _titleMenu.CurrentIndex);
            Assert.AreEqual(FIRST, _titleMenu.Get());
        }

        [TestMethod]
        public void TestPrevious() 
        {
            _titleMenu.Previous();
            Assert.AreEqual(2, _titleMenu.CurrentIndex);
            Assert.AreEqual(THIRD, _titleMenu.Get());

            _titleMenu.Previous();
            Assert.AreEqual(1, _titleMenu.CurrentIndex);
            Assert.AreEqual(SECOND, _titleMenu.Get());

            _titleMenu.Previous();
            Assert.AreEqual(0, _titleMenu.CurrentIndex);
            Assert.AreEqual(FIRST, _titleMenu.Get());
        }
    }
}
