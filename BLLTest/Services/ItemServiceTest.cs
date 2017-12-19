using BLL;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using DAL.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLTest.Services
{
    [TestFixture]
    public class ItemServiceTest
    {
        //Mock To isolate Test Object
        Mock<IDALFacade> dalFacade;
        Mock<IUnitOfWork> uow;
        Mock<IItemRepo> itemRepo;
        Mock<IConverter<Item, ItemBO>> iConv;

        //Entities to work with
        Item itemWithId = new Item() { Id = 1, Name = "Beer" };
        Item itemWithoutId = new Item() {Name = "Beer" };

        //BusinessObjects to work with
        ItemBO itemBOWithId = new ItemBO() { Id = 1, Name = "Beer" };
        ItemBO itemBOWithoutId = new ItemBO() { Name = "Beer" };

        //Test Object
        //IItemService _service;

        [SetUp]
        public void Setup()
        {
            dalFacade = new Mock<IDALFacade>();
            uow = new Mock<IUnitOfWork>();
            itemRepo = new Mock<IItemRepo>();

            iConv = new Mock<IConverter<Item, ItemBO>>();
           
        }
    }
}
