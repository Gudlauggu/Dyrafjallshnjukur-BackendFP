﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IItemRepo
    {
        Item Create(Item i);

        List<Item> GetAll();
        Item Get(int Id);

        Item Delete(int Id);
    }
}
