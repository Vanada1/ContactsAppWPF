using System;
using System.Runtime.CompilerServices;

namespace ContactsAppBL
{
    public class ContactBase
    {

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (prop is null)
            {
                throw new ArgumentNullException(nameof(prop));
            }
        }
    }
}