﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
