using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Models.Abstraction
{
    public abstract class BaseModel<TKey>
    {
        public TKey Id { get; set; }
    }
}
