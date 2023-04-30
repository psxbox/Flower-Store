using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.Context.Entities;

public enum Role 
{
    SystemAdmin = 0,
    Admin = 1,
    User = 2,
}