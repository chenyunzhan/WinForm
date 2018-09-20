using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page
{
    class Index
    {
        //get the starting point of 1st range
        public int fromItem(int num, int numPerPage)
        {
            int j = 1;
            for (int i = 0; i < num - 1; i++)
            {
                j += numPerPage;
            }
            return j;
        }
    }
}
