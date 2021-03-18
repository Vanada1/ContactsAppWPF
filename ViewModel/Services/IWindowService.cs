using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Services
{
    public interface IWindowService
    {
        bool? ShowDialog(object dataContext);
    }
}
