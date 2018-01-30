using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Together.BusinessLogic.GenericIntefaces
{
    public interface IBusinessAction<in TIn, out TOut>
    {
        TOut Action(TIn dto);
    }
}
